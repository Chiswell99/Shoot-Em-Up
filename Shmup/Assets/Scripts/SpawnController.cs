using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<EnemyWavesConfig> wavesConfigs;

    [SerializeField] private Quaternion spawnRotation;
    
    [SerializeField] private float initialWaitTime;
    [SerializeField] private float cadenceBetweenWaves;

    private void Start()
    {
        GameController.Instance.OnEnemyDied += OnEnemyDied;
        StartCoroutine(EnemySpawnerCoroutine());
    }
    
    private void OnDestroy()
    {
        if(GameController.Instance != null)
        {
            GameController.Instance.OnEnemyDied -= OnEnemyDied;

        }
    }
    private void OnEnemyDied(GameObject corpse)
    {
        
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);
        foreach(var wave in wavesConfigs)
        {
            foreach ( var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;
                if (enemy.useSpecificXPosition)
                {
                    enemyPosition = enemy.spawnReferencePosition;
                }
                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spawnReferencePosition.x, enemy.spawnReferencePosition.x), enemy.spawnReferencePosition.y, enemy.spawnReferencePosition.z);
                }
                SpawnEnemy(enemy.enemyPrefab, enemy.config, enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadence);
            }
            yield return new WaitForSeconds(cadenceBetweenWaves);
        }

    }
    public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config, Vector3 enemyPosition, Quaternion rotation)
    {
        var enemyInstance = Instantiate(enemyPrefab, enemyPosition, rotation);
        enemyInstance.config = config;
    }


}
