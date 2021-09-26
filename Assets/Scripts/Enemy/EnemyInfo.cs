using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "DD_Mech/EnemyInfo", order = 0)]
public class EnemyInfo : ScriptableObject 
{
    public int damage;
    public int dropCoin;       
}