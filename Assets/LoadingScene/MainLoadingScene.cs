using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLoadingScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Color primaryColor;
    public Color FinalColor;
    public Image backGorundImage;
    public Slider SliderProgressBar;



    void Start()
    {

        SubscribeToInfoProgress();

    }

    // Update is called once per frame
    void Update()
    {
     
    }


    IEnumerator FadeBackground()
    {
        float t = 0;
        while(t < 1)
        {
            backGorundImage.color = Color.Lerp(primaryColor, FinalColor, t);
            t += 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
    }


    IEnumerator SimulateProgressBar()
    {
        float t = 0;
        while (t < 1)
        {
            SliderProgressBar.value  = t;
            t += 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
    }


    public void UpdateProgressBar(float progress)
    {             
        SliderProgressBar.value = progress;                    
    }

    public void SubscribeToInfoProgress()
    {
        SceneController sceneController = GameObject.FindAnyObjectByType<SceneController>();
        sceneController.CurrentSceneLoadingProgress += UpdateProgressBar;
    }


}
