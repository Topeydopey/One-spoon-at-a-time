using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("List of Sounds")]
    public Sound[] sounds; // Assign each Sound in the Inspector

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            // Keep this AudioManager across scene loads
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Create an AudioSource for each sound
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound \"" + soundName + "\" not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound \"" + soundName + "\" not found!");
            return;
        }
        s.source.Stop();
    }
}
