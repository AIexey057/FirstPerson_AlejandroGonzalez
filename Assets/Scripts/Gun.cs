using UnityEngine;

public class Gun : MonoBehaviour
{
    public ArmaSO weaponData;  
    public Transform firePoint;   
    private float nextFireTime = 0f; 

    private void Start()
    {
        weaponData.balasCargador = weaponData.balasBolsa; 
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && weaponData.balasCargador > 0)
        {
            Shoot();
            nextFireTime = Time.time + weaponData.cadenciaAtaque;
        }
    }

    void Shoot()
    {
        if (weaponData.balasCargador <= 0) return;

        GameObject bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.velocity = firePoint.forward * weaponData.distanciaAtaque; 

        weaponData.balasCargador--; 
       
    }

    public void Reload()
    {
        weaponData.balasCargador = weaponData.balasBolsa; 
       
    }
}
