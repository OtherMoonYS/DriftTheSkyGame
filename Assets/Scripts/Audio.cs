using UnityEngine;

public class Audio : MonoBehaviour
{
    private float volume;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("AudioVolume");
        audioSrc.volume = volume;
    }
    
    void Update()
    {
        
    }
}
