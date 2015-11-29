using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlPersonaje : MonoBehaviour
{
    //variables que almacenan el valor en x e y del joystick y la velocidad de movimiento
    public float h, v, speed;
    public bool facingRight;
    //Rigidbody del objeto
    private Rigidbody2D myRigidBody;

    //ANIMACIONES
    //Animador del objeto
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        facingRight = (h >= 0);
        if (!facingRight)
        {
            transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        v = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector3(h * speed, v * speed, 0);
        //if (Input.GetButton("Fire1"))
        //{
        //    animator.SetBool("Attack", true);
        //}
        //if (Input.GetButton("Fire2"))
        //{
        //    animator.SetBool("RobaEnergia", true);
        //}
        //if (Input.GetButtonUp("Fire2"))
        //{
        //    animator.SetBool("RobaEnergia", false);
        //}

    }

 
}
