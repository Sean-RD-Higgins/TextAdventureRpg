using System;
using System.Collections.Generic;
using TextAdventureRpgLibrary;

namespace TextAdventureRpgConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text Adventure RPG - Version 1");

            IMapTile[,] tileMatrix = new IMapTile[3, 3];
            tileMatrix[0, 0] =
                new DialogueMapTile(new []{ "You arrive at a bunch of mountains.",
                    "They seem to stretch on for miles to the north and west.",
                    "There's no going back now." },
                new [] { "The mountains are really tall.",
                    "Tall things definitely make you nervous."});
            tileMatrix[0, 1] = new DialogueMapTile("You are traversing a grassy field.", 
                "The grassy field has lots of flowers.");
            tileMatrix[0, 2] = new DialogueMapTile(
                new [] { "You are treading across a pond." }, 
                new [] { "The pond has no fish in it." , 
                    "Kinda a shame.  You could go for some fish."});
            // TODO - Add a logic separator for if the shop is closed or not.
            tileMatrix[1, 0] = new ShopMapTile(
                new [] { "You are knee deep in a marsh.", 
                    "You stumble upon a shopkeeper.",
                    "Interested in some potions, stranger?  Only 20 Currency each!",
                    "Just let me know if you want to \"buy 1\" or \"buy 5\" or whatever amount you need!"},
                new [] { "There are far too many bugs here." },
                new TimeSpan(7,30,00), new TimeSpan(12+4, 10, 00));
            tileMatrix[1, 1] = new DialogueMapTile("You are trekking across a barren desert.", 
                "It is really dry in the desert.");
            tileMatrix[1, 2] = new DialogueMapTile("You are moving through a tundra.", 
                "You're a bit concerned that a tundra can be next to a desert.");
            tileMatrix[2, 0] = new DialogueMapTile("You bump into a castle.", 
                "You see a tall foreboding fortress of a structure that towers over you.  The double doors are meant for a giant.  Which means you can't reach the doornobs.");
            tileMatrix[2, 1] = new DialogueMapTile("You fall into a ravine.", 
                "It is pretty dark down here.  You're going to have a really bad time climbing out.");
            tileMatrix[2, 2] = new DialogueMapTile("You are floating in outer space.", 
                "You luckily don't know there's no oxygen here and breathe just fine.");

            Player playerOne = new Player()
            {
                Currency = 100
            };
            World currentWorld = new World()
            {
                TileMatrix = tileMatrix,
                CurrentDateTime = DateTime.Parse("1576-05-01 08:00:00.000"),
                PlayerOne = playerOne
            };

            Console.WriteLine("Press any key to advance text.  Enter any of the following actions if the > icon appears.");
            foreach (string helpText in currentWorld.GetHelpText()) 
            { 
                Console.WriteLine(helpText); 
            }

            string[] arrivalText = (string[])currentWorld.GetArrivalText();
            foreach (string textLine in arrivalText)
            {
                Console.WriteLine(textLine);
                if (arrivalText.Length > 1)
                { 
                    Console.ReadKey(); 
                }
            }

            while (true)
            {
                Console.Write(">");
                string userText = Console.ReadLine();

                if(userText.ToLower() == "exit")
                {
                    break;
                }

                // TODO - place logic in MapStrategy instead of World.
                List<string> textList = new List<string>(currentWorld.GetResult(userText));
                foreach (string textLine in textList)
                {
                    Console.WriteLine(textLine);
                    if (textList.Count > 1)
                    {
                        Console.ReadKey();
                    }
                }

            }

            Console.WriteLine("Quitting game.  Thank you for playing!");
            Console.ReadKey();
        }
    }
}
