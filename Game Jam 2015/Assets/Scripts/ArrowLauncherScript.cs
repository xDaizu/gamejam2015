using UnityEngine;
using System.Collections;

public class ArrowLauncherScript : MonoBehaviour
{

    private float timeLastShot;
    public float shootPeriod;
    GameManager gameManager;
    public GameObject arrow;
    public Vector2 shootDirection;
    // Use this for initialization
    void Start()
    {
        GameManager gameManager = GameManager.instance;
        timeLastShot = 0f;
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        //TODO: Get flecha del pool.
        arrow.transform.position=new Vector3(0, 0, 0);
        arrow.GetComponent<Rigidbody2D>().velocity = shootDirection;
        this.timeLastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeLastShot + shootPeriod)
        {
            this.Shoot();

        }
    }
}
