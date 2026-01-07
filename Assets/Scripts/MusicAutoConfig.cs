using UnityEngine;

public class MusicAutoConfig : MonoBehaviour
{
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        
        AudioSource source = GetComponent<AudioSource>();
        if (source != null)
        {
            source.volume = savedVolume;
        }
    }
}