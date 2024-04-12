using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureRpgLibrary
{
    [Serializable]
    public class ActionCollection
    {
        public ActionCollection()
        {
            _actionToFunctionMap = new Dictionary<string, Func<IEnumerable<string>, World, IEnumerable<string>>>();
        }

        private readonly Dictionary<string, Func<IEnumerable<string>, World, IEnumerable<string>>> _actionToFunctionMap;

        public string[] GetActionList()
        { 
            return _actionToFunctionMap.Select(pair => pair.Key).ToArray();
        }   

        public void Add(string actionText, Func<IEnumerable<string>, World, IEnumerable<string>> actionFunction)
        {
            _actionToFunctionMap.Add(CleanseKey(actionText), actionFunction);
        }

        public Func<IEnumerable<string>, World, IEnumerable<string>> GetActionFunction(string actionText)
        {
            if (_actionToFunctionMap.ContainsKey(CleanseKey(actionText)))
            {
                return _actionToFunctionMap[CleanseKey(actionText)];
            }
            return null;
        }

        private string CleanseKey(string key)
        {
            return key.ToLower().Replace(" ", string.Empty);
        }
    }
}
