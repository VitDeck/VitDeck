using UnityEngine;

namespace VitDeck.Validator
{
    public interface ICustomComponentIgnorer
    {
        bool IsIgnored(Component component);
    }

    public class DummyComponentIgnorer : ICustomComponentIgnorer
    {
        public bool IsIgnored(Component component)
        {
            return false;
        }
    }

}
