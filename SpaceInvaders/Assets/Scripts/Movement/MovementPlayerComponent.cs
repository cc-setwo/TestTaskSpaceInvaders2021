using SpaceInvaders.Data;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    public class MovementPlayerComponent : MovementBaseComponent
    {
        public override void OnMovementUpdate(float timeDelta)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }
            
            base.OnMovementUpdate(timeDelta);
            
            direction = Vector2.zero;
        }

        public override void Initialize(Bounds allowedBounds, DataMovementBase dataBase)
        {
            movementTr.position = new Vector3(0, allowedBounds.min.y + objCollider.bounds.size.y / 2, 0);
            base.Initialize(allowedBounds, dataBase);
        }
    }
}