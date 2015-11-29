using UnityEngine;
using System.Collections;

public class GhostChanges : MonoBehaviour {
    public Animator anima;
    // Use this for initialization
    void Start () {
             anima=gameObject.GetComponent<Animator>();
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
}
