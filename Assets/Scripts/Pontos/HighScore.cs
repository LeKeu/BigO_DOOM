using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] Tempo timer;
    public static string scoreH;
    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "HighScore: "+ DisplayTime(float.Parse(scoreH));
    }
    public string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
