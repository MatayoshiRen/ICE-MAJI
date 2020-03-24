using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcamera : MonoBehaviour
{
    //public GameObject cam; // 玉のオブジェクト
                              //private Vector3 offset; // 玉からカメラまでの距離
    public GameObject Camerapos;
    public GameObject playerpos;
    private List<GameObject> pos = new List<GameObject>();
    void Start()
    {
        Camerapos = GameObject.Find("Playerkara");
        playerpos = GameObject.Find("Campos");
        pos.Add(Camerapos);
        pos.Add(playerpos);
      //  offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = pos[1].transform.position;
       // transform.position = Camerapos.position;
        transform.LookAt(pos[0].transform.position);
    
    }
}