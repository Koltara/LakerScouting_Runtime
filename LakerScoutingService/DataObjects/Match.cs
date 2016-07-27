using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LakerScoutingService.DataObjects
{
    public class Match : EntityData
    {
        public int MatchNumber { get; set; }
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }
        

        public int HighGoalsScored { get; set; }
        public int HighGoalsAttempted { get; set; }
        public bool CrossLowBar { get; set; }
    }
}