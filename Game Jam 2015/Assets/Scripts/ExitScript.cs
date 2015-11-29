using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if (other.tag == "Player") {
            Application.LoadLevel(0);
        }
    }
}
