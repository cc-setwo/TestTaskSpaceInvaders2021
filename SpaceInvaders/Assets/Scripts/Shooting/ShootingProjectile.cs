using System;
using SpaceInvaders.Movement;
using UnityEngine;

namespace SpaceInvaders.Shooting
{
    public class ShootingProjectile : MonoBehaviour
    {
        public MovementProjectileComponent MovementComponent => movementComponent;
        
        [SerializeField] private MovementProjectileComponent movementComponent;

        private Action<GameObject, ShootingProjectile> currentHitCallback;

        public void Initialize(Action<GameObject, ShootingProjectile> hitCallback)
        {
            currentHitCallback = hitCallback;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            currentHitCallback.Invoke(other.gameObject, this);
        }
    }
}