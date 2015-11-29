using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed = 1f;
    public GameObject objeto;
    public float distance, radioAtaque;
    public Animator anima;
    private bool aggresiveMode = false;
    private GameObject target = null;

    // Use this for initialization
    void Start () {
        anima = gameObject.GetComponent<Animator>();
        distance = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
        if (aggresiveMode) {
            this.aggresiveAction();
        }
       
    }

    void aggresiveAction() {
        if (distance > radioAtaque)
        {
            anima.SetFloat("Velocidad", speed);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
            //gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (distance <= radioAtaque)
        {
            anima.SetBool("Ataca", true);
        }

    }

    public void SetSpeed(float sp) { this.speed=sp; }
    public float GetSpeed() { return this.speed; }

    public void SetRadioAtaque(float r) { this.radioAtaque = r; }
    public float GetRadioAtaque() { return this.radioAtaque; }

    public void SetObjetivo(GameObject ob) { this.objeto = ob; }
    public GameObject GetObjetivo() { return this.objeto; }

    public void playerSighted(GameObject player) {
        this.aggresiveMode = true;
        this.target = player;

      
    }
    public void playerLost(GameObject player)
    {
        this.aggresiveMode = false;
        this.target = null;
    }

    public void OnTriggerEnter2D(Collider2D colision)
    {
            objeto = colision.gameObject;
    }

}