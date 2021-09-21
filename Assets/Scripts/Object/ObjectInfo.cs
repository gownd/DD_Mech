using UnityEngine;

[CreateAssetMenu(fileName = "ObjectInfo", menuName = "DD_Mech/ObjectInfo", order = 0)]
public class ObjectInfo : ScriptableObject 
{
    public ObjectType type;
    public string objName;
    public Sprite repSprite;
    public int cost;
}