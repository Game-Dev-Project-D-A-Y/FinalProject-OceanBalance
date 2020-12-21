using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]

public class GameTimeScoreTextScript : MonoBehaviour
{
    [Tooltip("Time which represents the score")]
    [SerializeField] int timeOnBase;
    private TextMeshPro textField;
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshPro>();
    }

    public int GetTimeOnBase()
    {
        return this.timeOnBase;
    }

    public void SetTimeOnBasee(int newScore)
    {
        this.timeOnBase = newScore;
        this.textField.text = newScore.ToString();
    }
}
