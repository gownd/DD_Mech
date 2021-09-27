using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
using DD.UI;
using DD.Entities;
using DD.Data;
using DD.FX;

namespace DD.Core
{
    public class EntityLauncher : MonoBehaviour
    {
        [Header("Component")]
        [SerializeField] Transform spawnPos = null;
        [SerializeField] ParticleSystem spawnVFX = null;

        [Header("Config")]
        [SerializeField] Vector2 throwForce;
        [SerializeField] Vector2 AddForce;

        [Header("Default Entity")]
        [SerializeField] Entity skeleton = null;
        [SerializeField] Entity potion = null;
        

        LauncherController launcherController;
        PlayData playData;

        private void Awake()
        {
            launcherController = FindObjectOfType<LauncherController>();
            playData = FindObjectOfType<PlayData>();
        }

        public void LaunchEnemy()
        {
            LaunchEntity(skeleton);
        }


        public void LaunchPotion()
        {
            LaunchEntity(potion);
        }

        public void LaunchEntity(Entity entityToLaunch)
        {
            print("A");

            if(playData.CanUse(entityToLaunch.info.cost))
            {
                playData.UseCoin(entityToLaunch.info.cost);
                Launch(entityToLaunch.gameObject);
                print("B");
            }
        }

        void Launch(GameObject objToSpawn)
        {
            FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.MediumImpact);
            GameObject newObj = Instantiate(objToSpawn, spawnPos.position, Quaternion.identity);
            newObj.GetComponent<Rigidbody2D>().AddForce(throwForce + AddForce * launcherController.GetPosValue());
            spawnVFX.Play();
        }
    }

}
