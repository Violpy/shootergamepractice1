using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public AudioMixer audioMixer;

    public float mouseSensitivity = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float value)
    {
        float volume = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
        audioMixer.SetFloat("MasterVolume", volume);

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    public void SetSensitivity(float value)
    {
        mouseSensitivity = value;
        PlayerPrefs.SetFloat("Sensitivity", value);
        PlayerPrefs.Save();
    }

    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Volume"))
            SetVolume(PlayerPrefs.GetFloat("Volume"));

        if (PlayerPrefs.HasKey("Sensitivity"))
            mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
}
