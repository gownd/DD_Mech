using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Combat;

namespace DD.Platforms
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] Platform platformToGenerate = null;
        [SerializeField] Platform currentPlatform;
        [SerializeField] float generationXOffset = 30f;

        [Header("Move Speed")]
        [SerializeField] float normalMoveSpeed = 150f;
        [SerializeField] float feverMoveSpeed = 250f;

        Platform pastPlatform;

        Transform heroTransform;
        Vector2 generationPoint;
        Vector2 destroyPoint;

        Fever fever;

        private void Awake()
        {
            heroTransform = GameObject.FindWithTag("Hero").transform;
            fever = heroTransform.GetComponent<Fever>();
        }

        void Update()
        {
            UpdatePoints();
            GenerateNewPlatform();
            DestroyPastPlatform();
            UpdateMoveSpeed(fever.IsFever());
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
            if(heroTransform == null) return;

            generationPoint = new Vector2(heroTransform.transform.position.x + generationXOffset, 0f);
            destroyPoint = new Vector2(heroTransform.transform.position.x - generationXOffset, 0f);
        }

        public void UpdateMoveSpeed(bool? isFever)
        {
            float moveSpeed;

            if(fever == null) moveSpeed = 0f;
            else if((bool)isFever) moveSpeed = feverMoveSpeed;
            else moveSpeed = normalMoveSpeed;

            if(pastPlatform != null) pastPlatform.GetComponent<PlatformMover>().SetSpeedFever(moveSpeed);
            currentPlatform.GetComponent<PlatformMover>().SetSpeedFever(moveSpeed);
        }
    }

}
