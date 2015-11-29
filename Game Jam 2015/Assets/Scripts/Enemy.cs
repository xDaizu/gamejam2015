﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed = 5f;
    public GameObject objeto;
    public float distance, radioAtaque;
    public Animator anima;
	
    // Use this for initialization
	void Start () {
        anima = gameObject.GetComponent<Animator>();
        distance = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
       
    }

    public void SetSpeed(float sp) { this.speed=sp; }
    public float GetSpeed() { return this.speed; }

    public void SetRadioAtaque(float r) { this.radioAtaque = r; }
    public float GetRadioAtaque() { return this.radioAtaque; }

    public void SetObjetivo(GameObject ob) { this.objeto = ob; }
    public GameObject GetObjetivo() { return this.objeto; }

    public void playerSighted(GameObject player) {
        if (distance > radioAtaque)
        {
            anima.SetFloat("Velocidad", speed);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, objeto.transform.position, speed * Time.deltaTime);
        }
        if (distance <= radioAtaque)
        {
            anima.SetBool("Ataca", true);
        }
    }
    public void playerLost(GameObject player) { }

    public void OnTriggerEnter2D(Collider2D colision)
    {
            objeto = colision.gameObject;
    }

}