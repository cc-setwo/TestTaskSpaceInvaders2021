using System.Collections;
using SpaceInvaders.Data;
using SpaceInvaders.Movement;
using UnityEngine;

namespace SpaceInvaders.Shooting
{
    public class ShootingEnemyComponent : ShootingBaseComponent
    {
        protected override void OnProjectileHit(GameObject data, ShootingProjectile projectile)
        {
            MovementPlayerComponent playerComponent = data.GetComponent<MovementPlayerComponent>();

            if (playerComponent != null)
            {
                currentCallback.Invoke(playerComponent);
                projectile.gameObject.SetActive(false);
            }
        }

        protected override void Start()
        {
            base.Start();

            DataShootingEnemy enemyShootingData = (DataShootingEnemy) currentData;
            StartCoroutine(WaitAndShoot(enemyShootingData.EnemyShootCooldown));
        }

        private IEnumerator WaitAndShoot(float time)
        {
            yield return new WaitForSeconds(time);
            
            Shoot(-transform.forward);
            StartCoroutine(WaitAndShoot(time));
        }
    }
}