using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro gameTimeScoreTxt; // object that response on score Dovie
    [SerializeField] 
    float timeGained; //
    bool isActive = true;

    [SerializeField]
    TextMeshPro bottleTimerTxt; // object that response on bottle time Dovie

    [SerializeField]
    TextMeshPro BottelsCollectedTxt; // object that response on bottle time Dovie

    int bottelsCollected = -1;   // -1 because in the start of the game the bottle fallls on the ball! please fix alon de loco! ******************************
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
    float minTimeToCollectBottle;
    float timeLeftToCollectBottle;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToCollectBottle = minTimeToCollectBottle;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime();
        BottleTime();


    }

    public void UpdateGameTime()  //update time of game
    {
        if (isActive)   
        {
            timeGained += Time.deltaTime;
            gameTimeScoreTxt.SetText("Time: {0}", timeGained);
        }
    }

      public void CheckAndUpdateBottleTime()
      {
          if (bottelsCollected >= scoreToreduceTimeBottle && minTimeToCollectBottle >= 4)
        {
            minTimeToCollectBottle -= 1;
            scoreToreduceTimeBottle *= 2;
        }
        timeLeftToCollectBottle = minTimeToCollectBottle;

    }

    public void BottleTime()
    {
        timeLeftToCollectBottle -= Time.deltaTime;
        bottleTimerTxt.SetText("Bottle Timer: {0}", timeLeftToCollectBottle);
        if (timeLeftToCollectBottle <= 0)
        {
            timeLeftToCollectBottle = minTimeToCollectBottle;
            //bottleToDestroy = bottleToDestroy.FindWithTag("Bottle");
            Destroy (GameObject.Find("Bottle(Clone)"));
            BottleSpawnerOnCollision();
        }

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
        bottelsCollected += 1;
        BottelsCollectedTxt.SetText("Bottles: " + bottelsCollected);
        CheckAndUpdateBottleTime();
        Debug.Log("OnBottlePicked");
    }
    public void OnBorderHit(GameObject ball)
    {
        Destroy(ball);
        isActive = false;
        Debug.Log("OnBorderHit");
    }
}
