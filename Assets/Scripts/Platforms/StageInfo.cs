using UnityEngine;

namespace DD.Platforms
{
    [CreateAssetMenu(fileName = "StageInfo", menuName = "DD_Mech/StageInfo", order = 0)]
    public class StageInfo : ScriptableObject
    {
        [SerializeField] PlatformType[] stageStructure = null;
        [SerializeField] Platform defaultPlatform = null;
        [SerializeField] Platform[] trapPlatforms = null;
        [SerializeField] Platform bossPlatform = null;

        public Platform GetCurrentPlatform(int i)
        {
            Platform platformToInstantiate = GetDefaultPlatform();

            if(stageStructure[i] == PlatformType.Trap) platformToInstantiate = GetTrapPlatform();
            else if(stageStructure[i] == PlatformType.Boss) platformToInstantiate = GetBossPlatform();
        
            return platformToInstantiate;
        }

        public Platform GetDefaultPlatform()
        {
            return defaultPlatform;
        }

        public Platform GetTrapPlatform()
        {
            return trapPlatforms[Random.Range(0, trapPlatforms.Length)];
        }

        public Platform GetBossPlatform()
        {
            return bossPlatform;
        }

        public int GetStageLength()
        {
            return stageStructure.Length;
        }
    }
}
