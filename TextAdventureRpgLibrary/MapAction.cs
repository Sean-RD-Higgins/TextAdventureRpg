namespace TextAdventureRpgLibrary
{
    public class MapAction
    {
        private MapAction(string value) { Value = value.ToLower(); }

        public string Value { get; private set; }
    
        public static MapAction GoNorth { get { return new MapAction("Go North"); } }
        public static MapAction GoEast { get { return new MapAction("Go East"); } }
        public static MapAction GoSouth { get { return new MapAction("Go South"); } }
        public static MapAction GoWest { get { return new MapAction("Go West"); } }
        public static MapAction Look { get { return new MapAction("Look"); } }
    }
}