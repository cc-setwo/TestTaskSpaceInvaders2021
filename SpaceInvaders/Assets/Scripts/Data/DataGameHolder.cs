using System;
using System.Collections.Generic;
using SpaceInvaders.Movement;
using SpaceInvaders.Shooting;
using SpaceInvaders.Utils;
using UnityEngine;

namespace SpaceInvaders.Data
{
    public class DataGameHolder : Singleton<DataGameHolder>, IInitializable
    {
        public bool IsInitialized { get; set; }
        
        [SerializeField] private DataGame dataGame;
        
        private Dictionary<Type, object> dataDictionary;

        public void Initialize()
        {
            dataDictionary = new Dictionary<Type, object>
            {
                {
                    typeof(MovementPlayerComponent), dataGame.PlayerMovement
                },
                {
                    typeof(MovementEnemyComponent), dataGame.EnemyMovement
                },
                {
                    typeof(MovementProjectileComponent), dataGame.ProjectileMovement
                },
                {
                    typeof(ShootingEnemyComponent), dataGame.EnemyShooting
                },
                {
                    typeof(ShootingPlayerComponent), dataGame.PlayerShooting
                }
            };

            IsInitialized = true;
        }

        public T GetData<T>(Type t)
        {
            foreach (var item in dataDictionary)
            {
                if (item.Key == t)
                {
                    return (T) item.Value;
                }
            }
            
            Debug.LogError($"DataGameHolder -> GetData couldn't find value for type {t}");
            return default;
        }
    }
}