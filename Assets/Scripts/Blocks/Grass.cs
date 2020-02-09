using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public List<GameObject> objectList;
    [Range(1, 150)]
    public float amountOfObjects;
    void Start()
    {
        int rand = Random.Range(1, (int)(1000 - amountOfObjects - 850));
        if(rand == 1)
        {
            GameObject gog = objectList[Random.Range(1, objectList.Count)];
            GameObject go = Instantiate(gog, this.transform.position, Quaternion.identity);
            go.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
