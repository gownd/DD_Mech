using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] Transform endPos;

        public Transform GetEndPos()
        {
            return endPos;
        }
    }

}
