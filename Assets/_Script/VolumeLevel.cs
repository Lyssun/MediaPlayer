using UnityEngine;
using UnityEngine.UI;

/**
 * Allow the user to change the sound level
 */
public class VolumeLevel : MonoBehaviour {

    [SerializeField]
    /*
     * 
     */
    private Slider VolumeSlider;
    /**
     * Get the value for the slider in the playerpref if that exist otherwise, that would be set to 1
     */
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
            Volume = PlayerPrefs.GetFloat("Volume");
        else
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
            Volume = 1f;
        }
    }

    /**
     * Allows us to get and to set the slider value
     */
    public float Volume
    {
        get { return VolumeSlider.value; }
        set { VolumeSlider.value = value;}
    }

    /**
     * Save the value of the slider in the playerPref when disabled.
     */
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }
}