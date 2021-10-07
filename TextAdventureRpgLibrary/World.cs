using System;
using System.Collections.Generic;

namespace TextAdventureRpgLibrary
{
    public class World
    {

        public World()
        {
            TileMatrix = new MapTile[1, 1]
            {
                { new MapTile(MOVEMENT_BLOCKED_DISPLAY_TEXT, MOVEMENT_BLOCKED_DISPLAY_TEXT) }
            };
            ActionToFunctionMap = GetActionToFunctionMap();
            PlayerOne = new Player();
        }

        public World(MapTile[,] tileMatrix, Player playerOne)
        {
            TileMatrix = tileMatrix;
            ActionToFunctionMap = GetActionToFunctionMap();
            PlayerOne = playerOne;
        }

        public World(MapTile[,] tileMatrix, Dictionary<string, Func<IEnumerable<string>>> actionToFunctionMap, Player playerOne)
        {
            TileMatrix = tileMatrix;
            ActionToFunctionMap = actionToFunctionMap;
            PlayerOne = playerOne;
        }

        #region Constants

        private readonly string MOVEMENT_BLOCKED_DISPLAY_TEXT = "A tall vast mountainous region blocks your path that is insurmountable.";
        private readonly string PREPEND_HELP_TEXT = "You need to type an action (or exit), like any of the following:";

        #endregion Constants


        #region Properties

        MapTile[,] TileMatrix { get; set; }
        Dictionary<string, Func<IEnumerable<string>>> ActionToFunctionMap { get; set; }
        Player PlayerOne { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerable<string> GetResult(string actionText)
        {
            string lowercaseActionText = actionText.ToLower().Replace(" ", string.Empty);
            Func<IEnumerable<string>> callFunction;
            bool actionExists = ActionToFunctionMap.TryGetValue(lowercaseActionText, out callFunction);
            if(!actionExists)
            {
                return GetHelpText();
            }
            return callFunction.Invoke();
        }

        public IEnumerable<string> GetHelpText()
        {
            return new string[] { $"{PREPEND_HELP_TEXT}{string.Join(',', ActionToFunctionMap.Keys)}" };
        }

        public IEnumerable<string> GetArrivalText()
        {
            return TileMatrix[PlayerOne.XLocation,PlayerOne.YLocation].ArrivalText;
        }

        public IEnumerable<string> GetLookText()
        {
            return TileMatrix[PlayerOne.XLocation,PlayerOne.YLocation].LookText;
        }

        public IEnumerable<string> DisplayActionList()
        {
            return TileMatrix[PlayerOne.XLocation,PlayerOne.YLocation].ArrivalText;
        }

        public IEnumerable<string> GoNorth()
        {
            if (PlayerOne.YLocation == 0)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            PlayerOne.YLocation--;
            return GetArrivalText();
        }

        public IEnumerable<string> GoEast()
        {
            if (PlayerOne.XLocation == TileMatrix.GetLength(1) - 1)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            PlayerOne.XLocation++;
            return GetArrivalText();
        }

        public IEnumerable<string> GoSouth()
        {
            if (PlayerOne.YLocation == TileMatrix.GetLength(1) - 1)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            PlayerOne.YLocation++;
            return GetArrivalText();
        }

        public IEnumerable<string> GoWest()
        {
            if (PlayerOne.XLocation == 0)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            PlayerOne.XLocation--;
            return GetArrivalText();
        }

        public Dictionary<string, Func<IEnumerable<string>>> GetActionToFunctionMap()
        {
            return new Dictionary<string, Func<IEnumerable<string>>>()
            {
                { MapAction.GoNorth.Value.ToLower().Replace(" ", string.Empty), GoNorth },
                { MapAction.GoEast.Value.ToLower().Replace(" ", string.Empty), GoEast },
                { MapAction.GoSouth.Value.ToLower().Replace(" ", string.Empty), GoSouth },
                { MapAction.GoWest.Value.ToLower().Replace(" ", string.Empty), GoWest },
                { MapAction.Look.Value.ToLower().Replace(" ", string.Empty), GetLookText }
            };
        }

        #endregion Methods
    }
}
