using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrifabs;

    [SerializeField]
    private GameObject[] powerups;


    public GameManager manager;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public IEnumerator waitForSpawnEnemy()
    {
        while (!manager.isGameOver)
        {
            Instantiate(_enemyPrifabs, new Vector3(Random.Range(-8.6f, 8.6f), 7f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(5.0f);
        }
    }

    public IEnumerator waitForSpawnPowerUp()
    {
        while (!manager.isGameOver)
        {
            yield return new WaitForSeconds(5.0f);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8.6f, 8.6f), 7f, 0f), Quaternion.identity);
        }
    }

    public void StartQorountine()
    {
        StartCoroutine(waitForSpawnEnemy());
        StartCoroutine(waitForSpawnPowerUp());
    }
}
