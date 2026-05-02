using System;
using UnityEngine;

public class SoundDetectionScript : MonoBehaviour
{
    GameObject player;
    public float detectionArea;
    Sound angelicChoir;
    public bool TwoDScene = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angelicChoir = Array.Find(AudioManager.instance.sounds, s => s.name == "AngelicChoir");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }

    public void CalculateDistance()
    {
        float dist;
        Vector3 paintingPos = transform.position;
        if (TwoDScene)
        {
            GameObject player = GameObject.FindWithTag("Player");
            Vector3 playerPos = player.transform.position;
            dist = Vector3.Distance(playerPos, paintingPos);
        }
        else
        {
            GameObject tank = GameObject.FindWithTag("Tank");
            Vector3 tankPos = tank.transform.position;
            dist = Vector3.Distance(tankPos, paintingPos);
        }

        Debug.Log($"Distance between player and painting is {dist}");
        AdjustVolume(dist);

    }

    public void AdjustVolume(float distance)
    {
        float normalizedDistance = Mathf.InverseLerp(detectionArea, 0, distance);
        float normalizedDistanceOtherSound = Mathf.InverseLerp(0, detectionArea, distance);
        float finalVolume = easeInQuint(normalizedDistance);
        float finalVolumeSound = easeInQuint(normalizedDistanceOtherSound);
        Debug.Log("Normalized Distance" + normalizedDistance);
        if (TwoDScene)
        {
            Debug.Log("2D");
            angelicChoir.source.volume = normalizedDistanceOtherSound * 0.25f;
            AudioManager.instance.ControlSoundVolume(normalizedDistance);
        }
        else 
        {
            if (distance < detectionArea && !angelicChoir.source.isPlaying)
            {
                AudioManager.instance.PlaySFX(angelicChoir.name);
            }
            else if (distance > detectionArea && angelicChoir.source.isPlaying)
            {
                AudioManager.instance.StopSFX(angelicChoir.name);
            }
            angelicChoir.source.volume = normalizedDistance; 
            AudioManager.instance.ControlSoundVolume(normalizedDistanceOtherSound); 
            Debug.Log("3D"); 
        }

        Debug.Log(angelicChoir.source.volume);
    }

    public float easeInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
