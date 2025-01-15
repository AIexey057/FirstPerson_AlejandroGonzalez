using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;  
    public Transform[] spawnPoints;  
    public float tiempoEntreSpawns = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Espera el tiempo especificado entre spawns
            yield return new WaitForSeconds(tiempoEntreSpawns);

            // Seleccionamos un punto de spawn aleatorio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instanciamos el enemigo en la posición del punto de spawn
            Instantiate(enemigoPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
