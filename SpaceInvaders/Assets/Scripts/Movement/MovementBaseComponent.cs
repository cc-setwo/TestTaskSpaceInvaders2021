using SpaceInvaders.Data;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    public abstract class MovementBaseComponent : MonoBehaviour
    {
        protected Vector3 desiredMin { get; private set; }
        protected Vector3 desiredMax { get; private set; }
        
        [SerializeField] protected Transform movementTr;
        [SerializeField] protected Collider2D objCollider;
        
        protected Vector2 direction;
        protected float speed;
        
        private Bounds movementBounds;

        public virtual void Initialize(Bounds allowedBounds, DataMovementBase dataBase)
        {
            speed = dataBase.Speed;
            movementBounds = allowedBounds;
            
            Vector3 currentTrPos = movementTr.position;
            Vector3 currentObjBoundsSize = objCollider.bounds.size;

            desiredMin = new Vector3(movementBounds.min.x - currentObjBoundsSize.x / -2, currentTrPos.y, currentTrPos.z);
            desiredMax = new Vector3(movementBounds.max.x + currentObjBoundsSize.x / -2, currentTrPos.y, currentTrPos.z);
        }

        public virtual void OnMovementUpdate(float timeDelta)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            if (direction == Vector2.right)
            {
               movementTr.position = Vector3.MoveTowards(movementTr.position, desiredMax, timeDelta * speed);
            }
            else if (direction == Vector2.left)
            {
                movementTr.position = Vector3.MoveTowards(movementTr.position, desiredMin, timeDelta * speed);
            }
        }

        protected void UpdateDesiredPositions(Vector3 min, Vector3 max)
        {
            desiredMin = min;
            desiredMax = max;
        }

        private void OnDestroy()
        {
            if (MovementController.IsAvaliable)
            {
                MovementController.Instance.RemoveComponent(this);
            }
        }
    }
}