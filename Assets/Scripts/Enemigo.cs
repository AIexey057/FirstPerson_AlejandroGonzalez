using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vidas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AbrirVentanaAtaque()
    {

    }
    private void CerrarVentanaAtaque()
    {

    }
    public void RecibirDanho(float Danhorecibido)
    {
        vidas -= Danhorecibido;
        if (vidas < 0)
        {
            Destroy(gameObject);
        }
    }
      
}
