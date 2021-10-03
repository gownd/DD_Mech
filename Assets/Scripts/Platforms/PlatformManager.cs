using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Combat;
using DD.Data;

namespace DD.Platforms
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] Platform defaultPlatform = null;
        [SerializeField] Platform bossPlatform = null;


        [Header("Move Speed")]
        [SerializeField] float normalMoveSpeed = 150f;
        [SerializeField] float feverMoveSpeed = 250f;

        [Header("Generate")]
        [SerializeField] List<Platform> platforms;
        [SerializeField] int platformCount = 10;
        [SerializeField] Platform initialPlatform;

        Platform endPlatform;
        Platform pastPlatform;
        float generationXOffset = 10f;

        Transform heroTransform;
        Vector2 generationPoint;
        Vector2 destroyPoint;

        Fever fever;
        bool isMoving = true;

        PlayData playData;

        private void Awake()
        {
            heroTransform = GameObject.FindWithTag("Hero").transform;
            fever = heroTransform.GetComponent<Fever>();
            playData = FindObjectOfType<PlayData>();

            GenerateStage();
        }

        private void Start()
        {
            StartMove();
        }

        void Update()
        {
            HandleInfinitePlatform();
            UpdateMoveSpeed(fever.IsFever(), isMoving);
        }

        void GenerateStage()
        {
            platforms = new List<Platform>();
            platforms.Add(initialPlatform);

            endPlatform = initialPlatform;
            
            for (int i = 0; i < platformCount; i++)
            {
                Platform platformToGenerate;

                if (i == platformCount - 1)
                {
                    platformToGenerate = bossPlatform;
                }
                else platformToGenerate = defaultPlatform;

                Platform newPlatform = Instantiate(platformToGenerate, endPlatform.GetEndPos().position, Quaternion.identity, transform);
                platforms.Add(newPlatform);
                endPlatform = newPlatform;
            }
        }

        public void UpdateMoveSpeed(bool isFever, bool isMoving)
        {
            float moveSpeed;

            if (!isMoving) moveSpeed = 0f;
            else if ((bool)isFever) moveSpeed = feverMoveSpeed;
            else moveSpeed = normalMoveSpeed;

            if (!playData.HasStartedBossFight())
            {
                foreach (Platform platform in platforms)
                {
                    platform.GetComponent<PlatformMover>().SetSpeedFever(moveSpeed);
                }
            }
            else
            {
                if (pastPlatform != null) pastPlatform.GetComponent<PlatformMover>().SetSpeedFever(moveSpeed);
                endPlatform.GetComponent<PlatformMover>().SetSpeedFever(moveSpeed);
            }
        }

        public void StopMove()
        {
            isMoving = false;
            heroTransform.GetComponent<Animator>().SetFloat("Moving", 0f);
        }

        public void StartMove()
        {
            isMoving = true;
            heroTransform.GetComponent<Animator>().SetFloat("Moving", 1f);
        }

        void HandleInfinitePlatform()
        {
            UpdatePoints();
            GenerateNewPlatform();
            DestroyPastPlatform();
        }

        private void GenerateNewPlatform()
        {
            if (generationPoint.x > endPlatform.GetEndPos().position.x)
            {
                Platform newPlatform = Instantiate(defaultPlatform, endPlatform.GetEndPos().position, Quaternion.identity, transform);
                pastPlatform = endPlatform;
                endPlatform = newPlatform;

                playData.StartBossFight();
            }
        }

        private void UpdatePoints()
        {
            if (heroTransform == null) return;

            generationPoint = new Vector2(heroTransform.transform.position.x + generationXOffset, 0f);
            destroyPoint = new Vector2(heroTransform.transform.position.x - generationXOffset, 0f);
        }

        private void DestroyPastPlatform()
        {
            if (pastPlatform == null) return;
            if (destroyPoint.x > pastPlatform.GetEndPos().position.x)
            {
                Destroy(pastPlatform.gameObject);
            }
        }

        void DeactivateStagePlatforms()
        {
            for (int i = 0; i < platforms.Count - 1; i++)
            {
                platforms[i].gameObject.SetActive(false);
            }
        }
    }

}
