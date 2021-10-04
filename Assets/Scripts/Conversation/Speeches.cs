using UnityEngine;

namespace DD.Conversation
{
    [CreateAssetMenu(fileName = "Speeches", menuName = "DD_Mech/Speeches", order = 0)]
    public class Speeches : ScriptableObject
    {
        public Speech[] speeches = null;
    }

    [System.Serializable]
    public class Speech
    {
        public bool isHero = false;
        [TextArea]
        public string message;
        public float timeToShow;
    }
}
