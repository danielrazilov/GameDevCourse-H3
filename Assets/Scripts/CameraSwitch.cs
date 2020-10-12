using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject avatarText;

    private int _currentCamNum;
    private bool _isCameraChanged;
    void Start()
    {
        _currentCamNum = 2;
        avatarText.SetActive(false);
        _isCameraChanged = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch Camera Right"))
        {
            _currentCamNum++;
            if (_currentCamNum == 6)
                _currentCamNum = 1;
            _isCameraChanged = true;
        }
        else if (Input.GetButtonDown("Switch Camera Left"))
        {
            _currentCamNum--;
            if (_currentCamNum == 0)
                _currentCamNum = 5;
            _isCameraChanged = true;
        }

        if (_isCameraChanged)
        {
            switch (_currentCamNum)
            {
                case 1:
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    cam4.SetActive(false);
                    cam5.SetActive(false);
                    avatarText.SetActive(true);
                    break;
                case 2:
                    cam1.SetActive(false);
                    cam2.SetActive(true);
                    cam3.SetActive(false);
                    cam4.SetActive(false);
                    cam5.SetActive(false);
                    avatarText.SetActive(false);
                    break;
                case 3:
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(true);
                    cam4.SetActive(false);
                    cam5.SetActive(false);
                    avatarText.SetActive(false);
                    break;
                case 4:
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    cam4.SetActive(true);
                    cam5.SetActive(false);
                    avatarText.SetActive(false);
                    break;
                case 5:
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    cam4.SetActive(false);
                    cam5.SetActive(true);
                    avatarText.SetActive(false);
                    break;

            }
            _isCameraChanged = false;
        }



    }
}
