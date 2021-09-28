using UnityEngine;
using System;

namespace DD.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] Stat[] stats = null;

        public float GetStat(StatType type)
        {
            foreach(Stat stat in stats)
            {
                if(stat.type == type)
                {
                    return stat.value;
                }
            }
            return 0f;
        }

        public void AddStat(StatType type, float addValue)
        {
            foreach(Stat stat in stats)
            {
                if(stat.type == type)
                {
                    stat.value += addValue;
                }
            }
        }
    }

    [System.Serializable]
    public class Stat
    {
        public StatType type;
        public float value;
    }
}
