using UnityEngine;
using System.Collections;

public class DoorOpenScript : MonoBehaviour {


	// Update is called once per frame
	bool FixedUpdate () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyWrapper");
        foreach (GameObject enemy in enemies) {
            if (enemy.active)
            {
                return false;
            }
        }

        gameObject.SetActive(false);
        return true;
	}
}
