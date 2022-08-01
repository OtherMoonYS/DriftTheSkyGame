using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;
    private Image buttonAudioImage;
    private bool isActive = true;
    private float volume;

    public Slider slider;

    public AudioClip clip;
    public AudioSource audioSrc;

    private void Awake()
    {
        buttonAudioImage = buttonAudio.GetComponent<Image>();
        if (PlayerPrefs.HasKey("AudioVolume"))
            volume = PlayerPrefs.GetFloat("AudioVolume");
        else
            volume = 0.5f;

        slider.value = volume;
        audioSrc.volume = slider.value;
    }
    void Update()
    {
        if (isActive == false)
        {
            volume = 0;
        }
        else
        {
            volume = slider.value;            
        }

        if (audioSrc.volume != volume)
        {
            audioSrc.volume = volume;
            PlayerPrefs.SetFloat("AudioVolume", volume);
        }
    }
    public void OnOffAudio()
    {
        if (isActive)
        {
            isActive = false;
            buttonAudioImage.sprite = audioOff;
        }
        else
        {
            isActive = true;
            buttonAudioImage.sprite = audioOn;
        }
    }
    public void PlaySound()
    {
        audioSrc.PlayOneShot(clip);
    }
}
