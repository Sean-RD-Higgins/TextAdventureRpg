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

            MapTile[,] tileMatrix = new MapTile[3, 3];
            tileMatrix[0, 0] =
                new MapTile(new string[]{ "You arrive at a bunch of mountains.",
                    "They seem to stretch on for miles to the north and west.",
                    "There's no going back now." },
                new string[] { "The mountains are really tall.",
                    "Tall things definitely make you nervous."});
            tileMatrix[0, 1] = new MapTile("You are traversing a grassy field.", 
                "The grassy field has lots of flowers.");
            tileMatrix[0, 2] = 
                new MapTile(new string[] { "You are treading across a pond." }, 
                new string[] { "The pond has no fish in it." , 
                    "Kinda a shame.  You could go for some fish."});
            tileMatrix[1, 0] = new MapTile("You are knee deep in a marsh.", 
                "There are far too many bugs here.");
            tileMatrix[1, 1] = new MapTile("You are trekking across a barren desert.", 
                "It is really dry in the desert.");
            tileMatrix[1, 2] = new MapTile("You are moving through a tundra.", 
                "You're a bit concerned that a tundra can be next to a desert.");
            tileMatrix[2, 0] = new MapTile("You bump into a castle.", 
                "You see a tall foreboding fortress of a structure that towers over you.  The double doors are meant for a giant.  Which means you can't reach the doornobs.");
            tileMatrix[2, 1] = new MapTile("You fall into a ravine.", 
                "It is pretty dark down here.  You're going to have a really bad time climbing out.");
            tileMatrix[2, 2] = new MapTile("You are floating in outer space.", 
                "You luckily don't know there's no oxygen here and breathe just fine.");

            Player playerOne = new Player();
            World currentWorld = new World(tileMatrix, playerOne);

            Console.WriteLine("Press any key to advance text.  Enter any of the following actions if the > icon appears.");
            foreach (string helpText in currentWorld.GetHelpText()) { Console.WriteLine(helpText); }

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

                string[] textList = (string[])currentWorld.GetResult(userText);
                foreach (string textLine in textList)
                {
                    Console.WriteLine(textLine);
                    if (textList.Length > 1)
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
