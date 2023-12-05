using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tempo : MonoBehaviour
{
    public static float tempoAtual = 0;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] CloudSave cloudSave;

    bool auxSalvar;
    private void Start()
    {
        tempoAtual = 0;
        timerIsRunning = true; auxSalvar = false;
    }
    void Update()
    {
        if (!AcabarJogo.chegouNoFim)
        {
            tempoAtual += Time.deltaTime;
            DisplayTime(tempoAtual);
        }
        if(AcabarJogo.chegouNoFim && !auxSalvar)
        {
            auxSalvar = true;
            cloudSave.SaveHighScore(tempoAtual);
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
