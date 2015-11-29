using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour {

    Animator animator;
    public GameObject corpse;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
    }

    public float HP = 5f;

    public void doDamage(float damage) {

        Debug.Log("ENEMY: 'ARGH!' Time: " + Time.time);

        HP -= damage;
        animator.SetBool("RecibeDamage", true);

        if (HP < 0) {
            gameObject.SetActive(false);
            corpse.SetActive(true);
        }
    }
}
