using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butoes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Jogar()
    {
        SceneManager.LoadScene("StartUp");
    }
}
