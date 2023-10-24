using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{

    public const int INITIAL_AUDIO_SOURCES = 2;
    public static AudioManager Instance;

 


    [Range(0f, 1f)]
    private float _masterVolume = 1;
    [SerializeField]
    public float MasterVolume
    {
        get { return _masterVolume; }
        set
        {
            _masterVolume = value;
            UpDateVolume();
        }
    }
    public List<AudioSource> AudioSources;
    [Header("Audio Clips")]
    public List<AudioClipSound> AudioClips;



    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioSources = new List<AudioSource>();
            AudioClips = new List<AudioClipSound>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpDateVolume()
    {
        int audioSourceCount = AudioSources.Count;
        for (int i = 0; i < audioSourceCount; i++)
        {
            var AudioSoundClip = AudioClips.Find(x => x.Name == AudioSources[i].clip.name);
            var audiClipVolumen = AudioSoundClip.Volume;
            AudioSources[i].volume = audiClipVolumen * MasterVolume;
        }
    }

    public void Init()
    {
        for(int i =0; i< INITIAL_AUDIO_SOURCES; i++)
        {
            AddNewAudioSource();
        }
        LoadBackgroundMusic(1f,true,1, "titanium-170190");
        PlaySoundByName("titanium-170190");
    }

    public bool PlaySound(AudioClipSound clip)
    {        
        AudioSource au = GetAudioSourceFree();
        if(au)
        {
            au.volume = clip.Volume * MasterVolume;
            au.pitch = clip.Pitch;
            au.clip = clip.Clip;
            au.Play();
            return true;
        }
        return false;
    }

   
    public bool PlaySoundByName(string soundName)
    {       
        AudioClipSound currentAudioClip = AudioClips.Find(au => au.Name == soundName);
        if(currentAudioClip != null)
        {
            PlaySound(currentAudioClip);
            return true;
        }
        else
        {
            Debug.LogError("SONIDO NO ENCONTRADO");
        }
        return false;
    }

    public void AddNewAudioSource()
    {
        AudioSource currentAudioSource = gameObject.AddComponent<AudioSource>();
        currentAudioSource.volume = MasterVolume;
        AudioSources.Add(currentAudioSource);
    }

    public AudioSource GetAudioSourceFree()
    {
       return AudioSources.Find(au => au.isPlaying == false);
    }


    public void LoadBackgroundMusic(float volume, bool isLoop, float pitch, string clipName)
    {
        AudioClip audioLoaded = Resources.Load<AudioClip>("Audios/"+clipName);
        if (audioLoaded)
        {
            AudioClipSound AuClSound = new();
            AuClSound.Name = audioLoaded.name;
            AuClSound.Volume = volume;
            AuClSound.Pitch = pitch;
            AuClSound.IsLoop = isLoop;
            AuClSound.Clip = audioLoaded;
            AudioClips.Add(AuClSound);
        }
        else
        {
            Debug.LogError("SONIDO NO CARGADO");
        }       
    }
}


public class AudioClipSound
{
    public bool IsLoop;
    public float Volume = 1;
    public string Name;
    public float Pitch;
    public AudioClip Clip;
}
