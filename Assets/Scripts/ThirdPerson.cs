using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidadMovimiento;

    CharacterController controler;
    private Camera cam;
    [SerializeField] private float smoothing;
    private Animator anim;

    private float velocidadRotacion;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controler = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();    
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoRotacion();

    }

    private void MovimientoRotacion()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;
        if (input.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controler.Move(movimiento * velocidadMovimiento * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
   
}
