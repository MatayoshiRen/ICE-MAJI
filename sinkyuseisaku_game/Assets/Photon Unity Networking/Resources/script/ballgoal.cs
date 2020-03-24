using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballgoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "ball":
                Destroy(col.gameObject);
                Debug.Log("ｺﾞｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵｵﾙ");
                break;
        }
    }
}
