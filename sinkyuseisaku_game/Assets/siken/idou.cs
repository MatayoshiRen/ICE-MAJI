using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class idou : MonoBehaviour
{
    [SerializeField] private GameObject Cam;//カメラの向きをとる用
    [SerializeField] int reaction;//反動の値
    [SerializeField] int limitspeed;//限界速度
    [SerializeField] int limitspeed_iv;//限界速度の初期値代入用    
    [SerializeField] float speed_iv;//速度の初期値代入用
    [SerializeField] int power_iv;//力の初期値
    [SerializeField] int reaction_iv;//反動の初期値
    [SerializeField] GameObject text;
    new Vector3 a;
    Rigidbody rb;
    Rigidbody Rb;
    GameObject ball;
    float speed;//移動速度
    int power;//力
    int count = 1;
    int bottoncoutn;
    string statucount;
    // Start is called before the first frame update
    [SerializeField] GameObject type;//ステータス判定
    void Start()
    {
        Text type_text = type.GetComponent<Text>();
        type_text.text = "ぱわー";
        speed = 20f;
        power = 10;
        speed_iv = speed;
        limitspeed = 5;
        limitspeed = limitspeed_iv;
        reaction = 100 * 3;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.J))//反動軽減
         {
             reaction = reaction + 100;
         }
         if (Input.GetKeyDown(KeyCode.K))//反動軽減
         {
             reaction = reaction - 100;
         }
             if (Input.GetKeyDown(KeyCode.U))//速度上昇
         {
             speed = speed + 5;
             limitspeed = limitspeed + 2;
         }
         if (Input.GetKeyDown(KeyCode.I))//速度上昇
         {
             speed = speed - 5;
             limitspeed = limitspeed - 2;
         }
             if (Input.GetKeyDown(KeyCode.N))//力上昇（予定）
         {
             power = power + 20;
         }
         if (Input.GetKeyDown(KeyCode.M))//力上昇（予定）
         {
             power = power - 20;
         }
         if (Input.GetKeyDown(KeyCode.P))
         {
             power = power_iv;
             speed = speed_iv;
             reaction = reaction_iv;
             limitspeed = limitspeed_iv;

         }
         if (Input.GetKeyDown(KeyCode.Q))
         {
             Debug.Log("オールステータス"+"\n"+
                     "力      :"+power+"\n"+
                     "速さ    :"+speed+"\n"+
                     "反動    :"+reaction+"\n"+
                     "限界速度:"+limitspeed+"\n");
         }*/
        switch (Input.GetKey("left shift"))
        {
            case true:
                speed = speed_iv * 10;
                //Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                break;

            default:
                speed = speed_iv;
                break;
        }
        if (reaction <= 0) { reaction = 50; }
        //if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))) { 
        if (rb.velocity.magnitude <= limitspeed)
        {
            float z = Input.GetAxis("Vertical") * speed;
            Vector3 cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
            rb.AddForce(z * cameraForward * speed, ForceMode.Force);

        }
        // }


    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            //ボールに触れた時の処理
            case "ball":
                Vector3 cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
                ball = collision.gameObject;
                Rb = ball.GetComponent<Rigidbody>();
                Rb.AddForce(cameraForward * power, ForceMode.Force);
                Rb.AddForce(new Vector3(0, power / 2, 0), ForceMode.Force);
                rb.AddForce(cameraForward * -reaction, ForceMode.Force);//反動を加える
                rb.AddForce(new Vector3(0, 250, 0), ForceMode.Force);//反動を加える
                break;
        }
    }
    public void Changestatus()
    {
        switch (count) {
            case 0:
        Text type_text = type.GetComponent<Text>();
        type_text.text ="ぱわー" ;
                statucount = "ぱわー";
                break;
            case 1:
                type_text = type.GetComponent<Text>();
                type_text.text = "すぴど";
                statucount = "すぴど";
                break;
            case 2:
                type_text = type.GetComponent<Text>();
                type_text.text = "はんど";
                statucount = "はんど";
                break;
        }
        count++;
        
    }
    public void plusdowncount()
    {
        Debug.Log(power);
        switch (transform.name)
        {
            case "plus":
                bottoncoutn++;
                break;
            case "down":
                bottoncoutn--;
                break;
        }
        switch (statucount)
        {
            case "ぱわー":
                power = power+(bottoncoutn*10);
                //Debug.Log(power);
                break;
            case "すぴど":
                speed = speed + (bottoncoutn*10);
                break;
            case "はんど":
                reaction = reaction + (bottoncoutn*10);
                break;
        }
        Text statusall = text.GetComponent<Text>();
        statusall.text = "力" + power + "\n" + "速" + power + "\n" + "重" + power + "\n";
        if (count>=3) { count = 0; }
        bottoncoutn = 0;
    }
  /*  public void powerup()
    {
        switch (transform.name)
        {
            case "puls":
                power = power + 20;
                break;
            case "down":
                power = power + 20;
                break;
        }*/
    }


