using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tracker_DataLayer;

namespace Tracker_BusinessLogic
{
    public class clsMatchEntry
    {
        /// <summary>
        /// ID for this Match Entry
        /// </summary>
        public int MatchEntryID { get; set; }
        /// <summary>
        /// represent team who playing
        /// </summary>
        public clsTeam TeamCompeting { get; set; } = new clsTeam();
        /// <summary>
        /// represent team score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Represents the match ID in which the team plays
        /// </summary>
        public int ParentMatchID { get; set; }

        public clsMatchEntry()
        {
            MatchEntryID = -1;
            Score = -1;
            ParentMatchID = -1;
        }

        private async Task<bool> _AddNewMatchEntry()
        {
            MatchEntryID = await clsMatchEntryData.AddNewMatchEntryByMatchID(this.ParentMatchID, TeamCompeting.TeamID, Score);
            return MatchEntryID > 0;
        }

        public async Task<bool> Save()
        {
            return await _AddNewMatchEntry();
        }

        public static async Task<List<clsMatchEntry>> GetAllEntriesByMatchID(int MatchID)
        {
            List<clsMatchEntry> Entries = new List<clsMatchEntry>();
            DataTable result = new DataTable();

            result = await clsMatchEntryData.FindMatchEntryByMatchID(MatchID);

            foreach(DataRow row in result.Rows)
            {
                clsMatchEntry entry = new clsMatchEntry();
                entry.MatchEntryID = (int)row["MatchEntryID"];
                entry.ParentMatchID = (int)row["MatchID"];
                if (row["TeamID"] != DBNull.Value)
                {
                    int TeamID = Convert.ToInt32(row["TeamID"]);
                    entry.TeamCompeting = await clsTeam.GetTeamInfoByID(TeamID);
                }
                else entry.TeamCompeting = null;
                if (row["Score"] != DBNull.Value)
                {
                    entry.Score = (int)row["Score"];
                }
                else entry.Score = -1;

                Entries.Add(entry);
            }
            return Entries;
        }

        public async Task<bool> SaveEntryScore()
        {
            return await clsMatchEntryData.SaveEntryResult(this.MatchEntryID, this.Score);
        }
    }
}
