using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdventureRpgLibrary
{
    public class World
    {

        public World()
        {
            TileMatrix = new DialogueMapTile[1, 1]
            {
                { new DialogueMapTile(MOVEMENT_BLOCKED_DISPLAY_TEXT, MOVEMENT_BLOCKED_DISPLAY_TEXT) }
            };
            Actions = GetActions();
            PlayerOne = new Player();
        }

        #region Constants

        private readonly string MOVEMENT_BLOCKED_DISPLAY_TEXT = "A tall vast mountainous region blocks your path that is insurmountable.";
        private readonly string MOVEMENT_COMPLETE_DISPLAY_TEXT = "You venture {0}.  The time is now {1}.";
        private readonly string PREPEND_HELP_TEXT = "You need to type an action (or exit), like any of the following:";
        private readonly TimeSpan TIME_DELTA_ON_MOVEMENT = new TimeSpan(0, 15, 0);

        #endregion Constants


        #region Properties

        public IMapTile[,] TileMatrix { get; set; }
        public ActionCollection Actions { get; set; }
        public Player PlayerOne { get; set; }
        public DateTime CurrentDateTime { get; set; }

        #endregion Properties

        #region Methods

        public IEnumerable<string> GetResult(string actionText)
        {
            string actionWord = actionText.Split(" ").First();
            string additionalInput = actionText.Split(" ").Last();

            var tileActionFunction = GetCurrentTile().Actions.GetActionFunction(actionWord);
            if(tileActionFunction != null)
            {
                return tileActionFunction.Invoke(additionalInput, this);
            }

            var worldActionFunction = Actions.GetActionFunction(actionText);
            if(worldActionFunction != null)
            {
                return worldActionFunction.Invoke(additionalInput, this);
            }
            return GetHelpText();
        }

        public IEnumerable<string> GetHelpText()
        {
            string worldActions = string.Join(',', Actions.GetActionList());
            string tileActions = string.Join(',', GetCurrentTile().Actions.GetActionList());
            return new string[] { $"{PREPEND_HELP_TEXT}{worldActions}", tileActions };
        }

        private IMapTile GetCurrentTile()
        {
            return TileMatrix[PlayerOne.XLocation, PlayerOne.YLocation];
        }

        public IEnumerable<string> GetArrivalText()
        {
            return GetCurrentTile().ArrivalText;
        }

        public IEnumerable<string> GetLookText(string additionalInput, World world)
        {
            return GetCurrentTile().LookText;
        }

        public IEnumerable<string> DisplayActionList()
        {
            return GetCurrentTile().ArrivalText;
        }

        public IEnumerable<string> GoNorth(string additionalInput, World world)
        {
            if (PlayerOne.YLocation == 0)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            CurrentDateTime = CurrentDateTime.Add(TIME_DELTA_ON_MOVEMENT);
            PlayerOne.YLocation--;
            string movementDialogue = string.Format(MOVEMENT_COMPLETE_DISPLAY_TEXT, "North", CurrentDateTime.ToString());
            List<string> dialogueText = new List<string>() { movementDialogue };
            dialogueText.AddRange(GetArrivalText());
            return dialogueText;
        }

        public IEnumerable<string> GoEast(string additionalInput, World world)
        {
            if (PlayerOne.XLocation == TileMatrix.GetLength(1) - 1)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            CurrentDateTime = CurrentDateTime.Add(TIME_DELTA_ON_MOVEMENT);
            PlayerOne.XLocation++;
            string movementDialogue = string.Format(MOVEMENT_COMPLETE_DISPLAY_TEXT, "East", CurrentDateTime.ToString());
            List<string> dialogueText = new List<string>() { movementDialogue };
            dialogueText.AddRange(GetArrivalText());
            return dialogueText;
        }

        public IEnumerable<string> GoSouth(string additionalInput, World world)
        {
            if (PlayerOne.YLocation == TileMatrix.GetLength(1) - 1)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            CurrentDateTime = CurrentDateTime.Add(TIME_DELTA_ON_MOVEMENT);
            PlayerOne.YLocation++;
            string movementDialogue = string.Format(MOVEMENT_COMPLETE_DISPLAY_TEXT, "South", CurrentDateTime.ToString());
            List<string> dialogueText = new List<string>() { movementDialogue };
            dialogueText.AddRange(GetArrivalText());
            return dialogueText;
        }

        public IEnumerable<string> GoWest(string additionalInput, World world)
        {
            if (PlayerOne.XLocation == 0)
            {
                return new string[] { MOVEMENT_BLOCKED_DISPLAY_TEXT };
            }

            CurrentDateTime = CurrentDateTime.Add(TIME_DELTA_ON_MOVEMENT);
            PlayerOne.XLocation--;
            string movementDialogue = string.Format(MOVEMENT_COMPLETE_DISPLAY_TEXT, "West", CurrentDateTime.ToString());
            List<string> dialogueText = new List<string>() { movementDialogue };
            dialogueText.AddRange(GetArrivalText());
            return dialogueText;
        }

        public IEnumerable<string> GetMirrorText(string additionalInput, World world)
        {
            return new string[] { $"You gaze into the mirror for some \"self-reflection.\"  " +
                $"Location: {PlayerOne.XLocation}, {PlayerOne.YLocation}.  " +
                $"Currency: {PlayerOne.Currency}.  " +
                $"Potions: {PlayerOne.PotionCount}" };
        }

        public ActionCollection GetActions()
        {
            ActionCollection actionCollection = new ActionCollection();
            actionCollection.Add(MapAction.GoNorth.Value, GoNorth);
            actionCollection.Add(MapAction.GoEast.Value, GoEast);
            actionCollection.Add(MapAction.GoSouth.Value, GoSouth);
            actionCollection.Add(MapAction.GoWest.Value, GoWest);
            actionCollection.Add(MapAction.Look.Value, GetLookText);
            actionCollection.Add(MapAction.Mirror.Value, GetMirrorText);
            return actionCollection;
        }

        #endregion Methods
    }
}
