using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Platforms
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] Platform platformToGenerate = null;
        [SerializeField] Platform currentPlatform;
        [SerializeField] float generationXOffset = 30f;

        Platform pastPlatform;

        Transform heroTransform;
        Vector2 generationPoint;
        Vector2 destroyPoint;

        private void Awake()
        {
            heroTransform = GameObject.FindWithTag("Hero").transform;
        }

        void Update()
        {
            UpdatePoints();
            GenerateNewPlatform();
            DestroyPastPlatform();
        }

        private void DestroyPastPlatform()
        {
            if (pastPlatform == null) return;
            if (destroyPoint.x > pastPlatform.GetEndPos().position.x)
            {
                Destroy(pastPlatform.gameObject);
            }
        }

        private void GenerateNewPlatform()
        {
            if (generationPoint.x > currentPlatform.GetEndPos().position.x)
            {
                Platform newPlatform = Instantiate(platformToGenerate, currentPlatform.GetEndPos().position, Quaternion.identity, transform);
                pastPlatform = currentPlatform;
                currentPlatform = newPlatform;
            }
        }

        private void UpdatePoints()
        {
            if (heroTransform == null) return;

            generationPoint = new Vector2(heroTransform.transform.position.x + generationXOffset, 0f);
            destroyPoint = new Vector2(heroTransform.transform.position.x - generationXOffset, 0f);
        }
    }

}
