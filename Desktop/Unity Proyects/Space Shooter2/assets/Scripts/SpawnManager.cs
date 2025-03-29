using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
 
    IEnumerator SpawnEnemyRoutine ()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            //Vector3 posToSpawn = new Vector3(Random.Range(-17.5f, 14.5f), 16.5f, 0);

            Vector3 posToSpawn = new Vector3(Random.Range(-17.0f, 17.0f), 12f, 0);
            GameObject newEnemy = Instantiate(_enemyprefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        
    }

    IEnumerator SpawnPowerupRoutine()
    {
        //every3-7 sec, spawn in power up
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-17.0f, 17.0f), 12f, 0);
            int randomPowerUP = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUP], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 15));

        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
//Vector3 posToSpawn = new Vector3(Random.Range(-17.5f, 17.5f), 16.5f, 0);
//Instantiate(_enemyprefab, posToSpawn, Quaternion.identity);
//
//yield return new WaitForSeconds(5.0f);
