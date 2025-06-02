using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker_DataLayer;
using System.Data;
using System.Linq;

namespace Tracker_BusinessLogic
{
    public class clsTournament
    {
        /// <summary>
        /// Tournament ID for this tournament
        /// </summary>
        public int TournamentID { get; set; }
        /// <summary>
        /// Tournment Name
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Entry fees for participate in this Tournament
        /// </summary>
        public decimal EntryFees { get; set; }
        /// <summary>
        /// teams that participate in this Tournament
        /// </summary>
        public List<clsTeam> Teams { get; set; } = new List<clsTeam>();
        /// <summary>
        /// represent the list of prizes in this Tournament
        /// </summary>
        public List<clsPrize> Prizes { get; set; } = new List<clsPrize>();
        /// <summary>
        /// represent the matches that played in each round
        /// </summary>
        /// <example>
        /// Round[0] => get the list of all matches that played in round one
        /// Round[1] => get the list of all matches that played in round two
        /// </example>
        public List<List<clsMatch>> Rounds { get; set; } = new List<List<clsMatch>>();

        public int CreatedByUserID { get; set; }

        public clsTournament()
        {
            TournamentName = "";
            EntryFees = 0;
        }
        private clsTournament(string TournamentName, decimal EntryFees, List<clsTeam> Teams, List<clsPrize> Prizes, List<List<clsMatch>> Rounds)
        {
            this.TournamentName = TournamentName;
            this.EntryFees = EntryFees;
            this.Teams = Teams;
            this.Prizes = Prizes;
            this.Rounds = Rounds;
        }
        private int _GetNumOfRound() => (int)Math.Ceiling(Math.Log(Teams.Count,2));// if we have 5 teams then number of round equel 3
        private int _GetNumOfSpecialTeam(int NumOfRound) => (int)Math.Pow(2, NumOfRound) - Teams.Count;// 8 - 5 = (3) => special team

        public void CreateAllRounds()
        {
            //TODO- Randomize Team List
            int NumOfRound = _GetNumOfRound();
            int NumOfSpecailTeam = _GetNumOfSpecialTeam(NumOfRound);

            _CreateFirstRound(NumOfSpecailTeam);
            _CreateOtherRounds(NumOfRound);

        }
        private void _CreateFirstRound(int NumOfSpecialTeam)
        {
            List<clsMatch> FirstRound = new List<clsMatch>();
            clsMatch Match = new clsMatch();
            foreach(clsTeam Team in Teams)
            {
                Match.Entries.Add(new clsMatchEntry { TeamCompeting = Team });
                if(Match.Entries.Count > 1 || NumOfSpecialTeam > 0)
                {
                    if (NumOfSpecialTeam > 0)
                    {
                        Match.Winner.TeamID = Team.TeamID;
                        NumOfSpecialTeam--;
                    }
                    Match.MatchRound = 1;
                    FirstRound.Add(Match);
                    Match = new clsMatch();
                }
            }
            Rounds.Add(FirstRound);
        }
        private void _CreateOtherRounds(int NumberOfRound)
        {
            List<clsMatch> PerfRound = Rounds[0];
            List<clsMatch> CurRound = new List<clsMatch>();
            clsMatch CurMatch = new clsMatch();

            for(int RoundNum = 2; RoundNum <= NumberOfRound; RoundNum++)// start from Round 2
            {
                foreach(clsMatch Match in PerfRound)
                {
                    CurMatch.Entries.Add(new clsMatchEntry());

                    if(CurMatch.Entries.Count > 1)
                    {
                        CurMatch.MatchRound = RoundNum;
                        CurRound.Add(CurMatch);
                        CurMatch = new clsMatch();
                    }
                }
                Rounds.Add(CurRound);// add it round to all round
                PerfRound = CurRound;
                CurRound = new List<clsMatch>();
                CurMatch = new clsMatch();
            }
        }

        public async Task<bool> SaveTournament()
        {
            TournamentID = await clsTournamentData.CreateNewTournament(this.TournamentName, this.EntryFees, this.CreatedByUserID);// Create Tournament record
            if (TournamentID > 0)// if tournament created sucessuflly
            {
                if (!await _SavePrizesList())// if save prizes list is failed
                    return false;
                if (!await _SaveTeamsIntoTournament())// if save Teams list is failed
                    return false;
                if (!await _SaveRounds())// if save Matchs in all rounds is falied
                    return false;
            }
            else return false;
            return true;
        }
        /// <summary>
        /// this function save Team into tournament
        /// </summary>
        /// <returns>return true if added sucessfully otherwise return false</returns>
        private async Task<bool> _SaveTeamsIntoTournament()
        {
            foreach(clsTeam CurTeam in Teams)
            {
                if (await clsTournamentData.AddTeamToTournament(this.TournamentID, CurTeam.TeamID) < 1)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// this fuction save all prizes in prize list
        /// </summary>
        /// <returns> return true if all prizes added sucessuflly otherwize return flase</returns>
        private async Task<bool> _SavePrizesList()
        {
            foreach(clsPrize CurPrize in Prizes)
            {
                if (!await CurPrize.Save(TournamentID))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// this function Save all matches in round and add it to database
        /// </summary>
        /// <returns></returns>
        private async Task<bool> _SaveRounds()
        {

            foreach(var CurRound in Rounds)
            {
                foreach(clsMatch CurMacth in CurRound)
                {
                    CurMacth.TournamentID = this.TournamentID;
                    if (!await CurMacth.CreateMatch())
                        return false;
                    foreach(clsMatchEntry CurMatchEntry in CurMacth.Entries)
                    {
                        CurMatchEntry.ParentMatchID = CurMacth.MatchID;
                        if (!await CurMatchEntry.Save())
                            return false;
                    }
                }
            }
            return true;
        }

        public static async Task<DataTable> GetAllTournamentsInDataTable()
        {
            return await clsTournamentData.GetAllTournaments();
        }

        public static async Task<List<clsTournament>> GetAllTournaments()
        {
            List<clsTournament> Tournaments = new List<clsTournament>();
            DataTable TournamentsData = await clsTournamentData.GetAllTournaments();
            foreach(DataRow Row in TournamentsData.Rows)
            {
                clsTournament CurTournament = new clsTournament();
                CurTournament.TournamentID = int.Parse(Row["TournamentID"].ToString());// tournament ID
                CurTournament.TournamentName = Row["TournamentName"].ToString();// tournament Name
                CurTournament.EntryFees = Convert.ToDecimal(Row["EntryFee"]);// entry fees
                CurTournament.CreatedByUserID = int.Parse(Row["UserID"].ToString());
                Tournaments.Add(CurTournament);
            }

            return Tournaments;
        }

        public int GetCurRoundNumber()
        {
            int result = clsTournamentData.GetCurRound(this.TournamentID);
            if (result < 1)
                result = clsTournamentData.NumberOFRoundInTournament(this.TournamentID);
            
            return result;
        }

        public async Task<bool> HandelMatchInNextRound(clsMatch LastPlayedMatch)
        {
            int CurRound = clsTournamentData.GetCurRound(this.TournamentID);

            if (CurRound == LastPlayedMatch.MatchRound + 1)
            {
                List<clsMatch> Matchs = Rounds[LastPlayedMatch.MatchRound - 1];

                List<int> Winners = Matchs.
                    Where(match => match.Winner.TeamID > 0).
                    Select(match => match.Winner.TeamID).ToList();

                if (await clsTournamentData.AddWinnerTeamsToNextRound( Winners, LastPlayedMatch.MatchID + 1))
                    return true;
                else
                    return false;
                
            }
            return true;
        }

        

    }
}
