using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    [SerializeField] GameObject PainelEntrar;
    [SerializeField] GameObject PainelLogIn;
    async void Start()
    {
        //AuthenticationService.Instance.ClearSessionToken();
        await UnityServices.InitializeAsync();
    }


    public async void SignIn()
    {
        await SignInAnonymous();
    }

    public async void SignInDireto()
    {
        await SignInAnonymousDIreto();
    }

    async Task SignInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("sucesso " + AuthenticationService.Instance.PlayerId);
            PainelEntrar.SetActive(false);
            PainelLogIn.SetActive(true);
        }catch (AuthenticationException ex)
        {
            Debug.Log(ex);
        }
    }

    async Task SignInAnonymousDIreto()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("sucesso " + AuthenticationService.Instance.PlayerId);
            SceneManager.LoadScene("StartUp");
        }
        catch (AuthenticationException ex)
        {
            Debug.Log(ex);
        }
    }
}
