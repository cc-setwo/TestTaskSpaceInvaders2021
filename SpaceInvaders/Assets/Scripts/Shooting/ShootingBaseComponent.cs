using System;
using System.Collections;
using System.Collections.Generic;
using SpaceInvaders.Data;
using SpaceInvaders.Movement;
using SpaceInvaders.Utils;
using UnityEngine;

namespace SpaceInvaders.Shooting
{
    public abstract class ShootingBaseComponent : MonoBehaviour
    {
        public bool IsInitialized { get; set; }

        protected Action<MovementBaseComponent> currentCallback;
        protected DataShootingBase currentData;
        
        private List<ShootingProjectile> spawnedProjectTiles;
        private Pool<ShootingProjectile> projectilesPool;

        public virtual void Initialize(Action<MovementBaseComponent> hitCallback)
        {
            currentCallback = hitCallback;
        }

        protected void Shoot(Vector3 direction)
        {
            ShootingProjectile projectile = projectilesPool.Get();
            projectile.Initialize(OnProjectileHit);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.LookRotation(direction, Vector3.back);
            spawnedProjectTiles.Add(projectile);
            MovementController.Instance.AddComponent(projectile.MovementComponent);
            
            StartCoroutine(WaitAndReturnToPool(projectile, currentData.TimeToDestroy));
        }

        protected abstract void OnProjectileHit(GameObject data, ShootingProjectile projectile);

        protected virtual void Start()
        {
            currentData = DataGameHolder.Instance.GetData<DataShootingBase>(GetType());
            projectilesPool = new Pool<ShootingProjectile>(currentData.ProjectilePrefab, 10);
            spawnedProjectTiles = new List<ShootingProjectile>();

            IsInitialized = true;
        }

        protected void Clear()
        {
            StopAllCoroutines();

            if (spawnedProjectTiles != null)
            {
                for (int i = 0; i < spawnedProjectTiles.Count; i++)
                {
                    projectilesPool.Return(spawnedProjectTiles[i]);
                }
            }
        }

        private IEnumerator WaitAndReturnToPool(ShootingProjectile projectile, float timeToWait)
        {
            yield return new WaitForSeconds(timeToWait);
            
            spawnedProjectTiles.Remove(projectile);
            projectilesPool.Return(projectile);
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}