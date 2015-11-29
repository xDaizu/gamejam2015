using UnityEngine;
using System.Collections;

public class ArrowLauncherScript : MonoBehaviour
{

    private float timeLastShot;
    public float shootPeriod;
    GameManager gameManager;
    ObjectPooler objectPooler;


    public Vector2 shootDirection;
    // Use this for initialization
    void Start()
    {
        gameManager = GameManager.instance;
        ObjectPooler objectPooler = gameManager.gameObject.GetComponent<ObjectPooler>();
        timeLastShot = 0f;
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        //TODO: Get flecha del pool.
        GameObject arrow = objectPooler.getArrow();
        arrow.transform.position = new Vector3(0, 0, 0);
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
