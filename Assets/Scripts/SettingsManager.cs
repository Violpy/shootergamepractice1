using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Звук")]
    public Slider volumeSlider;
    public AudioSource musicSource;

    [Header("Яркость")]
    public Slider brightnessSlider;
    public Image brightnessOverlay; 

    void Start()
    {
        // Пытаемся найти музыку, если она не привязана
        if (musicSource == null)
        {
            musicSource = GameObject.Find("musicPlay")?.GetComponent<AudioSource>();
        }

        // Загружаем настройки из памяти
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1.0f);

        // Применяем звук
        if (musicSource != null) musicSource.volume = savedVolume;

        // Применяем яркость
        ApplyBrightness(savedBrightness);

        // Инициализируем слайдеры ТУТ, только если они есть в этой сцене
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(ApplyVolume);
        }

        if (brightnessSlider != null)
        {
            brightnessSlider.value = savedBrightness;
            brightnessSlider.onValueChanged.AddListener(ApplyBrightness);
        }
    }

    public void ApplyVolume(float val)
    {
        if (musicSource != null) musicSource.volume = val;
    }

    public void ApplyBrightness(float val)
    {
        if (brightnessOverlay != null)
        {
            // Меняем прозрачность черного слоя (0 - светло, 1 - темно)
            Color c = brightnessOverlay.color;
            c.a = 1f - val; 
            brightnessOverlay.color = c;
        }
    }

    public void SaveSettings()
    {
        if (volumeSlider != null) PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
        if (brightnessSlider != null) PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        
        PlayerPrefs.Save();
        Debug.Log("Настройки сохранены!");
    }
    public void ResetSettings()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = 0.5f;
            ApplyVolume(0.5f);
        }

        if (brightnessSlider != null)
        {
            brightnessSlider.value = 1.0f;
            ApplyBrightness(1.0f);
        }
    }
}