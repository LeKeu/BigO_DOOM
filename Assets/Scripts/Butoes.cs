using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butoes : MonoBehaviour
{

    public void restartJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Jogar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartUp");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Ensinando()
    {
        SceneManager.LoadScene("Ensinando");
    }
}
