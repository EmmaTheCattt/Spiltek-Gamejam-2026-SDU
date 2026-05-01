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
        Vector3 playerPos = player.transform.position;
        Vector3 paintingPos = transform.position;
        float dist = Vector3.Distance(playerPos, paintingPos);
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
        float finalVolume = easeInQuint(normalizedDistance);
        Debug.Log("Normalized Distance" + normalizedDistance);
        angelicChoir.source.volume = normalizedDistance;
    }

    public float easeInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
