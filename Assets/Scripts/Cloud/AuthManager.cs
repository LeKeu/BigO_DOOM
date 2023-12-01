using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void SignIn()
    {
        await SignInAnonymous();
    }

    async Task SignInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("sucesso " + AuthenticationService.Instance.PlayerId);
        }catch (AuthenticationException ex)
        {
            Debug.Log(ex);
        }
    }
}
