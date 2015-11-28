using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KawaiiGhostScript : MonoBehaviour {
    
    public bool goingUp;
    public float amplitude;
    public float frequency;
    public float velocity;
    public int movingLeft;

    public void Start(){
        movingLeft = 1;
    }

    public void Update() {
        hover();
    }
    public void hoverStill() {
        
        gameObject.transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
    }

    public void hover()
    {
        float y = transform.localPosition.y + amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime)));
        float x = transform.localPosition.x - (movingLeft * velocity * Time.deltaTime);
        //gameObject.transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
        transform.localPosition = new Vector3(x, y, gameObject.transform.position.z);
        if ((movingLeft < 0 && x >= 400) || (movingLeft > 0 && x<=-400)) {
            movingLeft = -(movingLeft);
        }
        transform.localScale = new Vector2(movingLeft * Mathf.Abs(transform.localScale.x), transform.localScale.y);

    }
}
