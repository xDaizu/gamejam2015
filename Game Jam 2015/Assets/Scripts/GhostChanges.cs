using UnityEngine;
using System.Collections;

public class GhostChanges : MonoBehaviour {
    private string state;
    public Animator anima;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetState(int newState) {
        switch(newState)
        {
            case 0:
                state = "Ghost";
                break;
            case 1:
                state = "Sword";
                break;
            case 2:
                state = "Shield";
                break;
            case 4:
                state = "Goblin";
                break;
            default:
                Debug.Log("NO PODEMOS CAMBIAR LA VARIABLE DE CONTROL DE CAMBIO");
                break;
        }
    }

    public void ChangeAnimation() {
        switch (state)
        {
            case "Ghost":
                //gameObject.GetComponent<Animator>().
                break;
            case "Sword":
                
                break;
            case "Shield":
                
                break;
            case "Goblin":
                
                break;
            default:
                Debug.Log("NO HEMOS REALIZADO LA ACCION DE CAMBIO");
                break;
        }

    }

}
