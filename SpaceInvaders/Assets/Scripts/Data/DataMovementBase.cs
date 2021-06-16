using System;
using UnityEngine;

namespace SpaceInvaders.Data
{
    [Serializable]
    public class DataMovementBase
    {
        public float Speed => speed;
        
        [SerializeField] private float speed;
    }
}