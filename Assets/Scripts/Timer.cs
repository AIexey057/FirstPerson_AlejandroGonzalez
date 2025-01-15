using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public class GameTimer : MonoBehaviour
    {
        public float timeToWin = 5f; 
        private float timer;

        private void Start()
        {
            timer = timeToWin; 
        }

        private void Update()
        {
            timer -= Time.deltaTime; 

            if (timer <= 0)
            {
                LoadVictoryScreen(); 
            }
        }

        private void LoadVictoryScreen()
        {
            SceneManager.LoadScene("Win");
        }
    }
    }
