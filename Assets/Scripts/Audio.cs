using UnityEngine;

public class Audio : MonoBehaviour
{
    private float volume;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("AudioVolume"))
            volume = PlayerPrefs.GetFloat("AudioVolume");
        else
            volume = 0.5f;

        audioSrc.volume = volume;
    }
}
