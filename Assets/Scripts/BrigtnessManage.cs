using UnityEngine;
using UnityEngine.UI;

public class BrightnessManage : MonoBehaviour
{
    public Image brightnessOverlay; // Черная картинка на весь экран для имитации яркости
    public Slider brightnessSlider; // Слайдер из настроек

    void Start()
    {
        // При старте любой сцены загружаем сохраненное значение
        // Если ничего не сохранено, ставим 0.5 (средняя яркость)
        float savedBrightness = PlayerPrefs.GetFloat("BrightnessValue", 0.5f);
        
        if (brightnessSlider != null)
        {
            brightnessSlider.value = savedBrightness;
        }

        ApplyBrightness(savedBrightness);
    }

    // Метод, который вызывается при движении слайдера
    public void OnSliderChanged(float value)
    {
        ApplyBrightness(value);
        // Сохраняем значение на диск
        PlayerPrefs.SetFloat("BrightnessValue", value);
        PlayerPrefs.Save();
    }

    void ApplyBrightness(float value)
    {
        if (brightnessOverlay != null)
        {
            // Меняем прозрачность черного слоя: 
            // Чем выше слайдер, тем меньше прозрачность черного (тем ярче игра)
            float alpha = 1 - value;
            Color c = brightnessOverlay.color;
            c.a = alpha;
            brightnessOverlay.color = c;
        }
    }
}