using System;
using UnityEngine;

namespace SpaceInvaders.Data
{
    [Serializable]
    public class DataShootingEnemy : DataShootingBase
    {
        public float EnemyShootCooldown => enemyShootCooldown;
        
        [SerializeField] private float enemyShootCooldown;
    }
}