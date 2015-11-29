using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public GameObject arrowPrefab;
    public int initialPooledArrowAmount;

    List<GameObject> pooledArrows;

    // Use this for initialization
    void Start()
    {
        pooledArrows = new List<GameObject>();
        addArrows(initialPooledArrowAmount);
    }

    public GameObject addArrows(int amount)
    {
        GameObject obj = null;
        for (int i = 0; i < amount; i++)
        {
            obj = (GameObject)Instantiate(arrowPrefab);
            obj.SetActive(false);
            pooledArrows.Add(obj);
        }

        return obj;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject getArrow()
    {
        for (int i = 0; i < pooledArrows.Count; i++)
        {
            if (!pooledArrows[i].activeInHierarchy)
            {
                return pooledArrows[i];
            }


        }
        return this.addArrows(1);

    }
}
