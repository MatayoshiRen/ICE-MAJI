using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    Transform cameraTrans;
    GameObject Player;
    [SerializeField] Transform playerTrans;
    [SerializeField] Vector3 cameraVec;  //Vector3(0, 1, -1)
    [SerializeField] Vector3 cameraRot;  //Vector3(45, 0, 0)
    void Awake()
    {
            cameraTrans = transform;
            cameraTrans.rotation = Quaternion.Euler(cameraRot);
            Player = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        cameraTrans.position = Vector3.Lerp(cameraTrans.position, playerTrans.position + cameraVec, 2f * Time.deltaTime);//追従
        this.transform.LookAt(Player.transform);
    }

}
