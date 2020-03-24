using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public AudioClip ButtonSE;
    AudioSource audiose;
    private void Start()
    {
        audiose = GetComponent<AudioSource>();
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る
    }

    public void Titlebutton()
    {
        audiose.PlayOneShot(ButtonSE);
        Invoke("TitleGO",0.5f);
    }
    public void TitleGO ()
    {
        SceneManager.LoadScene("Title");
    }

}
