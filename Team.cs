using System.Collections.Generic;

namespace SportzInteractive
{
    public class Team
    {
        //[JsonProperty("Name_Full")]
        public string NameFull { get; set; }
        public string NameShort { get; set; }

        public Dictionary<string, TeamPlayer> Players { get; set; }

    }

    public class TeamPlayer
    {
        public string Position { get; set; }

        public string NameFull { get; set; }

        public bool IsCaptain { get; set; }

    }
}
