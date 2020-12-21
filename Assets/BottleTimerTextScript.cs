using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshPro))]

public class BottleTimerTextScript : MonoBehaviour
{
    [Tooltip("Timer of Bottle until they disepear")]
    [SerializeField] float BottleTime;
    private TextMeshPro textField;
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        public int GetBottleTime()
        {
            return this.BottleTime;
        }

        public void SetBottleTime(int newBottleTime)
        {
            this.BottleTime = newBottleTime;
            this.textField.text = newBottleTime.ToString();
        }
    }
}
