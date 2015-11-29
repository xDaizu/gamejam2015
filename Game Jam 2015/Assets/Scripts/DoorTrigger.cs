using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public GameObject exitDoor;

    private static bool justTP;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Door OnTriggerEnter2D, name="+other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            Vector3 TargetPoint = exitDoor.transform.Find("SpawnPoint").gameObject.transform.position;
            Debug.Log("Tag Player detectado, moviendo a x=" + TargetPoint.x + ", y= " + TargetPoint.y);
            GameObject playerToMove = GameObject.FindGameObjectWithTag("PlayerWrapper");

            playerToMove.SetActive(false);
            playerToMove.transform.position = TargetPoint;
            // yield return new WaitForSeconds(0.01f);
            playerToMove.SetActive(true);

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Door OnTriggerLeave");
        if (other.gameObject.tag == "Player")
        {

        }
    }

}
