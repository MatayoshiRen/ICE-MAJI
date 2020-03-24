using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    public int speed = 10;
    public GameObject playerpos;
    public Transform Playerpos;
    public GameObject oya;
    // Start is called before the first frame update
    void Start()
    {

        oya = transform.root.gameObject;
        //playerpos = GameObject.Find("Playerplayer");
       // Playerpos = playerpos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * 3 * Time.deltaTime;
        transform.position = oya.transform.position;
        transform.Rotate(0, x, 0);
        //transform.position = Playerpos.transform.position;
    }

    }
