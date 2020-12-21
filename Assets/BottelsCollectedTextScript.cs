using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class BottelsCollectedTextScript : MonoBehaviour
{

    private TextMeshPro textField;
    private int BottelsCollected;

    void Start()
    {
        textField = GetComponent<TextMeshPro>();
    }

    public int GetSBottelsCollected()
    {
        return this.BottelsCollected;
    }

    public void SetBottelsCollectede(int newBottelsCollected)
    {
        this.BottelsCollected = newBottelsCollected;
        this.textField.text = newBottelsCollected.ToString();
    }
}


