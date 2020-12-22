using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] GameManager gm;

    void Start()
    {

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottle")) 
        {
            gm.OnBottlePicked(other.gameObject);
        }

        if (other.CompareTag("BottomBorder"))
        {
            gm.OnBorderHit(this.gameObject);
        }

        if (other.CompareTag("BlackHole"))
        {
            gm.OnBlackHole(this.gameObject);
        }
    }
}