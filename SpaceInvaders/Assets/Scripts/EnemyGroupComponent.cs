using System;
using System.Collections.Generic;
using SpaceInvaders.Movement;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class EnemyGroupComponent : MonoBehaviour
    {
        public int EnemiesLeft => enemyComponents.Count;
        
        [SerializeField] private List<EnemyComponent> enemyComponents;

        public void Initialize(Action<MovementBaseComponent> onUserHit)
        {
            for (int i = 0; i < enemyComponents.Count; i++)
            {
                enemyComponents[i].Initialize(onUserHit, OnEnemyReachedDesiredPos);
            }
        }

        public void OnEnemyHit(MovementBaseComponent hitEnemy)
        {
            for (int i = 0; i < enemyComponents.Count; i++)
            {
                if (enemyComponents[i].EnemyMoveComponent == hitEnemy)
                {
                    Destroy(hitEnemy.gameObject);
                    enemyComponents.RemoveAt(i);
                    break;
                }
            }
        }

        private void OnEnemyReachedDesiredPos()
        {
            for (int i = 0; i < enemyComponents.Count; i++)
            {
                enemyComponents[i].ChangeDirection();
            }
        }
    }
}