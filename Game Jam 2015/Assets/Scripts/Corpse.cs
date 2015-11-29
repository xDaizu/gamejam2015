using UnityEngine;
using System.Collections;

public class Corpse : MonoBehaviour {

    GameObject objeto;
    private string targ;

    public void start()
    {
        targ = gameObject.tag.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerWrapper") {
            Destruir();
        }
    }
    public void Destruir()
    {
        objeto = GameObject.Find(targ);
        Destroy(this.gameObject, (float) 0.5);
    }

}
