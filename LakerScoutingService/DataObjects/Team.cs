using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace LakerScoutingService.DataObjects
{
    public class Team : EntityData
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public DateTime RookieYear { get; set; }
    }
}