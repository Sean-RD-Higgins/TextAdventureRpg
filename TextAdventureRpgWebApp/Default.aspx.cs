using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextAdventureRpgLibrary;
using TextAdventureRpgWebApp.Models;

namespace TextAdventureRpgWebApp
{
    public partial class Default : Page
    {
        private HomeModel _model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                _model = (HomeModel)ViewState["Model"];
                GameLoop(UserInputTextBox.Text);
            }
            else
            {
                _model = GetDefaultModel();
                Initialize();
            }
            UserInputTextBox.Text = "";
            ConsoleLabel.Text = _model.ConsoleOutput.ToString();
            ViewState["Model"] = _model;
        }

        public string GetConsoleOutput()
        {
            return _model.ConsoleOutput.ToString().Replace("\n", "<br/>");
        }

        public void Initialize()
        {
            _model.ConsoleOutput.AppendLine("Text Adventure RPG - Version 1");
            _model.ConsoleOutput.AppendLine("Press any key to advance text.  Enter any of the following actions if the > icon appears.");
            foreach (string helpText in _model.CurrentWorld.GetHelpText())
            {
                _model.ConsoleOutput.AppendLine(helpText);
            }

            string[] arrivalText = (string[])_model.CurrentWorld.GetArrivalText();
            foreach (string textLine in arrivalText)
            {
                _model.ConsoleOutput.AppendLine(textLine);
            }
        }

        public void GameLoop(string userInput)
        {
            // TODO - place logic in MapStrategy instead of World.
            List<string> textList = new List<string>(_model.CurrentWorld.GetResult(userInput));
            foreach (string textLine in textList)
            {
                _model.ConsoleOutput.AppendLine(textLine);
            }
        }


        // TODO - Move to Factory in the Library code.
        private HomeModel GetDefaultModel()
        {
            HomeModel model = new HomeModel
            {
                ConsoleOutput = new StringBuilder((ViewState["ConsoleOutput"] ?? string.Empty).ToString())
            };
            IMapTile[,] TileMatrix = new IMapTile[3, 3];
            TileMatrix[0, 0] =
                new DialogueMapTile(new[]{ "You arrive at a bunch of mountains.",
                    "They seem to stretch on for miles to the north and west.",
                    "There's no going back now." },
                new[] { "The mountains are really tall.",
                    "Tall things definitely make you nervous."});
            TileMatrix[0, 1] = new DialogueMapTile("You are traversing a grassy field.",
                "The grassy field has lots of flowers.");
            TileMatrix[0, 2] = new DialogueMapTile(
                new[] { "You are treading across a pond." },
                new[] { "The pond has no fish in it." ,
                    "Kinda a shame.  You could go for some fish."});
            // TODO - Add a logic separator for if the shop is closed or not.
            TileMatrix[1, 0] = new ShopMapTile(
                new[] { "You are knee deep in a marsh.",
                    "You stumble upon a shopkeeper.",
                    "Interested in some potions, stranger?  Only 20 Currency each!",
                    "Just let me know if you want to \"buy 1\" or \"buy 5\" or whatever amount you need!"},
                new[] { "There are far too many bugs here." },
                new TimeSpan(7, 30, 00), new TimeSpan(12 + 4, 10, 00));
            TileMatrix[1, 1] = new DialogueMapTile("You are trekking across a barren desert.",
                "It is really dry in the desert.");
            TileMatrix[1, 2] = new DialogueMapTile("You are moving through a tundra.",
                "You're a bit concerned that a tundra can be next to a desert.");
            TileMatrix[2, 0] = new DialogueMapTile("You bump into a castle.",
                "You see a tall foreboding fortress of a structure that towers over you.  The double doors are meant for a giant.  Which means you can't reach the doornobs.");
            TileMatrix[2, 1] = new DialogueMapTile("You fall into a ravine.",
                "It is pretty dark down here.  You're going to have a really bad time climbing out.");
            TileMatrix[2, 2] = new DialogueMapTile("You are floating in outer space.",
                "You luckily don't know there's no oxygen here and breathe just fine.");

            model.CurrentWorld = new World()
            {
                TileMatrix = TileMatrix,
                CurrentDateTime = DateTime.Parse("1576-05-01 08:00:00.000"),
                PlayerOne = new Player()
                {
                    Currency = 100
                }
            };

            return model;
        }

    }
}