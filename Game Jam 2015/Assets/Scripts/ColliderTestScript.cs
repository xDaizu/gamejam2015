using UnityEngine;
using System.Collections;



public class ColliderTestScript : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public bool scriptActivado;
    public string scriptTag;
    public Enemy enemyScript;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            float x, y, z;
            GameObject player = other.gameObject;
            x = player.transform.position.x + transform.position.x;
            y = player.transform.position.y + transform.position.y;
            //z = player.transform.position.z + transform.position.z;
            Vector3 coordinates = new Vector3(x,y,0f);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                Quaternion.LookRotation(coordinates),
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
