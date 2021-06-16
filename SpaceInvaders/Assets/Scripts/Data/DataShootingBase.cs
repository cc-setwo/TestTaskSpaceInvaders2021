using System;
using SpaceInvaders.Shooting;
using UnityEngine;

namespace SpaceInvaders.Data
{
    [Serializable]
    public class DataShootingBase
    {
        public ShootingProjectile ProjectilePrefab => projectilePrefab;
        public float TimeToDestroy => timeToDestroy;

        [SerializeField] private ShootingProjectile projectilePrefab;
        [SerializeField] private float timeToDestroy;
    }
}