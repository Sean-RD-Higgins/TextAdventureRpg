using System.Collections;
using System.Collections.Generic;

namespace TextAdventureRpgLibrary
{
    public class MapTile
    {
        public MapTile()
        {
            ArrivalText = new string[] { };
            LookText = new string[] { };
        }

        public MapTile(IEnumerable<string> arrivalText, IEnumerable<string> lookText)
        {
            ArrivalText = arrivalText;
            LookText = lookText;
        }

        public MapTile(string arrivalText, string lookText)
        {
            ArrivalText = new string[] { arrivalText };
            LookText = new string[] { lookText };
        }

        public IEnumerable<string> ArrivalText { get; internal set; }
        public IEnumerable<string> LookText { get; internal set; }
    }
}