using UnityEngine;
using System.Collections;

public class gestionAnimaciones : MonoBehaviour {

    public Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CambiaAShield(int asd)
    {
        animator.SetInteger("PlayerForm", 1);
    }
}
