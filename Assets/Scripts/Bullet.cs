using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bala impactó con: " + other.name);
        Destroy(gameObject); 
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
