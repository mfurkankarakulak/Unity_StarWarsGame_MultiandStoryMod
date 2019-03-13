using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
   
   // public GameObject enemyPrefab;
    public int hazardCount;
    public Vector3 spawnValues;
    private int score;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject[] hazards;
    void Start()
    {

        //StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                /* bool flag = (Random.value > 0.05f);
                    if (flag){
                        
                        spawnValues.z (16 or -16) 
                    }
                */
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                 GameObject clone =  (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
               
                NetworkServer.Spawn(clone);
                // ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            
        }
    }
    public override void OnStartServer()
    {
        StartCoroutine(SpawnWaves());
        /*  for (int i = 0; i < hazardCount; i++)
          {

              Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
              Quaternion spawnRotation = Quaternion.identity;

              GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
              //  GameObject as11 = (GameObject)Instantiate(as1, spawnPosition, spawnRotation);
              //  GameObject as22 = (GameObject)Instantiate(as2, spawnPosition, spawnRotation);
              //  GameObject as33 = (GameObject)Instantiate(as3, spawnPosition, spawnRotation);

              NetworkServer.Spawn(enemy);
              // NetworkServer.Spawn(as11);
              // NetworkServer.Spawn(as22);
              // NetworkServer.Spawn(as33);


          }


          /*#pragma warning disable CS8321 // Local function is declared but never used
          IEnumerator SpawnWaves()

          {
              yield return new WaitForSeconds(startWait);
              while (true)
              {
                  for (int i = 0; i < hazardCount; i++)
                  {
                      GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                      /* bool flag = (Random.value > 0.05f);
                          if (flag){

                              spawnValues.z (16 or -16) 
                          }

                      Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                      Quaternion spawnRotation = Quaternion.identity;
                      // GameObject clone =  Instantiate(hazard, spawnPosition, spawnRotation);

                      NetworkServer.Spawn(Instantiate(hazard, spawnPosition, spawnRotation));
                      // ReverseDirection(clone);
                      yield return new WaitForSeconds(spawnWait);
                  }
                  yield return new WaitForSeconds(waveWait);


              }
          }*/
    }

   
}
