using UnityEngine;
using System.Collections;



public class ColliderTestScript : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool scriptActivado;
    public string scriptTag;
    public Enemy enemyScript;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            transform.rotation = Quaternion.Slerp(
                                                transform.rotation, 
                                                Quaternion.LookRotation(new Vector3(player.transform.position.x - transform.position.x,
                                                                                    player.transform.position.y - transform.position.y,
                                                                                    player.transform.position.z - transform.position.z
                                                                                    )
                                                                        ),
                                                rotationSpeed * Time.deltaTime);

        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            enemyScript.playerSighted(player);
        }
 
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            enemyScript.playerLost(player);
        }
    }

    public void GetSpeedRotation(float speed) { this.rotationSpeed = speed; }
    public float SetSpeedRotation() { return rotationSpeed; }
}
