using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPdateVolumeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpdateVolume(float volume)
    {
        AudioManager.Instance.MasterVolume = volume;
    }
}
