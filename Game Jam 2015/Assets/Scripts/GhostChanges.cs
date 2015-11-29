﻿using UnityEngine;
using System.Collections;

public class GhostChanges : MonoBehaviour {
    public Animator anima;

    // Use this for initialization
    void Start () {
             anima=gameObject.transform.FindChild("Ghost-Wrapper").GetComponent<Animator>();
    }

    void Update() {
        controlAndar();
    }
   
    public void SetState(int newState) {
        switch(newState)
        {
            case 0:
                anima.SetInteger("PlayerForm", 0);
                Debug.Log("I'm little sexy ghost");
                break;
            case 1:
                anima.SetInteger("PlayerForm", 1);
                Debug.Log("I'm de SHIELD-WARRIOR");
                break;
            case 2:
                anima.SetInteger("PlayerForm", 2);
                Debug.Log("My blade is awesome. Also my sword");
                break;
            case 4:
                anima.SetInteger("PlayerForm", 3);
                Debug.Log("Goblin, the Goblin");
                break;
            default:
                Debug.Log("EL CAMBIO DE FORMA ES IMPRACTICABLE");
                break;
        }
    }

    public void SetAction(int action) {
        switch (action)
        {
            case 0:
                anima.SetBool("Andar", true);
                anima.SetBool("Action", false);
                anima.SetBool("Muerte", false);
                Debug.Log("Walking on the moon");
                break;
            case 1:
                anima.SetBool("Andar", false);
                anima.SetBool("Action", true);
                anima.SetBool("Muerte", false);
                Debug.Log("I'm making my action");
                break;
            case 3:
                anima.SetBool("Andar", false);
                anima.SetBool("Action", false);
                anima.SetBool("Muerte", true);
                Debug.Log("Bye Bye");
                break;
            default:
                Debug.Log("Las acciones me confunden");
                break;
        }
    }
    public void desactivarAccion() {
        anima.SetBool("Action", false);
    }

    public void controlAndar()
    {
  
        if (gameObject.transform.parent.GetComponent<ControlPersonaje>().h != 0f || gameObject.transform.parent.GetComponent<ControlPersonaje>().v != 0f)
        {
            print("Anda");
            anima.SetBool("Andar", true);
        }
        else {
            print("Quieto");
            anima.SetBool("Andar", false);
        }
    }
    public void Revivir()
    {
        anima.SetBool("Muerte", false);
        anima.SetInteger("PlayerForm", 0);
    }
}
