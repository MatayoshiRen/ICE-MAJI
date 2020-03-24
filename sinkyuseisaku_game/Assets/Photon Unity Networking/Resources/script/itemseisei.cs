using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemseisei : MonoBehaviour
{
    public GameObject[] items= new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("itemcharge", 0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void itemcharge()
    {
        Instantiate(items[Random.Range(0, 3)],transform.position, Quaternion.identity);
    }
}
