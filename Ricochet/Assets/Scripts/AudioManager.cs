using UnityEngine.Audio;
using UnityEngine;
using System;

/* Ensure this file exists somewhere, or else this entire audio system won't work. 
 * Multiple copies are fine as it accounts for that, but ensure the Sounds array is consistent
 * 
 * To add sound:
 * Find AudioManager object (or prefab preferably). Increase Sounds size, add audio clip, name it, ensure all values are not null
 * To play sound:
 * AudioManager.instance.Play("SoundName");
 * SoundName will be the name given to the clip in inspector
 */

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake ()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Could not find sound: " + name);
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Could not find sound: " + name);
            return;
        }
        s.source.Stop();
    }
}
