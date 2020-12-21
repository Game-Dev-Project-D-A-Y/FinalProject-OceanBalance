using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component spawns the given object at random time-intervals.
 */
public class BottleTimesSpawner: MonoBehaviour {
    [SerializeField] GameObject prefabToSpawn;
   // [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] float timeBetweenSpawns = 1f;

    void Start() {
        this.StartCoroutine(SpawnRoutine());
        Debug.Log("Start finished");
    }

    private IEnumerator SpawnRoutine() {
        Vector3 randomPosition = new Vector3();

        while (true) {
             randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, randomPosition, Quaternion.identity);
           // newObject.GetComponent<GameObject>().SetVelocity(velocityOfSpawnedObject);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}