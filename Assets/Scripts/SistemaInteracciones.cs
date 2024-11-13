using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    
    private Camera cam;
    [SerializeField] private float distanciaDeteccion;

    private Transform interactuableActual;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaDeteccion))
        {

            if (hit.transform.TryGetComponent(out CajaMunicion Caja))
            {
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if(Input.GetKeyDown(KeyCode.E))
                {
                  
                }
            }
            
        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;

            interactuableActual = null;
        }
    }
    
}
