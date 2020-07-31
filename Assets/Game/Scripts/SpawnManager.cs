using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrifabs;

    [SerializeField]
    private GameObject[] powerups;

    void Start()
    {
        StartCoroutine(waitForSpawnEnemy());
        StartCoroutine(PowerUpSpawn());
    }
    IEnumerator waitForSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(_enemyPrifabs, new Vector3(Random.Range(-8.6f, 8.6f), 7f, 0f), Quaternion.identity);
        }
    }

    IEnumerator PowerUpSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8.6f, 8.6f), 7f, 0f), Quaternion.identity);
        }
    }
}
