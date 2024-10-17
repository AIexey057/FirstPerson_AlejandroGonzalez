using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine; 

public class FistPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;

    CharacterController controler;
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
        if (input.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) *  Vector3.forward;
           
            controler.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }   
       
       
        
    }
}
