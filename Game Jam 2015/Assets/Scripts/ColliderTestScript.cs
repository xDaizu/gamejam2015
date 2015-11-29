using UnityEngine;
using System.Collections;



public class ColliderTestScript : MonoBehaviour
{

    public bool scriptActivado;
    public string scriptTag;
    public Enemy enemyScript;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (scriptActivado)
            Debug.Log("Trigger enter de " + scriptTag);

        //enemyObject = transform.parent.gameObject;

        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            enemyScript.playerSighted(player);
        }
    }
    public void OnTriggerLeave2D(Collider2D other)
    {
        if (scriptActivado)
            Debug.Log("Trigger enter de " + scriptTag);

        //enemyObject = transform.parent.gameObject;

        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            enemyScript.playerLost(player);
        }
    }
}
