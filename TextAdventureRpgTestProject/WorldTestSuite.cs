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
            _world.GetLookText(string.Empty, _world);
            _world.GoEast(string.Empty, _world);
            _world.GoNorth(string.Empty, _world);
            _world.GoSouth(string.Empty, _world);
            _world.GoWest(string.Empty, _world);
        }
    }
}