using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualArma : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
        
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
      cam = Camera.main;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            system.Play(); //para las particulas
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                hitInfo.transform.GetComponent<Enemigo>().RecibirDanho(misDatos.danhoAtaque);
            }
        }
    }
}
