using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
using DD.UI;
using DD.Entities;
using DD.Data;
using DD.FX;
using DD.Inventory;

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
        InventoryHandler inventoryHandler;

        private void Awake()
        {
            launcherController = FindObjectOfType<LauncherController>();
            playData = FindObjectOfType<PlayData>();
            inventoryHandler = FindObjectOfType<InventoryHandler>();
        }

        public void LaunchEnemy()
        {
            LaunchEntity(skeleton);
        }


        public void LaunchPotion()
        {
            LaunchEntity(potion);
        }

        public void LaunchInventoryItem(int i)
        {
            Entity entityToLaunch = inventoryHandler.GetInventory()[i];
            inventoryHandler.DeleteItem(i);

            LaunchEntity(entityToLaunch);
        }

        public void LaunchEntity(Entity entityToLaunch)
        {
            if(playData.CanUse(entityToLaunch.info.cost))
            {
                playData.UseCoin(entityToLaunch.info.cost);
                Launch(entityToLaunch.gameObject);
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
