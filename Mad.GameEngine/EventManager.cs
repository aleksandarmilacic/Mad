
namespace Mad.GameEngine
{
    public class EventManager
    {
        private Dictionary<string, Action> events;

        public EventManager()
        {
            events = new Dictionary<string, Action>();
        }

        public void Register(string eventName, Action callback)
        {
            events[eventName] = callback;
        }

        public void Trigger(string eventName)
        {
            if (events.ContainsKey(eventName))
            {
                events[eventName]();
            }
        }
    }
}
