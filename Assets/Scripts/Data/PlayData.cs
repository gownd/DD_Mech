using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Data
{
    public class PlayData : MonoBehaviour
    {
        int coin = 0;
        bool hasStartedBossFight = false;
        bool isFightingBoss = false;

        public int GetCurrentCoin()
        {
            return coin;
        }

        public void GainCoin(int gain)
        {
            coin += gain;
        }

        public void UseCoin(int use)
        {
            coin -= use;
        }

        public bool CanUse(int use)
        {
            return coin >= use;
        }

        public bool HasStartedBossFight()
        {
            return hasStartedBossFight;
        }

        public void StartBossFight()
        {
            hasStartedBossFight = true;
        }

        public void ArrvivedAtBoss()
        {
            isFightingBoss = true;
        }

        public void EndBossFight()
        {
            isFightingBoss = false;
        }

        public bool IsFightingBoss()
        {
            return isFightingBoss;
        }
    }
}
