using UnityEngine;
using System.Collections;

public class EnergySphereScript : MonoBehaviour {
    float damage = 1.0f;
    float delay = 0.3f;
    float lastDamageTime = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time >= lastDamageTime + delay)
        {
            other.gameObject.GetComponent<HPManager>().doDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}
