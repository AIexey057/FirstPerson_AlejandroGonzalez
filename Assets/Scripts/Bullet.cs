using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5; 

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Enemy"))
        {
           
            Health enemyHealth = other.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("La bala ha impactado al enemigo y ha causado " + damage + " de daño.");
            }

           
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
          
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 3f); 
    }
}
