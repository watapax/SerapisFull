using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMobile : MonoBehaviour
{
    public float speed;
    public float multGravedad;
    public float velocidadRotacion;
    public float fuerzaSalto;
    Vector3 moveDirection;
    Vector3 rotateDirection;


    public Joystick joystick;
    public CharacterController cc;
    public GameObject refe;
    public float salto;
    float ySpeed;
    public Vector3 velocity;
    private void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        PlayerRotation();
    }

    void PlayerMovement()
    {
        //float yStore = moveDirection.y;

        //moveDirection = ((joystick.Vertical * speed * refe.transform.forward) + (joystick.Horizontal * speed * refe.transform.right));
        // moveDirection = moveDirection.normalized * speed;
        // moveDirection.y = yStore + salto;
        //ySpeed += Physics.gravity.y * Time.deltaTime;


        //moveDirection.y = moveDirection.y + (Physics.gravity.y * multGravedad * Time.deltaTime);
        //moveDirection.y -= multGravedad * Time.deltaTime;
        /*
        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            rotateDirection = moveDirection;
        }*/

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direccion = new Vector3(horizontal, 0, vertical);
        float magnitud = Mathf.Clamp01(direccion.magnitude) * speed;
        direccion.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime * multGravedad;

        if(cc.isGrounded)
        {
            //ySpeed = 0;
        }

        velocity = direccion * magnitud;
        velocity.y = ySpeed;
        cc.SimpleMove(velocity * Time.deltaTime);


    }


    void PlayerRotation()
    {
        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                targetRotation, velocidadRotacion * Time.deltaTime);
        }
    }

    Vector3 DirectionXZ()
    {
        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            Vector3 direction = rotateDirection;
            direction.y = 0; // Ignore Y
            return direction;
        }
        else
        {
            Vector3 direction = moveDirection;
            direction.y = 0; // Ignore Y
            return direction;
        }

    }

    public void Jump()
    {
       // if(cc.isGrounded)
            ySpeed = fuerzaSalto;
    }


}
