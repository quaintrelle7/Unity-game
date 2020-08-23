using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerup;
    [SerializeField]
    private bool _stopSpawning = false;
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemyRoutine()
    {
    while(_stopSpawning == false)
    {
    Vector3 posToSpawn = new Vector3(Random.Range(-29.2f, 2.6f),0.5f,0);
   GameObject newEnemy = Instantiate(_EnemyPrefab, posToSpawn, Quaternion.identity);
    newEnemy.transform.parent = _enemyContainer.transform;
     //yield return null; //wait 1 frame
    //then this line called
    yield return new WaitForSeconds(3.0f);
    }
    
   //while loop
     //instantiate prefab
     //yield wait for five seconds
     //yield is just used a s while loop is an infinite loop to stop it yield is used

	}

     IEnumerator SpawnPowerUpRoutine()
     {
     while(_stopSpawning == false)
     {
      Vector3 posToSpawn = new Vector3(Random.Range(-29.2f, 2.6f),7,0);

     int randomPowerUp = Random.Range(0,3);

     Instantiate(_powerup[randomPowerUp], posToSpawn, Quaternion.identity);
      yield return new WaitForSeconds(Random.Range(5, 11));
	 }
	 }
     
   
     public void OnPlayerDeath()
    {
     _stopSpawning = true;
	}


   
}
