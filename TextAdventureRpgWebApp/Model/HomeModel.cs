using System;
using System.Configuration;
using System.Text;
using TextAdventureRpgLibrary;

namespace TextAdventureRpgWebApp.Models
{
    [Serializable]
    public class HomeModel
    {
        public World CurrentWorld { get; set; }
        public StringBuilder ConsoleOutput { get; set; }
        public string UserInput { get; set; }
    }
}
