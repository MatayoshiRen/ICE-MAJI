using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    GameObject Player;
    public GameObject cam;
    Vector3 camerapos;
    // Start is called before the first frame update
    void Start()
    {
       Player = Instantiate(Player,new Vector3(0,2,0), Quaternion.identity);
    }

    // Update is called once per frame
   public void Update()
    {
        cam.transform.position += Player.transform.position - camerapos;
        camerapos = Player.transform.position;

        //cam.transform.position = kara.transform.localPosition + camerapos;
        //kara.transform.position = Player.transform.position;
        float x = Input.GetAxis("Horizontal");
        
        cam.transform.RotateAround(Player.transform.position, Vector3.up, x);
    }
}
