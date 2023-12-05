using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butoes : MonoBehaviour
{

    public void restartJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Jogar()
    {
        SceneManager.LoadScene("StartUp");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
