using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBottleScript : MonoBehaviour
{
    [SerializeField] GameManager gm;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bottle")) {
            gm.OnBottlePicked(other.gameObject);
        }
        if (other.CompareTag("BottomBorder"))
        {
            gm.OnBorderHit(this.gameObject);
        }
    }
}
