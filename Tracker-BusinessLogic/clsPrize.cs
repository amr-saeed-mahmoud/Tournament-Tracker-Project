using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tracker_DataLayer;

namespace Tracker_BusinessLogic
{
    public class clsPrize
    {
        public int PrizeID { get; set; }
        /// <summary>
        /// The position number that the team obtained
        /// </summary>
        public int PlaceNumber{ get; set; }
        /// <summary>
        /// The position Name that the team obtained
        /// </summary>
        public string PlaceName{ get; set; }
        /// <summary>
        /// Prize value
        /// </summary>
        public decimal PrizeAmount{ get; set; }
        /// <summary>
        /// The reward percentage from fixed amount
        /// </summary>
        public decimal PrizePercentage { get; set; }
        public clsPrize()
        {
            PrizeID = -1;
            PlaceNumber = -1;
            PlaceName = "";
            PrizeAmount = -1;
            PrizePercentage = -1;
        }

        private async Task<int> _AddNewPrize(int TournamentID)
        {
            return await clsPrizeData.AddNewPrizeByTournamentID(TournamentID, PlaceNumber, PlaceName, PrizeAmount, PrizePercentage);
        }

        public async Task<bool> Save(int TournamentID)
        {
            PrizeID = await _AddNewPrize(TournamentID);
            return PrizeID > 0;
        }
    }
}
