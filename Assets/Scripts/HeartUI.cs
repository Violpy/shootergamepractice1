using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] heartIcons; 
    public Sprite fullHeart;   
    public Sprite emptyHeart;  

    void Update()
{
    if (PlayerStats.Instance == null) return;

    int health = PlayerStats.Instance.currentHP;
    int hpPerHeart = PlayerStats.Instance.hpPerHeart;

    for (int i = 0; i < heartIcons.Length; i++)
    {
        // Сердце активно, если текущее здоровье больше, чем (номер сердца * 20)
        // Например: если HP = 40, то 1-е и 2-е сердца (0 и 20) полные, остальные пустые.
        if (health > i * hpPerHeart)
        {
            heartIcons[i].sprite = fullHeart;
        }
        else
        {
            heartIcons[i].sprite = emptyHeart;
        }

        // На всякий случай включаем объект, если он был выключен
        heartIcons[i].gameObject.SetActive(true);
    }
}
}