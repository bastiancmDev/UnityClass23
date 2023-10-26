using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPdateVolumeScript : MonoBehaviour, AudioReproducer
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

    public void Play()
    {
        throw new System.NotImplementedException();
    }
}

public interface AudioReproducer
{
    public void Play();
}
