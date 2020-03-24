using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tatatat : MonoBehaviour
{
    public GameObject starttext;
    public AudioClip tapSE;
    AudioSource audiose;
    // Start is called before the first frame update
    void Start()
    {
        audiose = gameObject.AddComponent<AudioSource>();
        PhotonNetwork.LeaveRoom();//ルームを出る
        PhotonNetwork.Disconnect();//接続を切る
        StartCoroutine("TouchToStart");

    }

    void Update()
    {
        if(Time.time == 2f &&Input.touchCount == 1||Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(tapSE);
            Invoke("StartGame",0.5f);
        }
        
    }

    public void StartGame ()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator TouchToStart ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            starttext.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            starttext.SetActive(true);
        }
    }
}
