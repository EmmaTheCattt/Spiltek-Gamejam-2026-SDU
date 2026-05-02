using System;
using UnityEngine;

public class SoundDetectionScript : MonoBehaviour
{
    GameObject player;
    public float detectionArea;
    Sound angelicChoir;

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
        GameObject tank = GameObject.FindWithTag("Tank");
        Vector3 tankPos = tank.transform.position;
        Vector3 paintingPos = transform.position;
        float dist = Vector3.Distance(tankPos, paintingPos);
        Debug.Log($"Distance between player and painting is {dist}");
        AdjustVolume(dist);

    }

    public void AdjustVolume(float distance)
    {
        if (distance < detectionArea && !angelicChoir.source.isPlaying)
        {
            AudioManager.instance.PlaySFX(angelicChoir.name);
        }
        else if (distance > detectionArea && angelicChoir.source.isPlaying)
        {
            AudioManager.instance.StopSFX(angelicChoir.name);
        }

        float normalizedDistance = Mathf.InverseLerp(detectionArea, 0, distance);
        float normalizedDistanceOtherSound = Mathf.InverseLerp(0, detectionArea, distance);
        float finalVolume = easeInQuint(normalizedDistance);
        float finalVolumeSound = easeInQuint(normalizedDistanceOtherSound);
        Debug.Log("Normalized Distance" + normalizedDistance);
        angelicChoir.source.volume = normalizedDistance;
        Debug.Log(angelicChoir.source.volume);
        AudioManager.instance.ControlSoundVolume(normalizedDistanceOtherSound);
    }

    public float easeInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
