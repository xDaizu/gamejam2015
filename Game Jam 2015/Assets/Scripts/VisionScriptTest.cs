﻿using UnityEngine;
using System.Collections;



public class VisionScriptTest : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool scriptActivado;
    public string scriptTag;

    public enum FacingDirection
    {
        UP = 270,
        DOWN = 90,
        LEFT = 180,
        RIGHT = 0
    }

    public void faceObject(Vector3 targetPosition)
    {
        Vector3 v_diff;
        float atan2;

        v_diff = (targetPosition - transform.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) + 90);
    }

    public void incrementRotation(float angleIncrement)
    {
        transform.Rotate(0f, 0f, angleIncrement);
    }

    public Quaternion getRotation()
    {
        return transform.rotation;
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerStay2D");
            GameObject player = other.gameObject;

            Transform target = player.transform;
            this.faceObject(player.transform.position);
        
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter2D");
        
            GameObject player = other.gameObject;
        
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerExit2D");

            GameObject player = other.gameObject;
        }
    }

    public void GetSpeedRotation(float speed) { this.rotationSpeed = speed; }
    public float SetSpeedRotation() { return rotationSpeed; }
}
