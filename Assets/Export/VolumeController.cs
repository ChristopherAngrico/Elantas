using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private SaveVolume volumeData = null;
    private const string VOLUME_KEY = "Volume";

    private void OnEnable()
    {
        LoadValues();
    }

    public void SaveVolumeButton()
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, volumeSlider.value);
        LoadValues();
    }

    private void LoadValues()
    {
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, volumeData.volume);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
    }
}