using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tracker_DataLayer;

namespace Tracker_BusinessLogic
{
    public class clsMatch
    {
        /// <summary>
        /// match ID for this object
        /// </summary>
        public int MatchID { get; set; }
        /// <summary>
        /// represent the teams in this match by other word represent two team who played each other
        /// </summary>
        public List<clsMatchEntry> Entries { get; set; } = new List<clsMatchEntry>();
        /// <summary>
        /// Represents the round in which this match was played
        /// </summary>
        public int MatchRound { get; set; }
        /// <summary>
        /// represents the team who won this match
        /// </summary>
        public clsTeam Winner { get; set; } = new clsTeam();
        /// <summary>
        /// tournament id for the tournament that match will play in it 
        /// </summary>
        public int TournamentID { get; set; }
       
        public clsMatch()
        {
            this.MatchID = -1;
            this.MatchRound = -1;
        }


        public async Task<bool> CreateMatch()
        {
            MatchID = await clsMatchData.CreateMatch(this.Winner.TeamID, this.MatchRound, TournamentID);
            return MatchID > -1;
        }

        public async static Task<DataTable> GetAllMatchsInTournamentInDataTable(int TournamentID)
        {
            return await clsMatchData.GetAllMatchesInTournament(TournamentID);
        }


        public async static Task<List<List<clsMatch>>> GetAllMatchsByTournamentID(int SelectedTournament)
        {
            DataTable Result = new DataTable();
            Result = await clsMatchData.GetAllMatchesInTournament(SelectedTournament);

            if (Result.Rows.Count == 0)
                return null;

            // Calculate the number of rounds
            int NumberOfRounds = (int)Math.Ceiling(Math.Log(Result.Rows.Count, 2));
            List<List<clsMatch>> Matches = new List<List<clsMatch>>(NumberOfRounds);

            // Initialize the inner lists
            for (int i = 0; i < NumberOfRounds; i++)
            {
                Matches.Add(new List<clsMatch>());
            }

            // Populate the Matches list
            foreach (DataRow Row in Result.Rows)
            {
                clsMatch CurMatch = new clsMatch
                {
                    TournamentID = SelectedTournament,
                    MatchID = Convert.ToInt32(Row["MatchID"]),
                    MatchRound = Convert.ToInt32(Row["Round"]),
                    Entries = await clsMatchEntry.GetAllEntriesByMatchID(Convert.ToInt32(Row["MatchID"])) // Ensure correct parameter
                };

                // handel winner team in CurMatch
                if (CurMatch.Entries.Count == 1)
                {
                    CurMatch.Entries[0].Score = 0;
                    CurMatch.Winner = CurMatch.Entries[0].TeamCompeting;
                }
                else if (CurMatch.Entries[0].Score > CurMatch.Entries[1].Score)
                {
                    CurMatch.Winner = CurMatch.Entries[0].TeamCompeting;
                }
                else if (CurMatch.Entries[0].Score < CurMatch.Entries[1].Score)
                {
                    CurMatch.Winner = CurMatch.Entries[1].TeamCompeting;
                }
                //---------

                if (CurMatch.MatchRound >= 0 && CurMatch.MatchRound <= NumberOfRounds)
                {
                    Matches[CurMatch.MatchRound-1].Add(CurMatch);
                }
            }

            return Matches;
        }

        public async Task<bool> SaveMatchResult()
        {

            if (this.Entries[0].Score > this.Entries[1].Score)
                this.Winner = this.Entries[0].TeamCompeting;
            else
                this.Winner = this.Entries[1].TeamCompeting;

            bool MatchIsSaved = await clsMatchData.SaveMatchResult(this.MatchID, this.Winner.TeamID);

            if (MatchIsSaved)
            {
                foreach (var entry in this.Entries)
                {
                    if (await entry.SaveEntryScore() == false)
                        return false;
                }
            }
            else return false;
            return true;
        }

        public static async Task<clsMatch> FindMatch(int MatchID)
        {
            DataTable result = await  clsMatchData.FindMatch(MatchID);

            clsMatch Match = new clsMatch();

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                Match.MatchID = MatchID;
                if(row["WinnerTeamID"] != DBNull.Value)
                    Match.Winner = await clsTeam.GetTeamInfoByID(int.Parse(row["WinnerTeamID"].ToString()));

                Match.Entries = await clsMatchEntry.GetAllEntriesByMatchID(MatchID);
                Match.MatchRound = int.Parse(row["Round"].ToString());
                Match.TournamentID = int.Parse(row["TournamentID"].ToString());
                
                return Match;
            }
            else return null;
        }
        
    }
}
