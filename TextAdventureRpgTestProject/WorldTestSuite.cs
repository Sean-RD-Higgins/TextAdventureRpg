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
            
            _world.GetLookText( new string[] {  string.Empty } , _world);
            _world.GoEast(new string[] { string.Empty }, _world);
            _world.GoNorth(new string[] { string.Empty }, _world);
            _world.GoSouth(new string[] { string.Empty }, _world);
            _world.GoWest(new string[] { string.Empty }, _world);
            
        }
    }
}