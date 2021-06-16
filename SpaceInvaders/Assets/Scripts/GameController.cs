using SpaceInvaders.Movement;
using SpaceInvaders.Shooting;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private EnemyGroupComponent enemyGroupPrefab;
        [SerializeField] private ShootingPlayerComponent player;
        [SerializeField] private MovementPlayerComponent playerComponent;
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject looseRoot;
        [SerializeField] private GameObject winRoot;

        private EnemyGroupComponent enemyGroup;
        
        public void StartGame()
        {
            canvas.SetActive(false);
            enemyGroup = Instantiate(enemyGroupPrefab);
            Time.timeScale = 1.0f;
            enemyGroup.Initialize(OnUserHit);
            player.Initialize(OnEnemyHit);
            MovementController.Instance.AddComponent(playerComponent);
        }

        private void StopGame()
        {
            Destroy(enemyGroup.gameObject);
            Time.timeScale = 0.0f;
        }

        private void Start()
        {
            Time.timeScale = 0.0f;
        }

        private void OnUserHit(MovementBaseComponent hitPlayer)
        {
            StopGame();
            canvas.SetActive(true);
            winRoot.SetActive(false);
            looseRoot.SetActive(true);
        }

        private void OnEnemyHit(MovementBaseComponent enemy)
        {
            enemyGroup.OnEnemyHit(enemy);

            if (enemyGroup.EnemiesLeft == 0)
            {
                StopGame();
                canvas.SetActive(true);
                winRoot.SetActive(true);
                looseRoot.SetActive(false);
            }
        }
    }
}