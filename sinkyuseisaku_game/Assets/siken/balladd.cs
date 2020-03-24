using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balladd : MonoBehaviour
{
    [SerializeField]private GameObject Cam;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 cameraForward = Vector3.Scale(Cam.transform.forward, new Vector3(1, 0, 1)).normalized;
            rb.AddForce(cameraForward * 50, ForceMode.Force);
            rb.AddForce(new Vector3(0,5000/2,0),ForceMode.Force);
        }
    }
}
