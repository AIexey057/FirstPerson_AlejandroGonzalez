using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del jugador
    public int currentHealth;   // Salud actual del jugador
    public Slider healthSlider; // Referencia al Slider UI para la vida
    public Text healthText;     // Referencia al Text UI si usas texto en lugar de Slider

    private void Start()
    {
        // Establecer la salud inicial
        currentHealth = maxHealth;

        // Actualizar el Slider de vida
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;  // Establecer valor m�ximo del slider
            healthSlider.value = currentHealth; // Establecer valor inicial
        }

        // Actualizar el texto de vida si es necesario
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restar el da�o de la salud actual
        if (currentHealth < 0) currentHealth = 0; // Evitar que la salud sea negativa

        // Actualizar la UI despu�s de recibir da�o
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // Actualizar el Slider si lo tienes
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // Actualizar la barra de vida
        }

        // Actualizar el texto de vida si lo tienes
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString(); // Mostrar la vida como texto
        }
    }
}
