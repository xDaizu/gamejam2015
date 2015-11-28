using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject objeto;
    public float vel = 3.0f;
    public float maxX, maxY, minX, minY;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x < maxX && gameObject.transform.position.x > minX)
        {
            if (gameObject.transform.position.y < maxY && gameObject.transform.position.y > minY)
            {
                gameObject.transform.position = Vector3.Lerp(
                                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),
                                new Vector3(objeto.transform.position.x, objeto.transform.position.y, -5),
                                vel);
            }
        }
    }

    public float GetVel() { return this.vel; }
    public void SetVel(float nvel) { this.vel = nvel; }

    public float GetMaxX() { return this.maxX; }
    public void SetMaxX(float maxX) { this.maxX = maxX; }
    public float GetMaxY() { return this.maxY; }
    public void SetMaxY(float maxY) { this.maxY = maxY; }
    public float GetMinX() { return this.minX; }
    public void SetMinX(float minX) { this.minX = minX; }
    public float GetMinY() { return this.minY; }
    public void SetMinY(float minY) { this.minY = minY; }
}
