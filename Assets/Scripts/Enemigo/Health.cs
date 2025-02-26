using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10; 

    public void TakeDamage(int damage)
    {
        health -= damage; 
        Debug.Log(gameObject.name + " ha recibido " + damage + " de daño. Salud restante: " + health);

        if (health <= 0)
        {
            Die(); 
        }
    }

    // Método para manejar la muerte del enemigo
    private void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        
        Destroy(gameObject); 
    }
}
