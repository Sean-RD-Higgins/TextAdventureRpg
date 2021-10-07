using NUnit.Framework;
using TextAdventureRpgLibrary;

namespace TextAdventureRpgTestProject
{
    public class WorldTestSuite
    {
        private World _world;

        [SetUp]
        public void Setup()
        {
            _world = new World();
        }

        [Test]
        public void CallAllDialogTest()
        {
            _world.DisplayActionList();
            _world.GetArrivalText();
            _world.GetHelpText();
            _world.GetLookText();
            _world.GoEast();
            _world.GoNorth();
            _world.GoSouth();
            _world.GoWest();
        }
    }
}