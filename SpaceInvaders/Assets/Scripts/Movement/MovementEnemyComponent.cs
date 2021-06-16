using System;
using SpaceInvaders.Data;
using SpaceInvaders.Utils;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    public class MovementEnemyComponent : MovementBaseComponent
    {
        private Action onMovementDoneCallback;
        private float downShiftValue;
        private float speedMultiplier;
            
        public override void Initialize(Bounds allowedBounds, DataMovementBase dataBase)
        {
            base.Initialize(allowedBounds, dataBase);

            DataMovementEnemy currentData = (DataMovementEnemy) dataBase;

            downShiftValue = currentData.DownShiftValue;
            speedMultiplier = currentData.SpeedMultiplier;
            bool isRight = currentData.IsStartDirectionRight;
            direction = isRight ? Vector2.right : Vector2.left;
        }

        public void SetDesiredPosReachedCallback(Action movementDoneCallback)
        {
            onMovementDoneCallback = movementDoneCallback;
        }

        public override void OnMovementUpdate(float timeDelta)
        {
            base.OnMovementUpdate(timeDelta);
            
            if (movementTr.position.IsGreaterOrEqual(desiredMax))
            {
                onMovementDoneCallback.Invoke();
            }
            else if (movementTr.position.IsLesserOrEqual(desiredMin))
            {
                onMovementDoneCallback.Invoke();
            }
        }

        public void UpdateDirection()
        {
            MoveDown();

            if (direction == Vector2.left)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }
        }

        private void MoveDown()
        {
            speedMultiplier *= speedMultiplier;
            Vector3 newPosition = new Vector3(movementTr.position.x, movementTr.position.y - downShiftValue, movementTr.position.z);
            Vector3 newDesiredMin = new Vector3(desiredMin.x, newPosition.y, newPosition.z);
            Vector3 newDesiredMax = new Vector3(desiredMax.x, newPosition.y, newPosition.z);
                
            UpdateDesiredPositions(newDesiredMin, newDesiredMax);
            movementTr.position = newPosition;
        }
    }
}