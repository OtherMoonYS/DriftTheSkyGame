using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;
    private Image buttonAudioImage;
    private bool isActive;

    public Slider slider;

    public AudioClip clip;
    public AudioSource audioSrc;

    private void Awake()
    {
        buttonAudioImage = buttonAudio.GetComponent<Image>();
    }
    void Update()
    {
        if (isActive == false)
        {
            audioSrc.volume = 0;
        }
        else
        {
            audioSrc.volume = slider.value;
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
