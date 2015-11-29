using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
    public GameObject exitDoor;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Movemos cámara a destino

            // Teletransportamos muñeco
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = exitDoor.transform.position;
            other.gameObject.SetActive(true);
        }
    }
}
