using System;
using System.Text;
using TextAdventureRpgLibrary;

namespace TextAdventureRpgMvcWebApplication.Models
{
    public class HomeModel
    {
        public World CurrentWorld { get; set; }
        public StringBuilder ConsoleOutput { get; set; }
        public string UserInput { get; set; }
    }
}
