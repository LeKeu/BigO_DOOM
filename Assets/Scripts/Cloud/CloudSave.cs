using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;

public class CloudSave : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    public async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void SaveData()
    {
        var data = new Dictionary<string, object> { {"Nome", input.text } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }
}
