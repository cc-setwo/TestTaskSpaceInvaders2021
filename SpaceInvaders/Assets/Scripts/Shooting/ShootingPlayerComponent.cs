using System;
using SpaceInvaders.Movement;
using UnityEngine;

namespace SpaceInvaders.Shooting
{
    public class ShootingPlayerComponent : ShootingBaseComponent
    {
        public override void Initialize(Action<MovementBaseComponent> hitCallback)
        {
            base.Initialize(hitCallback);
            
            Clear();
        }

        protected override void OnProjectileHit(GameObject data, ShootingProjectile projectile)
        {
            MovementEnemyComponent enemyComponent = data.GetComponent<MovementEnemyComponent>();

            if (enemyComponent != null)
            {
                currentCallback.Invoke(enemyComponent);
                projectile.gameObject.SetActive(false);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(transform.forward);
            }
        }
    }
}