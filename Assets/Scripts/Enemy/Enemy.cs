using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public EnemyInfo info = null;

    private void Awake() 
    {
        GetComponent<Health>().onDie += GainCoin;
    }

    void GainCoin()
    {
        FindObjectOfType<PlayData>().GainCoin(info.dropCoin);
    }
}