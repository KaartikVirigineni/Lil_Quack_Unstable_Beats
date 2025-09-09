using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;

    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(
                new Vector3(0, SongManager.Instance.noteSpawnY, 0), new Vector3(0, SongManager.Instance.noteDespawnY, 0),t);

            var renderer = GetComponent<Renderer>();
            if (renderer != null) renderer.enabled = true;
        }
    }
}
