using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerakirikae : MonoBehaviour
{//　メインカメラ
    [SerializeField]
    private GameObject mainCamera;
    //　切り替える他のカメラ
    [SerializeField]
    private GameObject otherCamera;
    //　切り替える他のカメラ2
    [SerializeField]
    private GameObject otherCamera2;
    [SerializeField]
    private GameObject otherCamera3;
    [SerializeField]
    private GameObject otherCamera4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (mainCamera.activeSelf)
            {
                mainCamera.SetActive(false);
                otherCamera.SetActive(true);
                
            }
            else if (otherCamera.activeSelf)
            {
                otherCamera.SetActive(false);
                otherCamera2.SetActive(true);

            }
            else if (otherCamera2.activeSelf)

            {
                otherCamera2.SetActive(false);
                otherCamera3.SetActive(true);

            }
            else if (otherCamera3.activeSelf)

            {
                otherCamera3.SetActive(false);
                otherCamera4.SetActive(true);

            }
            else if (otherCamera4.activeSelf)

            {
                otherCamera4.SetActive(false);
                mainCamera.SetActive(true);

            }
        }
    }
}
