
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ball : Photon.MonoBehaviour
{
    Vector3 mytrans;
    Vector3 networkpos;
    Quaternion networkRot;
    public int pointcounter;
    public int P1pointstatus, P2pointstatus;
    public AudioClip Gooool;
    public string p1, p2;
    public Text point1, point2;
    private Rigidbody rb;
    private PhotonView photonView;
    private PhotonTransformView photonTransformView;
    AudioSource audiose;
    bool count = false;
    float Count = 0;
    bool ground = true;
    bool player1;

    float power = 10,power2 = 10;

    GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiose = GetComponent<AudioSource>();
        photonTransformView = GetComponent<PhotonTransformView>();
        photonView = PhotonView.Get(this);
        mytrans = this.transform.position;
   
        P1pointstatus = 0;//1Pの得点の初期化
        P2pointstatus = 0;//2Pの得点初期化
        point1.text = "0";
        point2.text = "0";
    }

    private void Update()
    {
        if (count) Count += Time.deltaTime;
        else Count = 0;

    }

    public void OnTriggerEnter(Collider col)
    {
            switch (col.tag)
            {
                case "goalP1":
                    audiose.PlayOneShot(Gooool);
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    pointcounter++;
                    P1pointstatus = P1pointstatus + pointcounter;
                    photonView.RPC("gooolsame", PhotonTargets.All);
                    this.transform.position = mytrans;
                    if (P1pointstatus == 2)
                    {
                        SceneManager.LoadScene("2PWin");
                        Debug.Log("p1勝ち！");
                    }
                    break;
                case "goalP2":
                    audiose.PlayOneShot(Gooool);
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    pointcounter++;
                    P2pointstatus = P2pointstatus + pointcounter;
                    photonView.RPC("gooolsame", PhotonTargets.All);
                    this.transform.position = mytrans;
                    if (P2pointstatus == 2)
                    {
                        SceneManager.LoadScene("1PWin");
                        Debug.Log("p2勝ち！");
                    }
                    break;
        }
        
        pointcounter = 0;

    }
  
    [PunRPC]
    void gooolsame ()
    {
        p1 = P1pointstatus.ToString();
        point1.text = p1;
        p2 = P2pointstatus.ToString();
        point2.text = p2;
    }

    [PunRPC]
    void push ()
    {
        if (player1)
        {
            
            var impulse = (player.transform.position - transform.position).normalized * power;
            rb.AddForce(-impulse, ForceMode.VelocityChange);
        }
        else
        {
            
            var impulse = (player.transform.position - transform.position).normalized * power2;
            rb.AddForce(-impulse, ForceMode.VelocityChange);
        }
            
    }
    //Playerからpowerの値を受け取り
    public void playerstatu (float playerpower)
    {
        power = playerpower;
    }
    //Player2からpowerの値を受け取り
    public void playerstatu2 (float playerpower2)
    {
        power2 = playerpower2;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(this.P1pointstatus);
            stream.SendNext(this.P2pointstatus);
           /* stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
            stream.SendNext(rb.velocity);*/

        }
        else
        {
            //データの受信
            this.P1pointstatus = (int)stream.ReceiveNext();
            this.P2pointstatus = (int)stream.ReceiveNext();
           /* networkpos = (Vector3)stream.ReceiveNext();
            networkRot = (Quaternion)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.time - info.timestamp));
            networkpos += rb.velocity * lag;*/
            
            photonView.RPC("gooolsame", PhotonTargets.All);
        }
    }

    void OnCollisionEnter(Collision col)//名前でプレイや１か２かを判断してplayerのpowerの分だけ飛ぶ
    {
        if (col.gameObject.tag == "Player1")
        {
            player = col.gameObject;
            player1 = true;
            photonView.RPC("push", PhotonTargets.All);
            //Debug.Log("1");
        }else if(col.gameObject.tag == "Player2")
        {
            player = col.gameObject;
            player1 = false;
            photonView.RPC("push", PhotonTargets.All);
            //Debug.Log("2");
        }
            
    }
     /*IEnumerator StopRb ()
    {
        yield return new WaitForSeconds(10);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }*/

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Reset") this.transform.position = mytrans;
    }

    

}

