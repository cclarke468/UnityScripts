
using UnityEngine;
using UnityEngine.UI;

public class AudioBehavior : MonoBehaviour
{
    private float volumeFloat = 1;
    public Slider volumeSlider;
    public AudioSource Audio;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume",1);
            print("key created");
        }
        volumeFloat = PlayerPrefs.GetFloat("Volume");
        Audio.volume = volumeFloat;
        volumeSlider.value = volumeFloat; 
    }

    public void SetVolume()
    {
        volumeFloat = volumeSlider.value;
        Audio.volume = volumeFloat;
        PlayerPrefs.SetFloat("Volume", volumeFloat);
        // print("volume set to " + volumeFloat);
    }

    public void ResetAudio()
    {
        PlayerPrefs.DeleteKey("Volume");
        Audio.volume = 1;
        volumeSlider.value = 1;
    }
}
