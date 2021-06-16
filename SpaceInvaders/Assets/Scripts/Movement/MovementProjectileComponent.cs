namespace SpaceInvaders.Movement
{
    public class MovementProjectileComponent : MovementBaseComponent
    {
        public override void OnMovementUpdate(float timeDelta)
        {
            movementTr.position += movementTr.up * (timeDelta * speed);
        }
    }
}