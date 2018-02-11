using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Cameras;
    [SerializeField]
    private int CurrentCamera;

    void Start()
    {
        EnableAndDisableAllCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            CurrentCamera += 1;
            if (CurrentCamera > Cameras.Length)
            {
                CurrentCamera = 0;
            }
            EnableAndDisableAllCamera();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentCamera -= 1;
            if (CurrentCamera < 0)
            {
                CurrentCamera = Cameras.Length;
            }
            EnableAndDisableAllCamera();
        }
    }

    void EnableAndDisableAllCamera()
    {
        foreach (var item in Cameras)
        {
            if(item == Cameras[CurrentCamera].gameObject)
            {
                item.SetActive(true);
            }

            else
            {
                item.SetActive(false);
            }
        }
      
    }
}


