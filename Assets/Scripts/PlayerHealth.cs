using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Salud del jugador: {currentHealth}");

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Muerte");
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto!");
    }
}
