using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void PlayGame()
    {
       
        SceneManager.LoadScene("SampleScene");

    }
   
    public void QuitGame()
    {
    
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Muerte()
    {
        SceneManager.LoadScene("Muerte");
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
