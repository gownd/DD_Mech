using UnityEngine;
using DD.Stats;

public class TreasureBox : MonoBehaviour 
{
    // proto용 야매로 작성된 코드

    [Header("Components")]
    [SerializeField] GameObject box = null;
    [SerializeField] GameObject treasure = null;

    [Header("Item Info")]
    [SerializeField] Sprite treasureSprite = null;
    [SerializeField] StatType statTypeToAdd;
    [SerializeField] float addAmount;

    bool canOpen = true;

    private void Start() 
    {
        box.SetActive(true);
        treasure.SetActive(false);    
    }

    public void OpenTreasure(BaseStats stats)
    {
        canOpen = false;

        box.SetActive(false);
        treasure.SetActive(true);

        stats.AddStat(statTypeToAdd, addAmount);

        Destroy(gameObject, 0.5f);
    }

    public bool CanOpen()
    {
        return canOpen;
    }
}