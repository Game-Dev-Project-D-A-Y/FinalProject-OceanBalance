using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro gameScore;         // object that response on score Dovie

    [SerializeField] TextMeshPro bottleTime;        // object that response on bottle time Dovie

    [SerializeField] int scoreToreduceTimeBottle; // check score and update time
    [SerializeField] int levelScoreToAdd; // check score and update time

 

    // yishay
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] GameObject baseObject;
    [SerializeField] int minTimeToCollectBottle;




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
        // object that response on score Dovie   
        if(gameScore >= scoreToreduceTimeBottle )
        {
           scoreToreduceTimeBottle += levelScoreToAdd;  // for example levelScoreToAdd=10 so every 10 bottles time -- 
           if(bottleTime == minTimeToCollectBottle){
               return;
           }
           return;
    }
    }
    public void BottleSpawnerOnCollision()
    {
        Vector3 randomPosition = new Vector3();
        randomPosition = new Vector3(Random.Range(baseObject.transform.localScale.x, baseObject.transform.localScale.z), 0,
             Random.Range(baseObject.transform.localScale.x, baseObject.transform.localScale.z));
        GameObject newObject = Instantiate(prefabToSpawn.gameObject, randomPosition, Quaternion.identity, baseObject.transform);
        
    }

        public void BottleSpawnerOnTimeOut()
    {
        Vector3 randomPosition = new Vector3();
        randomPosition = new Vector3(Random.Range(baseObject.transform.localScale.x, baseObject.transform.localScale.z), 0,
             Random.Range(baseObject.transform.localScale.x, baseObject.transform.localScale.z));
                     GameObject newObject = Instantiate(prefabToSpawn.gameObject, randomPosition, Quaternion.identity, baseObject.transform);
    }

    public void OnBottlePicked(GameObject bottle)
    {
        BottleSpawnerOnCollision();
        Destroy(bottle);
        Debug.Log("OnBottlePicked");
    }


}

    