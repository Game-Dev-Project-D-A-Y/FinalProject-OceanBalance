using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro gameScore; // object that response on score Dovie

    [SerializeField]
    TextMeshPro bottleTime; // object that response on bottle time Dovie

    [SerializeField]
    int scoreToreduceTimeBottle; // check score and update time

    [SerializeField]
    int levelScoreToAdd; // check score and update time

    // yishay
    [SerializeField]
    GameObject prefabToSpawn;

    [SerializeField]
    GameObject baseObject;

    [SerializeField]
    int minTimeToCollectBottle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartBottleNewTime()
    {
        // object that response on bottle time Dovie
    }

    public void CheckAndUpdateBottleTime()
    {
        // TODO
    }
    private static float num = 1;
    public void BottleSpawnerOnCollision()
    {
        Debug.Log("BottleSpawnerOnCollision");

        float scaleX = baseObject.transform.localScale.x / 2f;
        float scaleZ = baseObject.transform.localScale.z / 2f;
        float randomX = Random.Range(-scaleX,scaleX);
        float randomZ = Random.Range(-scaleZ,scaleZ);
        Vector3 randomPosition = new Vector3(randomX,0,randomZ);

        GameObject newObject = Instantiate(prefabToSpawn.gameObject, randomPosition, baseObject.transform.localRotation);
        newObject.transform.parent = baseObject.transform;
        newObject.transform.localPosition = new Vector3(newObject.transform.localPosition.x,0,newObject.transform.localPosition.z);
    }

    public void BottleSpawnerOnTimeOut()
    {
                Debug.Log("BottleSpawnerOnTimeOut");
        Vector3 randomPosition =
            new Vector3(Random.Range(-10.0f, 10.0f),
                0,
                Random.Range(-10.0f, 10.0f));
        GameObject newObject =
            Instantiate(prefabToSpawn.gameObject,
            randomPosition,
            Quaternion.identity);
    }

    public void OnBottlePicked(GameObject bottle)
    {
        BottleSpawnerOnCollision();
        Destroy (bottle);
        Debug.Log("OnBottlePicked");
    }
}
