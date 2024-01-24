using System.Collections;
using Assets.Sources.Enemies;
using UnityEngine;

namespace Assets.Sources.Spawn
{
    public class Spawner : MonoBehaviour
    {
        #region Fields

        [SerializeField, Range(1, 5)] private float _spawnInterval = 2;
        [SerializeField] private EnemyMovement _enemyPrefab;
        [SerializeField] private Transform _target;

        private bool _isSpawning;
        private Coroutine spawnCoroutine;

        #endregion Fields

        #region Unity Events

        private void Awake()
        {
        }

        private void OnEnable()
        {
            EnableSpawning();
        }

        private void OnDisable()
        {
            DisableSpawning();
        }

        #endregion Unity Actions

        #region Spawn

        private IEnemy SpawnEnemy()
        {
            return Instantiate(
                _enemyPrefab,
                transform.position,
                Quaternion.identity);
        }

        #endregion Spawn 

        #region Enable/Disable Spawning 

        private void EnableSpawning()
        {
            DisableSpawning();

            _isSpawning = true;
            spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private void DisableSpawning()
        {
            _isSpawning = false;

            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
        }

        private IEnumerator SpawnCoroutine()
        {
            var delay = new WaitForSeconds(_spawnInterval);

            do
            {
                yield return delay;

                SpawnEnemy().SetTarget(/*_target*/ null);
            }
            while (_isSpawning && enabled);
        }

        #endregion Enable/Disable Spawning
    }
}