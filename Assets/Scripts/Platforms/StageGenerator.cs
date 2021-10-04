using UnityEngine;
using System.Collections.Generic;

namespace DD.Platforms
{
    public class StageGenerator : MonoBehaviour
    {
        [SerializeField] StageInfo stageInfo = null;
        [SerializeField] List<Platform> platforms;
        [SerializeField] Platform initialPlatform;

        Platform endPlatform;

        public void GenerateStage()
        {
            platforms = new List<Platform>();
            platforms.Add(initialPlatform);

            endPlatform = initialPlatform;

            for (int i = 0; i < stageInfo.GetStageLength(); i++)
            {
                Platform platformToGenerate;

                platformToGenerate = stageInfo.GetCurrentPlatform(i);

                Platform newPlatform = Instantiate(platformToGenerate, endPlatform.GetEndPos().position, Quaternion.identity, transform);
                platforms.Add(newPlatform);
                endPlatform = newPlatform;
            }
        }

        public List<Platform> GetPlatforms()
        {
            return platforms;
        }

        public Platform GetEndPlatform()
        {
            return endPlatform;
        }
    }
}
