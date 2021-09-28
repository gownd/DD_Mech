using UnityEngine;

namespace DD.Data
{
    [CreateAssetMenu(fileName = "PriceProgression", menuName = "DD_Mech/PriceProgression", order = 0)]
    public class PriceProgression : ScriptableObject
    {
        public int[] progression;
    }
}
