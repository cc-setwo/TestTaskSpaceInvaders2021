using System;
using SpaceInvaders.Movement;
using SpaceInvaders.Shooting;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class EnemyComponent : MonoBehaviour
    {
        public MovementEnemyComponent EnemyMoveComponent => enemyMoveComponent;
        
        [SerializeField] private MovementEnemyComponent enemyMoveComponent;
        [SerializeField] private ShootingEnemyComponent enemyShootComponent;

        public void Initialize(Action<MovementBaseComponent> onUserHit, Action onDesiredPosReached)
        {
            if (enemyShootComponent != null)
            {
                enemyShootComponent.Initialize(onUserHit);
            }

            MovementController.Instance.AddComponent(enemyMoveComponent);
            enemyMoveComponent.SetDesiredPosReachedCallback(onDesiredPosReached);
        }

        public void ChangeDirection()
        {
            enemyMoveComponent.UpdateDirection();
        }
    }
}