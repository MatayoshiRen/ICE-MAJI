using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class douki : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(0,x,0);
    }
}
