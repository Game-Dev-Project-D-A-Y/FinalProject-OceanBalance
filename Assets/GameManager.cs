using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
*   Class that manages game events
*/
public class GameManager : MonoBehaviour
{
    [Tooltip("The object of the surface")]
    [SerializeField]
    GameObject baseObject;

    [Tooltip("Bottle prefab to be respawn")]
    [SerializeField]
    GameObject bottleToSpawn;

    [Tooltip("Black hole prefab to be respawn")]
    [SerializeField]
    GameObject blackHoleToSpawn;

    [Tooltip("Time text field to be edited")]
    [SerializeField]
    TextMeshPro gameTimeScoreTxt; 

    [Tooltip("Bottle timer text field to be edited")]
    [SerializeField]
    TextMeshPro bottleTimerTxt; 

    [Tooltip("Number of bottle collected text field to be edited")]
    [SerializeField]
    TextMeshPro BottelsCollectedTxt; 

    [Tooltip("Decrease bottle timer when achived given score")]
    [SerializeField]
    int scoreToReduceTimeBottle; 

    [Tooltip("Maximum time for collecting bottle")]
    [SerializeField]
    float maxTimeToCollectBottle;

    // Variable that holds the current time left to collect bottle
    private float timeLeftToCollectBottle;

    // Game timer
    private float timeGained; 

    // Indicates whether the game is running
    private bool isActive = true;

    // Number of bottles collected
    private int bottelsCollected = 0; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToCollectBottle = maxTimeToCollectBottle + 1;
        SpawnBottle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        UpdateGameTime();
        BottleTime();
    }

    // PUBLIC METHODS

    // Method thats being called when bottle is picked
    public void OnBottlePicked(GameObject bottle)
    {
        Debug.Log("OnBottlePicked");
        SpawnBottle();
        Destroy (bottle);
        bottelsCollected += 1;
        Debug.Log("bottelsCollected:" + bottelsCollected);
        BottelsCollectedTxt.SetText("Bottles Collected\n{0}", (int)bottelsCollected);
        CheckAndUpdateBottleTime();
    }

    // Method thats being called when the ball hits the sea
    public void OnBorderHit(GameObject ball)
    {
        Destroy (ball);
        isActive = false;
        Debug.Log("OnBorderHit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // Method thats being called when the ball step on a black hole
    public void OnBlackHole(GameObject ball)
    {
        Destroy (ball);
        isActive = false;
        Debug.Log("OnBlackHole");
    }

    // PRIVATE METHODS

    // Method that updates time of game
    private void UpdateGameTime() 
    {
        if (isActive)
        {
            timeGained += Time.deltaTime;
            gameTimeScoreTxt.SetText("Time\n{0}", (int)timeGained);
        }
    }

    // Method that checks and updates time left for collecting bottle
    private void CheckAndUpdateBottleTime()
    {
        if (
            bottelsCollected >= scoreToReduceTimeBottle &&
            maxTimeToCollectBottle >= 5
        )
        {
            maxTimeToCollectBottle -= 1;
            scoreToReduceTimeBottle *= 2;
        }
        timeLeftToCollectBottle = maxTimeToCollectBottle;
    }

    // Method that sets time left for collecting bottle
    private void BottleTime()
    {
        timeLeftToCollectBottle -= Time.deltaTime;
        bottleTimerTxt.SetText("Bottle Timer\n{0}", (int) timeLeftToCollectBottle);
        if (timeLeftToCollectBottle <= 1)
        {
            timeLeftToCollectBottle = maxTimeToCollectBottle + 1;
            GameObject bottleObject = GameObject.Find("BottlePrefab(Clone)");
            Destroy(bottleObject);
            CreateBlackHole(bottleObject);
            SpawnBottle();
        }
    }

    // Method that creates new black hole on the uncollected bottle
    private void CreateBlackHole(GameObject bottleObject)
    {
        GameObject newObject = Instantiate(blackHoleToSpawn.gameObject, bottleObject.transform.position, baseObject.transform.localRotation);
        newObject.transform.parent = baseObject.transform;
        newObject.transform.localPosition = new Vector3(newObject.transform.localPosition.x, 0.6f, newObject.transform.localPosition.z);
    }

    // Method that spawns a new bottle
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
