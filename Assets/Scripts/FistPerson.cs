using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine; 

public class FistPerson : MonoBehaviour
{
    [Header("Detteccion del suelo")]
   
   [SerializeField] private Transform pies;
   [SerializeField] private float radioDetteccion;
   [SerializeField] private LayerMask queEsSuelo;
    
    [Header("Movimiento")]
    
   [SerializeField] private float velocidadMovimiento;
   [SerializeField] private float escalaGravedad;
   [SerializeField] private float alturaSalto;

    CharacterController controler;
    private Vector3 movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;
        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) *  Vector3.forward;
           
            controler.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        Aplicargravedad();
        DeteccionSuelo();        

        

    }
    private void Aplicargravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controler.Move(movimientoVertical * Time.deltaTime);
    }

    private void DeteccionSuelo()
    {
      Collider[] collsDetectados =  Physics.OverlapSphere(pies.position, radioDetteccion, queEsSuelo);
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Salto();
        }

    }
    
    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }
    
        
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDetteccion);
    }
}
