using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 
    private int score = 0; 

    public void IncreaseScore()
    {
        score++; 
        scoreText.text = "Score: " + score; 
    }
}