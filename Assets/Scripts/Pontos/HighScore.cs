using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject nameText;
    [SerializeField] Tempo timer;
    public static string scoreH;
    public static string nomeH;

    bool auxBool;

    private void Start()
    {
        auxBool = false;
    }

    private void Update()
    {
        string aux = "";
        if (!auxBool)
        {
            for (int i = 0; i < scoreH.Length; i++)
            {
                if (scoreH[i] == '.') { auxBool = true; break; }
                aux += scoreH[i];
            }
        }
        
        scoreText.GetComponent<TextMeshProUGUI>().text = $"{nomeH}\nHighScore: {DisplayTime(float.Parse(aux))}";
    }
    public string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
