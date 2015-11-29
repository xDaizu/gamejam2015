using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float distance, radioAtaque;
    public Animator anima;
    private string behaviourMode;
    private GameObject target = null;



    GameObject visionField;
    VisionScript visionFieldScript;

    private float searchFinishTime;
    private float accumulatedRotation;
    public int searchTime = 3;
    public float searchMaxAngle = 15;
    public int searchRotateDirection = 1;
    public float searchSpeed = 10f;

    // Use this for initialization
    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
        visionField = gameObject.transform.Find("Vision").gameObject;
        visionFieldScript = visionField.GetComponent<VisionScript>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (behaviourMode)
        {
            case "aggresive":
                aggresiveAction();
                break;
            case "search":
                searchAction();
                break;
            case "idle":
            default:
                idleAction();
                break;
        }

    }

    void idleAction()
    {

    }

    void searchInitAction() {
        accumulatedRotation = 0f;
        this.searchFinishTime = Time.time + this.searchTime;
        this.behaviourMode = "search";
        Debug.Log("ENEMIGO: 'Searching....'");
    }

    void searchAction()
    {

        if (Time.time > this.searchFinishTime)
        {
            Debug.Log("ENEMIGO: 'Meh, he's gone...'");
            this.behaviourMode = "idle";
        }
        else {
            float incrementAngle = searchRotateDirection * searchSpeed * Time.deltaTime;
            this.accumulatedRotation += incrementAngle;

            if (Mathf.Abs(accumulatedRotation) > searchMaxAngle) {
                searchRotateDirection = searchRotateDirection * -1;
            }
            //Debug.Log("ENEMIGO: 'Searching....'  AngleIncrement: "+incrementAngle+" Time:" + Time.time);
            visionFieldScript.incrementRotation(incrementAngle);
        }

    }

    void aggresiveAction()
    {

        distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        anima.SetFloat("Velocidad", speed);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);



    }

    public void SetSpeed(float sp) { this.speed = sp; }
    public float GetSpeed() { return this.speed; }

    public void SetRadioAtaque(float r) { this.radioAtaque = r; }
    public float GetRadioAtaque() { return this.radioAtaque; }

    public void SetObjetivo(GameObject ob) { this.target = ob; }
    public GameObject GetObjetivo() { return this.target; }

    public void playerSighted(GameObject player)
    {
        Debug.Log("ENEMIGO: 'I can see you!!'");
        this.behaviourMode = "aggresive";
        this.target = player;
    }

    public void playerSighting(GameObject player)
    {
        Debug.Log("ENEMIGO: 'I'm seeing you!!'   Time:" + Time.time);
        this.behaviourMode = "aggresive";
        this.target = player;
    }
    public void playerLost(GameObject player)
    {
        Debug.Log("ENEMIGO: 'Where are you?!'");
        this.target = null;
        searchInitAction();

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;
    }

}