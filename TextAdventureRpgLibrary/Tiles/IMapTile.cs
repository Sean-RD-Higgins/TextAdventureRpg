using System;
using System.Collections;
using System.Collections.Generic;

namespace TextAdventureRpgLibrary
{
    public interface IMapTile
    {
        IEnumerable<string> ArrivalText { get; set; }
        IEnumerable<string> LookText { get; set; }
        ActionCollection Actions { get; set; }
    }
}