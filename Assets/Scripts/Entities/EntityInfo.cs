using UnityEngine;

namespace DD.Entities
{
    [CreateAssetMenu(fileName = "EntityInfo", menuName = "DD_Mech/Entity/Info", order = 0)]
    public class EntityInfo : ScriptableObject
    {
        public EntityType type;
        public string objName;
        public Sprite repSprite;
    }
}
