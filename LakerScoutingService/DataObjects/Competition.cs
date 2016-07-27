using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace LakerScoutingService.DataObjects
{
    public class Competition : EntityData
    {
        public int CompetitionId { get; set; }
        public string Location { get; set; }
        public List<Team> TeamList { get; set; }


    }
}