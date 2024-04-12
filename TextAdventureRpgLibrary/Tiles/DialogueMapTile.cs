using System;
using System.Collections;
using System.Collections.Generic;

namespace TextAdventureRpgLibrary
{
    [Serializable]
    public class DialogueMapTile : IMapTile
    {
        public DialogueMapTile()
        {
            ArrivalText = new string[] { };
            LookText = new string[] { };
            Actions = new ActionCollection();
        }

        public DialogueMapTile(IEnumerable<string> arrivalText, IEnumerable<string> lookText)
        {
            ArrivalText = arrivalText;
            LookText = lookText;
            Actions = new ActionCollection();
        }

        public DialogueMapTile(string arrivalText, string lookText)
        {
            ArrivalText = new string[] { arrivalText };
            LookText = new string[] { lookText };
            Actions = new ActionCollection();
        }

        public IEnumerable<string> ArrivalText { get; set; }
        public IEnumerable<string> LookText { get; set; }
        public ActionCollection Actions { get; set; }
    }
}