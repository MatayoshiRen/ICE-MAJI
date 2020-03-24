using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string[] itemlist = new string[3];
    public GameObject player;//空のプレイヤー
    public GameObject Cam;
    public float speed;
    public float RotSpeed = 50;
    public float Runspeed = 5;
    public float Nockback = 30;//ボールを蹴ったときの反動
    private Quaternion gyro;
    public string itempoint;//アイテムの種類を判別するやつ
    //int Heavy;//時機の重さs
    public int powerpoint;
    public int speedpoint;
    public int defensepoint;
    public float powertyann = 10;
    public GameObject [] ItemIcon;
    public GameObject Speedvar;
    public GameObject color;
    public Sprite my_color;
    public Image SpeedV;
    public Image[] itemicon;
    public Sprite Power;
    public Sprite Speed;
    public Sprite Defense;
    public AudioClip kick,PowerUp;
    bool ground = false;
    [SerializeField] bool player1;
    [SerializeField] float maxspeed = 10;

    Text status;
    PhysicMaterial bounce;
    Rigidbody  playerRb;
    Rigidbody Rb;
    AudioSource audiose;
    Vector3 cameraForward;
    Vector3 startpos;

    GameObject ball;

    PhotonView myPhotonView;
    private PhotonTransformView photonTransformView;
    int count;
    void Start()
    {
        this.myPhotonView = GetComponent<PhotonView>();
        if (this.myPhotonView.isMine)
        {
            ball = GameObject.Find("ball");
            startpos = gameObject.transform.position;//初期位置
            color = GameObject.Find("mycolor");
            Image Mycolor = color.GetComponent<Image>();
            Mycolor.sprite = my_color;
            Cam = GameObject.Find("Camera");
            playerRb = GetComponent<Rigidbody>();
            audiose = GetComponent<AudioSource>();

            //status = GameObject.Find("magnitude").GetComponent<Text>();

            this.myPhotonView = GetComponent<PhotonView>();
            playerRb = this.gameObject.GetComponent<Rigidbody>();
            speed = 50;
            ItemIcon[0] = GameObject.Find("ItemIcon1");
            ItemIcon[1] = GameObject.Find("ItemIcon2");
            ItemIcon[2] = GameObject.Find("ItemIcon3");

            itemicon[0] = ItemIcon[0].GetComponent<Image>();
            itemicon[1] = ItemIcon[1].GetComponent<Image>();
            itemicon[2] = ItemIcon[2].GetComponent<Image>();
            Speedvar = GameObject.Find("speedvar");
            SpeedV = Speedvar.GetComponent<Image>();
        }
    }
    void Update()
    {
        
        // if (this.myPhotonView.isMine)
        // {
        //   // float x = Input.GetAxis("Horizontal") * speed *3* Time.deltaTime;
        //    float z = Input.GetAxis("Vertical");
        //     //player.transform.Rotate(0, x * speed * Time.deltaTime, 0);//カメラ左右回転
        /*********プレイヤー移動***********/
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        //    Vector3 cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //   // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        //   if (Mathf.Abs(z) <= 0.2 && !ground)
        //   {
        //       playerRb.velocity = new Vector3(0, -10, 0);
        //playerRb.angularVelocity = new Vector3(0, 1, 0);
        //   }else if(Mathf.Abs(z) <= 0.2 && ground)
        //   {
        //      playerRb.velocity = new Vector3(0, 0, 0);
        //playerRb.angularVelocity = new Vector3(0, 1, 0);
        //  }
        //   else playerRb.AddForce(z * cameraForward * 10 * speed * Time.deltaTime, ForceMode.Force);
        //   SpeedV.fillAmount = playerRb.velocity.magnitude / maxspeed;
        //Debug.Log(playerRb.velocity);
        /*********ここまで***********/
        //  }
        // transform.Translate(0,0,z);
        // transform.Rotate(0,x,0);
        //playerRb.AddForce(x, 0, z);

        /* Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;
         //移動速度を指定
         photonTransformView.SetSynchronizedValues(velocity, 0);*/
        if (this.myPhotonView.isMine)
        {
            if (playerRb.velocity.magnitude <= maxspeed)
            {
                cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
                float y = Input.acceleration.y;//Y軸の加速度
                //float y = Input.GetAxis("Vertical");
                float z = y * 2;
                if (Mathf.Abs(y) <= 0.1 && !ground)
                {
                    playerRb.velocity = new Vector3(0, -10, 0);
                }
                else if (Mathf.Abs(y) <= 0.1 && ground)
                {
                    playerRb.velocity = new Vector3(0, 0, 0);
                }
                else playerRb.AddForce(z * cameraForward *700 * Time.deltaTime, ForceMode.Force);
                SpeedV.fillAmount = playerRb.velocity.magnitude / maxspeed;
            }
            //status.text = "speed" + playerRb.velocity.magnitude;
        }
        else return;
    }
    public void itemcount()
    {
        audiose.PlayOneShot(PowerUp);
        int power01 = itemlist.Count(value => value.IndexOf("power") >= 0);
        int speed01 = itemlist.Count(value => value.IndexOf("speed") >= 0);
        int defense01 = itemlist.Count(value => value.IndexOf("defense") >= 0);
        powertyann = 10 + (power01 * 5) ;
        maxspeed = 10 + (speed01 * 2.5f);
        Nockback = 30 - (defense01* 5) + (speed01 * 5) ;

        
        if (player1)ball.GetComponent<ball>().playerstatu(powertyann/*power01 * 2*/);
        else if(!player1) ball.GetComponent<ball>().playerstatu2(powertyann/*power01 * 2*/);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (this.myPhotonView.isMine)
        {
            switch (col.gameObject.tag)
            {
                case "power":
                    itempoint = "power";
                    itemlist[count] = itempoint;
                    itemcount();
                    if (this.myPhotonView.isMine)
                    {
                        itemicon[count].sprite = Power;
                    }
                    Debug.Log("itempoint : " + itempoint);
                    Debug.Log("itemlist[count] : " + itemlist[count]);
                    count++;
                    Destroy(col.gameObject);
                    break;
                case "speed":
                    itempoint = "speed";
                    itemlist[count] = itempoint;
                    itemcount();
                    if (this.myPhotonView.isMine)
                    {
                        itemicon[count].sprite = Speed;
                    }
                    // Debug.Log(itemicon[count]);
                    count++;
                    Destroy(col.gameObject);
                    break;
                case "defense":
                    itempoint = "defense";
                    itemlist[count] = itempoint;
                    itemcount();
                    if (this.myPhotonView.isMine)
                    {
                        itemicon[count].sprite = Defense;
                    }
                    //Debug.Log(itemicon[count]);
                    count++;
                    Destroy(col.gameObject);
                    break;
                default:
                    break;
            }
            if (count == 3)
            {
                count = 0;
            }
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Reset") this.transform.position = startpos;
    }

    public void OnCollisionEnter(Collision col)
    {

            switch (col.gameObject.tag)
            {
                //ボールに触れた時の処理
                case "ball":
                myPhotonView.RequestOwnership();
                audiose.PlayOneShot(kick);
                    ball = col.gameObject;
                   var rigid = col.gameObject.GetComponent<Rigidbody>();
                    //var impulse = (rigid.position - transform.position).normalized * powertyann * 5;
                    var handou = (rigid.position - transform.position).normalized * Nockback;
                    // 衝突相手の座標から回転中心の座標(頭部から見てハンマー本体は親なので、transform.parent.positionで親の位置をとる)を引き、正規化してimpulseMagnitudeをかける
                    // ※衝突相手とハンマーはどちらもシーンの一番上層にあるので、それらの座標がそのままワールド座標になる
                    //rigid.AddForce(impulse, ForceMode.VelocityChange);
                    /*Rb = ball.GetComponent<Rigidbody>();
                    Transform balltransform = ball.transform;*/
                    /*Rb.AddForce(cameraForward * 500 * powertyann, ForceMode.Force);
                    Rb.AddForce(new Vector3(0, 2000 / 2, 0), ForceMode.Force);*/

                    //ボールの位置+プレイヤーの正面で蹴るような処理を実現
                    /* Vector3 ballpos = balltransform.position + this.transform.forward * (500 * powertyann);//ステータス変えるとこ1
                     Rb.AddForce(ballpos, ForceMode.Force);
                     Rb.AddForce(new Vector3(0, 2000 / 2, 0), ForceMode.Force);*/

                    /*ボールをけったときに受ける反動*/
                    playerRb.AddForce(-handou/*-impulse*/, ForceMode.Impulse);
                
                //Debug.Log(rigid.velocity.magnitude);
                //playerRb.AddForce(cameraForward * -Nockback * 10, ForceMode.Force);//反動を加える
                // playerRb.AddForce(new Vector3(0, 250, 0), ForceMode.Force);//反動を加える
                //Vector3 mypos = this.transform.position + transform.forward * -Nockback;//変えるとこ2
                //playerRb.AddForce(mypos, ForceMode.Impulse);
                break;
            }
            
    }
   public void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "ground") ground = true;
    }
   public void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "ground") ground = false;
    }
}
