using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tempo : MonoBehaviour
{
    public float tempoAtual = 0;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI timeText;
    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (!AcabarJogo.chegouNoFim)
        {
            tempoAtual += Time.deltaTime;
            DisplayTime(tempoAtual);
        }
        else
        {
            Debug.Log(tempoAtual);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
