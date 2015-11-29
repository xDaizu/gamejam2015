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
    public GameObject mywrapper;

    //ANIMACIONES
    //Animador del objeto
    public Animator animator;
    public GameObject energyBall;
    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //myRigidBody = gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        mywrapper = GameObject.FindGameObjectWithTag("PlayerWrapper");

        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        facingRight = (h >= 0);
        if (!facingRight)
        {
            transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
        }else{
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        myRigidBody.velocity = new Vector3(h * speed, v * speed, 0);


        //if (Input.GetButton("Fire1"))
        //{
        //    animator.SetBool("Action", true);
        //}




        if (Input.GetButtonDown("Fire2"))
        {
            if (gameObject.transform.FindChild("Ghost-Wrapper").GetComponent<GhostChanges>().forma == 0)
            {
                animator.SetBool("RobaEnergia", true);
                energyBall.SetActive(true);
            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("RobaEnergia", false);
            energyBall.SetActive(false);

        }

        if (Input.GetButton("Fire1"))
        {
            if (gameObject.transform.FindChild("Ghost-Wrapper").GetComponent<Posesion>().GetCorpse()>0)
            {
                animator.SetBool("Poseer", true);
                gameObject.transform.FindChild("Ghost-Wrapper").GetComponent<Posesion>().Poseer();
            }   
        }

        if (Input.GetKey("q"))
        {
            animator.SetBool("Poseer", false);
            gameObject.transform.FindChild("Ghost-Wrapper").GetComponent<Posesion>().Desposeer();
        }
    }
}
