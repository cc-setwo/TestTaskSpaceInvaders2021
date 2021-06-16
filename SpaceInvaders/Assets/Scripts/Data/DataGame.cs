using UnityEngine;

namespace SpaceInvaders.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 0)]
    public class DataGame : ScriptableObject
    {
        public DataMovementBase PlayerMovement => playerMovement;
        public DataMovementEnemy EnemyMovement => enemyMovement;
        public DataMovementBase ProjectileMovement => projectileMovement;
        public DataShootingBase PlayerShooting => playerShooting;
        public DataShootingEnemy EnemyShooting => enemyShooting;
        
        [SerializeField] private DataMovementBase playerMovement;
        [SerializeField] private DataMovementEnemy enemyMovement;
        [SerializeField] private DataMovementBase projectileMovement;
        [SerializeField] private DataShootingBase playerShooting;
        [SerializeField] private DataShootingEnemy enemyShooting;
    }
}