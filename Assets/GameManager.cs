using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject baseObject;

    [SerializeField]
    GameObject bottleToSpawn;

    [SerializeField]
    GameObject blackHoleToSpawn;

    [SerializeField]
    TextMeshPro gameTimeScoreTxt; // object that response on score Dovie

    [SerializeField]
    TextMeshPro bottleTimerTxt; // object that response on bottle time Dovie

    [SerializeField]
    TextMeshPro BottelsCollectedTxt; // object that response on bottle time Dovie

    [SerializeField]
    int scoreToReduceTimeBottle; // check score and update time

    [SerializeField]
    int levelScoreToAdd; // check score and update time

    [SerializeField]
    float minTimeToCollectBottle;

    float timeLeftToCollectBottle;

    private float timeGained; 

    private bool isActive = true;

    private int bottelsCollected = 0; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToCollectBottle = minTimeToCollectBottle;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        UpdateGameTime();
        BottleTime();
    }

    // PUBLIC METHODS
    public void OnBottlePicked(GameObject bottle)
    {
        Debug.Log("OnBottlePicked");
        SpawnBottle();
        Destroy (bottle);
        bottelsCollected += 1;
        Debug.Log("bottelsCollected:" + bottelsCollected);
        BottelsCollectedTxt.SetText("Bottles: " + bottelsCollected);
        CheckAndUpdateBottleTime();
    }

    public void OnBorderHit(GameObject ball)
    {
        Destroy (ball);
        isActive = false;
        Debug.Log("OnBorderHit");
    }

    public void OnBlackHole(GameObject ball)
    {
        Destroy (ball);
        isActive = false;
        Debug.Log("OnBlackHole");
    }

    // PRIVATE METHODS
    private void UpdateGameTime() //update time of game
    {
        if (isActive)
        {
            timeGained += Time.deltaTime;
            gameTimeScoreTxt.SetText("Time: {0}", timeGained);
        }
    }

    private void CheckAndUpdateBottleTime()
    {
        if (
            bottelsCollected >= scoreToReduceTimeBottle &&
            minTimeToCollectBottle >= 4
        )
        {
            minTimeToCollectBottle -= 1;
            scoreToReduceTimeBottle *= 2;
        }
        timeLeftToCollectBottle = minTimeToCollectBottle;
    }

    private void BottleTime()
    {
        timeLeftToCollectBottle -= Time.deltaTime;
        bottleTimerTxt.SetText("Bottle Timer: {0}", timeLeftToCollectBottle);
        if (timeLeftToCollectBottle <= 0)
        {
            timeLeftToCollectBottle = minTimeToCollectBottle;
            GameObject bottleObject = GameObject.Find("BottlePrefab(Clone)");
            Destroy(bottleObject);
            CreateBlackHole(bottleObject);
            SpawnBottle();
        }
    }

    private void CreateBlackHole(GameObject bottleObject)
    {
        GameObject newObject = Instantiate(blackHoleToSpawn.gameObject, bottleObject.transform.position, baseObject.transform.localRotation);
        newObject.transform.parent = baseObject.transform;
        newObject.transform.localPosition = new Vector3(newObject.transform.localPosition.x, 0.6f, newObject.transform.localPosition.z);
    }

    private void SpawnBottle()
    {
        Debug.Log("SpawnBottle");

        float scaleX = (baseObject.transform.localScale.x / 2f) - 2;
        float scaleZ = (baseObject.transform.localScale.z / 2f) - 2;
        float randomX = Random.Range(-scaleX, scaleX);
        float randomZ = Random.Range(-scaleZ, scaleZ);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        GameObject newObject = Instantiate(bottleToSpawn.gameObject, randomPosition, baseObject.transform.localRotation);
        newObject.transform.parent = baseObject.transform;
        newObject.transform.localPosition = new Vector3(newObject.transform.localPosition.x, 0, newObject.transform.localPosition.z);
    }
}
