using UnityEngine;
using System.Collections;

public class Posesion : MonoBehaviour {

    private GameObject selectedCorpse;
    public int corpseType;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CorpseGoblin") {
            this.selectedCorpse = other.gameObject;
            this.corpseType = 3;
        }
        if (other.tag == "CorpseShield")
        {
            this.corpseType = 1;
            this.selectedCorpse = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CorpseGoblin")
        {
            this.corpseType = 0;
        }
        if (other.tag == "CorpseShield")
        {
            this.corpseType = 0;
        }
    }

    public void Poseer()
    {
        int formaActual = gameObject.GetComponent<GhostChanges>().GetForma();
        if (formaActual == 0 && corpseType != 0)
        {
            gameObject.GetComponent<GhostChanges>().SetState(corpseType);
            selectedCorpse.SetActive(false);
        }
    }

    public void Desposeer()
    {
        int formaActual = gameObject.GetComponent<GhostChanges>().GetForma();
        if (formaActual != 0)
        {
            gameObject.GetComponent<GhostChanges>().SetState(0);
        }
    }

    public int GetCorpse() { return corpseType; }
}
