using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pvcamera : MonoBehaviour
{
    /*public float Rotspeed;
    public float speed;
    float up;
    [SerializeField] bool Rot = true;*/
    int count = 0;
    public GameObject Ball, Player1, Player2;
    Vector3 Startpos, Nowpos;
    void Start()
    {
        Startpos = transform.position;
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Nowpos.y = 50;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) count++;
        switch(count)
        {
            case 0://上空
                transform.position = Startpos;
                break;

            case 1://Player１視点
                Nowpos.x = Player1.transform.position.x;
                Nowpos.z = Player1.transform.position.z;
                transform.position = Nowpos;
                break;

            case 2:
                Nowpos.x = Player2.transform.position.x;
                Nowpos.z = Player2.transform.position.z;
                transform.position = Nowpos;
                break;

            case 3:
                Nowpos.x = Ball.transform.position.x;
                Nowpos.z = Ball.transform.position.z;
                transform.position = Nowpos;
                break;

            case 4:
                count = 0;
                break;
        }
       /* float hori = Input.GetAxis("Horizontal") * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && Rot)
        {
            Rot = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !Rot)
        {
            Rot = true;
        }
        if (Input.GetKey(KeyCode.LeftShift)) up = 1 * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightShift)) up = -1 * Time.deltaTime;
        else up = 0;
        if (Rot)
        {
            transform.Rotate(-ver * Rotspeed, hori * Rotspeed, 0);
        }
        else
        {
            transform.Translate(hori * speed, up * speed, ver * speed);
        }*/
    }
}