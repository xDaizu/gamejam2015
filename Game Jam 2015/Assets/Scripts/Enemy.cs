using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed = 5f;
    public GameObject objeto;
    public float perception, distance;
    public Animator anima;
	// Use this for initialization
	void Start () {
         anima = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
        if (distance <= perception && distance > 1f )
        {
            anima.SetFloat("Velocidad", speed);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, objeto.transform.position, speed * Time.deltaTime);
        }

        if (distance <= 1f)
        {
            anima.SetBool("Ataca",true);
        }
    }

    public void SetSpeed(float sp) { this.speed=sp; }
    public float GetSpeed() { return speed; }

    public void SetObjetivo(GameObject ob) { this.objeto = ob; }
    public GameObject GetObjetivo() { return objeto; }
}
