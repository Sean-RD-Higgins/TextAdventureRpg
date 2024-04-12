namespace TextAdventureRpgLibrary
{
    public class MapAction
    {
        private MapAction(string value) { Value = value.ToLower(); }

        public string Value { get; private set; }
    
        public static MapAction GoNorth { get { return new MapAction("North"); } }
        public static MapAction GoEast { get { return new MapAction("East"); } }
        public static MapAction GoSouth { get { return new MapAction("South"); } }
        public static MapAction GoWest { get { return new MapAction("West"); } }
        public static MapAction Look { get { return new MapAction("Look"); } }
        public static MapAction Mirror { get { return new MapAction("Mirror"); } }
    }
}