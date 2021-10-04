using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
using DD.UI;
using DD.Entities;
using DD.Data;
using DD.FX;
using DD.Inventory;
using DD.Shop;

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
        [SerializeField] Entity jumpPad = null;
        

        LauncherController launcherController;
        PlayData playData;
        InventoryHandler inventoryHandler;
        ShopHandler shopHandler;
        PotionHandler potionHandler;
        

        private void Awake()
        {
            launcherController = FindObjectOfType<LauncherController>();
            playData = FindObjectOfType<PlayData>();
            inventoryHandler = FindObjectOfType<InventoryHandler>();
            shopHandler = FindObjectOfType<ShopHandler>();
            potionHandler = FindObjectOfType<PotionHandler>();
        }

        public void LaunchEnemy()
        {
            LaunchEntity(skeleton, 0);
        }

        public void LaunchJumpPad()
        {
            LaunchEntity(jumpPad, 0);
        }


        public void LaunchPotion()
        {
            LaunchEntity(potion, potionHandler.GetCost());
        }

        public void LaunchInventoryItem(int i)
        {
            Entity entityToLaunch = inventoryHandler.GetInventory()[i];
            inventoryHandler.DeleteItem(i);

            LaunchEntity(entityToLaunch, 0);
        }

        public void LaunchShopItem(int i)
        {
            Entity entityToLaunch = shopHandler.GetShopItems()[i];
            
            if(LaunchEntity(entityToLaunch, shopHandler.GetCosts()[i])) shopHandler.IncreasePrice(i); 
        }

        public bool LaunchEntity(Entity entityToLaunch, int cost)
        {
            if(playData.CanUse(cost))
            {
                playData.UseCoin(cost);
                Launch(entityToLaunch.gameObject);
                return true;
            }
            else return false;
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
