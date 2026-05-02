using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Sound[] sounds;
    public static AudioManager instance;

    [SerializeField] private Sound[] walkSounds;
    [SerializeField] private Sound[] slimeSounds;

    [SerializeField] Material purpleMaterial;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.PlayOnAwake;
        }

        foreach (Sound s in walkSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.PlayOnAwake;
        }

        foreach (Sound s in slimeSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.PlayOnAwake;
        }

    }

    public void Update()
    {

    }

    public void Start()
    {

    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void StopSFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            print("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public IEnumerator WalkingLoop()
    {
        while (true)
        {
            Sound walkSound = Array.Find(walkSounds, sound => sound.name == "Walk");

            walkSound.source.pitch = UnityEngine.Random.Range((float)0.8, 1.2f);
            PlaySFX(walkSound.name);

            float delay = 0.35f + UnityEngine.Random.Range((float)-0.05f, 0.08f);
            yield return new WaitForSeconds(delay);
        }
    }

    public void PlayRandomSlimeSFX()
    {
        int lastIndex = -1;
        int randomIndex;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, slimeSounds.Length);
        } while (randomIndex == lastIndex);
        var randomSlimeSound = slimeSounds[randomIndex];
        randomSlimeSound.source.Play();
        Debug.Log("Playing slime sound");
    }

    public void PlaySoundWithVolumeRelativeToDistance(Vector3 objectPos, string sound)
    {
        var tank = GameObject.FindWithTag("Tank");
        float dist = Vector3.Distance(tank.gameObject.transform.position, objectPos);
        Debug.Log($"Distance between player and painting is {dist}");

        float normalizedDistance = Mathf.InverseLerp(40, 0, dist); // 40 feels good
        Debug.Log("Normalized Distance" + normalizedDistance);
        Sound _sound = Array.Find(sounds, s => s.name == sound);
        _sound.source.volume = normalizedDistance;
        Debug.Log(_sound.source.volume);
        PlaySFX(_sound.name);
    }

    public void PlaySlimeGroundSound(Material mat)
    {
        Debug.Log(mat.color);
        Debug.Log(purpleMaterial);
        if (mat.color == purpleMaterial.color)
        {
            PlayRandomSlimeSFX();
        }
        else
        {
            Debug.Log("Not hitting purple Material on raycasthit down");
        }
    }

    public void ControlSoundVolume(float volume)
    {
        foreach(var sound in sounds)
        {
            if (sound.name == "AngelicChoir") continue;
            sound.source.volume = volume;
        }
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (scene.name.StartsWith("LEVEL"))
        {
            StopMusic("TankSong");
            PlayMusic("TankSong");
        }
    }
}
   



