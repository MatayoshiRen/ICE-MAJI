using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody Rb;
    GameObject Cam;
    int speed = 20;
    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        Rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
                                                                  /*********プレイヤー移動***********/
                                                                  // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        Rb.AddForce(z * cameraForward * 5, ForceMode.Force);
    }
}
