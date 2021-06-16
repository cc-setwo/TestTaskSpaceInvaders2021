using System;
using UnityEngine;

namespace SpaceInvaders.Data
{
    [Serializable]
    public class DataMovementEnemy : DataMovementBase
    {
        public float SpeedMultiplier => speedMultiplier;
        public float DownShiftValue => downShiftValue;
        public bool IsStartDirectionRight => isStartDirectionRight;
        
        [SerializeField] private float speedMultiplier;
        [SerializeField] private float downShiftValue;
        [SerializeField] private bool isStartDirectionRight;
    }
}