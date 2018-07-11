using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController charControl;
    public float walkSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float speed;
    float verticalSpeed;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        
       // charControl.SimpleMove(moveDirSide);
        //charControl.SimpleMove(moveDirForward);

          verticalSpeed -= gravity * Time.deltaTime;
        Vector3 mov = new Vector3(0, 0, 0);
        mov += transform.forward * Input.GetAxis("Vertical") * speed;
        mov += Vector3.up * verticalSpeed;

        //charControl.Move(mov * Time.deltaTime);

        if (charControl.isGrounded)
        {
            if (Input.GetButton("Jump"))
                verticalSpeed = jumpForce;
            else
                verticalSpeed = 0;
        }
        charControl.Move((moveDirForward + moveDirSide + mov)* Time.deltaTime);
    }
    
}
