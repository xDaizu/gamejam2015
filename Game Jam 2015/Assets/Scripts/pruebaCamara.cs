using UnityEngine;
using System.Collections;

public class pruebaCamara : MonoBehaviour {

    public GameObject[] posiciones = new GameObject[2];
    public float speed = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            //   gameObject.transform.position = posiciones[0].transform.position;
            print(gameObject.transform.position.x + " " + gameObject.transform.position.y + " " + gameObject.transform.position.z + " ");
            print(posiciones[0].transform.position.x + " " + posiciones[0].transform.position.y + " " + posiciones[0].transform.position.z + " ");
            gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(posiciones[0].transform.position.x, posiciones[0].transform.position.y, posiciones[0].transform.position.z), speed * Time.deltaTime);
        }
	
	}
}
