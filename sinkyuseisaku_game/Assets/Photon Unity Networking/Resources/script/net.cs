using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class net : MonoBehaviour
{
   public GameObject Player1, Player2, Player3, Camerabox, Camerabox2,PVcamera,ball,PVpleyercamera;
    Transform campos, campos2;
    public GameObject cam;
    public GameObject canvasactiv,PVcamera_Canvas;
    public GameObject cameraCanvas;
    public GameObject button, button2;
    public Text RotText;
    public Vector3 camerapos, camerapos2;
    Vector3 camepos, camepos2,PV_camerapos,PVstartpos;
    public int Rt = 10;
    int playerid;
    bool inplayer = false;
    string color = null;
    public Text roomtext;
    // public GameObject Camera1,Camera2;

    void Start()
    {
        canvasactiv.SetActive(true);
        PVcamera_Canvas.SetActive(true);
        Debug.Log("サーバへ接続");
        // サーバへ接続して、ロビーへ入室する
        PhotonNetwork.ConnectUsingSettings(null);
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 60;
        ball = GameObject.Find("ball");
        PV_camerapos.y = 50;
        roomtext.text = "";
    }
    public void Rotup()
    {
        Rt++;
    }

    public void Rotdown()
    {
        Rt--;
    }

    void Update()
    {
        //Camera1.transform.LookAt(Player2.transform);
        //Camera2.transform.LookAt(Player.transform);
        RotText.text = "カメラ感度 : " + Rt;
        float x = Input.acceleration.x * Rt;
        //float x = Input.GetAxis("Horizontal") * Rt;
        switch (playerid)
        {
            case 1:
                Camerabox.transform.position = Player1.transform.position/* - camepos*/;
                //camepos = Player.transform.position;
                Camerabox.transform.RotateAround(Player1.transform.position, Vector3.up, x);
                break;
            case 2:
                Camerabox2.transform.position = Player2.transform.position/* - camepos2*/;
                //camepos2 = Player2.transform.position;
                Camerabox2.transform.RotateAround(Player2.transform.position, Vector3.up, x);
                break;
        }
        /*switch(color)
        {
        
            case "ball":
                PV_camerapos.x = ball.transform.position.x;
                PV_camerapos.z = ball.transform.position.z;
                
                PVcamera.transform.position = PV_camerapos;
                break;

            case "null":
                PVcamera.transform.position = PVstartpos;
                break;

            case "red":
                PV_camerapos.x = Player1.transform.position.x;
                PV_camerapos.z = Player1.transform.position.z;
                PVcamera.transform.position = PV_camerapos;
                break;

            case "blue":
                PV_camerapos.x = Player2.transform.position.x;
                PV_camerapos.z = Player2.transform.position.z;
                PVcamera.transform.position = PV_camerapos;
                break;
        }*/
    }
    /*//観戦用レッド視点
    public void PV_BALL ()
    {
        color = "ball";
    }
    //観戦用上空視点
    public void PV_BACK()
    {
        color = "null";
    }

    public void PV_RED ()
    {
        color = "red";
    }
    public void PV_BLUE()
    {
        color = "blue";
    }
    */
    // ロビーへ入室すると呼び出される
    void OnJoinedLobby()
    {
        Debug.Log("ロビーへ入室しました");
        // どこかのルームへ接続
        if (!PhotonNetwork.inRoom)
        {
            PhotonNetwork.JoinRandomRoom();
            roomtext.text = "ルーム検索中・・・";
        }
    }
    /*public void joinedroom()
    {
        PhotonNetwork.JoinRandomRoom();
        button.SetActive(false);
        button2.SetActive(false);
        roomtext.text = "ルーム検索中・・・";
    }*/
   /* public void createroom()
    {

        PhotonNetwork.CreateRoom(null);
        button.SetActive(false);
        button2.SetActive(false);
        roomtext.text = "ルーム作成中・・・";
    }*/
    // ルームへ入室すると呼び出される
    void OnJoinedRoom()
    {
        Debug.Log("ルームへ入室しました");
        roomtext.text = "ルーム作成完了！";
            switch (PhotonNetwork.countOfPlayers)
            {

                case 2:
                    Debug.Log("2人目");
                    playerid = 2;
                    //matchText.text = "マッチングしました";
                    canvasactiv.SetActive(false);
                    PVcamera_Canvas.SetActive(false);
                    Player2 = PhotonNetwork.Instantiate("Playerplayer2", new Vector3(0, 10, -30), Quaternion.identity, 0) as GameObject;
                    Camerabox2 = PhotonNetwork.Instantiate("TEST2", new Vector3(0, 10, -30), Quaternion.identity, 0) as GameObject;
                    //campos2 = Player2.transform.Find("Campos2");
                    //playerkara2 = GameObject.Find(" playerkara2");
                    // GameObject playerkara2 = PhotonNetwork.Instantiate("Playerkara2", new Vector3(0, 10, -30), Quaternion.identity, 0);
                    Player2.GetComponent<Renderer>().material.color = Color.blue;
                    cam.transform.rotation = Quaternion.Euler(26, 0, 0);
                    cam.transform.position = Camerabox2.transform.position + camerapos2;
                    cam.transform.parent = Camerabox2.transform;
                    break;

                case 3:
                canvasactiv.SetActive(false);
                PVcamera_Canvas.SetActive(true);
                
                break;
            }
    }

    // ルームの入室へ失敗すると呼び出される
    void OnPhotonRandomJoinFailed()
    {
        roomtext.text = "ルームを作成中です";
        PhotonNetwork.CreateRoom(null);
        
    }
    void OnPhotonPlayerConnected(PhotonPlayer player)//ホスト時誰かが入室してきたタイミングでスポーンさせれば、同時スタートができる
    {
        if (PhotonNetwork.countOfPlayers == 1 && !inplayer)
        {
            inplayer = true;
            Debug.Log("誰かが入室しました");
            //matchText.text = "マッチングしました";
            PVcamera_Canvas.SetActive(false);
            canvasactiv.SetActive(false);
            playerid = 1;
            Player1 = PhotonNetwork.Instantiate("Playerplayer", new Vector3(0, 10, 30), Quaternion.identity, 0) as GameObject;
            Camerabox = PhotonNetwork.Instantiate("TEST", new Vector3(0, 10, 30), Quaternion.identity, 0) as GameObject;
            //PVpleyercamera = PhotonNetwork.Instantiate("PV_pleyer" ,new Vector3(0, 10, 30), Quaternion.identity, 0) as GameObject;
            //campos = Player.transform.Find("Campos");
            // playerkara = GameObject.Find(" playerkara");
            // GameObject playerkara = PhotonNetwork.Instantiate("Playerkara", new Vector3(0, 10, 30), Quaternion.identity, 0);
            Camerabox.transform.rotation = Quaternion.Euler(0, 180, 0);
            cam.transform.rotation = Quaternion.Euler(26, 180, 0);
            //cam.transform.rotation = Quaternion.Euler(-18, -50, 0.2f);
            Player1.GetComponent<Renderer>().material.color = Color.red;
            cam.transform.position = Camerabox.transform.position + camerapos;
            //Camerabox.transform.rotation = Quaternion.Euler(26, 180, 0);
            cam.transform.parent = Camerabox.transform;
        }

    }

    /******ここから接続を切る処理（ホスト・クライアントがアプリを終了したとかetc...）**********/


    void OnMasterClientSwitched(PhotonPlayer newMasterClient)//ホストが落ちて、自分（クライアント）がマスターになったとき
    {
        Debug.Log("マスターが切り替わりました");
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る
    }
    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)//クライアントがルームを出た時
    {
        Debug.Log("誰かが退室しました");
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る
    }
    void OnApplicationQuit()//アプリを終了したとき
    {
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る    
    }
    /***ここまで****/

    public void EndButton()//終わりたいときに終わる
    {
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る
    }
    void OnDisconnectedFromPhoton()
    {
        Debug.Log("通信を切りました");
        SceneManager.LoadScene("Title");
    }
}
