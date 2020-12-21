using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This script represents the ball moves and collides.
*/
public class BottleDestroyOnCollision : MonoBehaviour
{
   
    public Transform bottleStartPosition;

   //public GameManager gameManager;

    public GameObject objectToCollision;

    public Transform lifeAdderObject;

    private Rigidbody rb;  //ball ot bottle

    private bool inPlay;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing when game is over
        // need to add
        
        // if (gameManager.gameOver)
        // {
        //     rb.velocity = Vector2.zero;
        //     return;
        // }

        // // Attach the ball to surface before starting
        // if (!inPlay)
        // {
        //     transform.position = bottleStartPosition.position;
        // }
    }

    void OnTriggerEnter(Collider other)
    {

        //add tag to Ball
        if (other.tag =="Ball")
        {
            return;
        }

        // // Handle collision with bottom border
        // if (other.tag == GameManager.BOTTOM_BORDER)
        // {
        //     rb.velocity = Vector2.zero;
        //     inPlay = false;
        //     gameManager.DecreaseLives();
        // }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int randomNumber = Random.Range(1, 101);

        // Handle collisions with ball
        if (other.transform.CompareTag("Ball"))
        {
            // need to be aded
            //BrickScript brickScript =
               // other.gameObject.GetComponent<BrickScript>();

            // Explosion effect when breaking a brick
            // Transform newExplosion =
            //     Instantiate(explosion,
            //     other.transform.position,
            //     other.transform.rotation);
           // Destroy(newExplosion.gameObject, 2.5f);

            //need to add
           // gameManager.UpdateScore(brickScript.points);
          // gameManager.BricksUpdate();
            Destroy(this.gameObject);
        }   
    }
}