using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudSave : MonoBehaviour
{
    [SerializeField] TMP_InputField inputN;
    static string nomePlayer = "";
    public static bool temNovoScore;

    public async void Start()
    {
        temNovoScore = false;
        await UnityServices.InitializeAsync();
        Dictionary<string, string> savedScore = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Score" });
        Dictionary<string, string> savedNome = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Nome" });
        HighScore.scoreH = savedScore["Score"];
        HighScore.nomeH = savedNome["Nome"];
    }

    public async void SaveData()
    {
        Dictionary<string, string> serverData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Nome" });
        
        var nomeData = new Dictionary<string, object> { {"Nome", inputN.text } };
        var scoreData = new Dictionary<string, object> { { "Score", 100000 } };

        if (/*serverData["Nome"] != inputN.text ||*/ !serverData.ContainsKey("Nome"))
        {
            await CloudSaveService.Instance.Data.ForceSaveAsync(nomeData);
            await CloudSaveService.Instance.Data.ForceSaveAsync(scoreData);
            nomePlayer = inputN.text; SceneManager.LoadScene("StartUp");
        }
        else { Debug.Log("já tem" + serverData["Nome"]); }

    }

    public async void SaveHighScore(float score)
    {
        Dictionary<string, string> savedScore = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Score" });
        if(score < Convert.ToDouble(savedScore["Score"]))
        {
            var scoreData = new Dictionary<string, object> { { "Score", score } };
            await CloudSaveService.Instance.Data.ForceSaveAsync(scoreData);
            temNovoScore = true;
        }
    }

    public async void CheckDataData()
    {
        Dictionary<string, string> serverData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Nome" });

        //if (serverData.ContainsKey("Nome"))
            
    }
}
