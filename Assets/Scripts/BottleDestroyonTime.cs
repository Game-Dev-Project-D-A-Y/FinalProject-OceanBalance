using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This script represents the ball moves and collides.
*/
public class BottleDestroyonTime : MonoBehaviour
{

    public float timeBottleToBeShown;
   
   //public GameManager gameManager;

    public GameObject objectToDetroy;

    private bool inPlay;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime > timeBottleToBeShown){
            Debug.Log("bottle destroy"+ this);
               Destroy(objectToDetroy);
        }

    }


}

