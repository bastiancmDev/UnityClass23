using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCinematic : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera _cimaticCamera;
    void Start()
    {
        _cimaticCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
           
        }
    }


    public void LaunchCimaticCoroutine()
    {
        StartCoroutine(CinamtickTrackMovement());
    }

    IEnumerator CinamtickTrackMovement()
    {
        
        float position = 0f;
        while (position < 1)
        {
            _cimaticCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = position;
            yield return new WaitForSeconds(0.01f);
            position += 0.001f;
        }
        UIGameController uiController = FindObjectOfType<UIGameController>();
        uiController.CinematicEnd();

    }
}
