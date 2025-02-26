using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class Timer : MonoBehaviour
{
    public float timeToWin = 5f; 
    private float timer;
    public TextMeshProUGUI timerText; 

    private void Start()
    {
        timer = timeToWin; 
    }

    private void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0)
        {
            timer = 0; 
            Debug.Log("Has ganado");
            LoadVictoryScreen();
        }

        UpdateTimerUI(); 
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Faltan: " + timer.ToString("F2") + "s"; 
        }
    }

    private void LoadVictoryScreen()
    {
        SceneManager.LoadScene("Win");
    }
}