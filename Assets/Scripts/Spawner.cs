using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] asteroids;
    public Vector3 SpawnValues;
    public float SpawnWait;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public float startWait;
    public static bool stop;
    public int asteroidNumber;
    int randAsteroids;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWait = Random.Range(SpawnLeastWait, SpawnMostWait);
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait); 
        while(!stop)
        {
            randAsteroids = Random.Range(0,2);
            Quaternion SpawnRotation = Quaternion.identity;
            Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x,SpawnValues.x),SpawnValues.y,SpawnValues.z);
            Instantiate(asteroids[randAsteroids], SpawnPosition,SpawnRotation);
            asteroidNumber--;
            if (asteroidNumber <= 0)
            {
                stop = true;
            }
            yield return new WaitForSeconds(SpawnWait);
        }
    }
}
