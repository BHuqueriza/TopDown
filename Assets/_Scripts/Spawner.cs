/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       02/08/2016 00:39
================================================================*/

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // Variable Declarations
    public Wave[] waves;

    // Static Variables

    // Private Variables
    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;
    int currentWaveNumber;

    // Public Variables

    // Function Definitions
    public Enemy enemy;
    Wave currentWave;
	
	// Unity Functions
	
	void Awake ()
    {
		
	}
	
    void Start ()
    {
        NextWave();
	}
	
	void OnDestroy ()
    {
		
	}

    void Update ()
    {
		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath ()
    {
        enemiesRemainingAlive--;
        
        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }

        currentWaveNumber++;
        print("Wave: " + currentWaveNumber);
    }
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}