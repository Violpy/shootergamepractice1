using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Префабы снарядов")]
    public GameObject fireballPrefab;   // Урон 10
    public GameObject lightningPrefab;  // Урон 4

    [Header("Спрайты оружия")]
    public SpriteRenderer weaponRenderer; // Ссылка на SpriteRenderer палки
    public Sprite fireWandSprite;         // Картинка огненной палки
    public Sprite electricWandSprite;     // Твоя картинка с молнией

    public Transform firePoint;         
    private bool isFireWand = true;    

    void Update()
    {
        // Переключение оружия на R
        if (Input.GetKeyDown(KeyCode.R))
        {
            isFireWand = !isFireWand;
            UpdateWeaponVisuals();
        }
    }

    void UpdateWeaponVisuals()
    {
        if (isFireWand)
        {
            weaponRenderer.sprite = fireWandSprite;
            Debug.Log("Выбран Огненный посох");
        }
        else
        {
            weaponRenderer.sprite = electricWandSprite;
            Debug.Log("Выбран Электрический посох");
        }
    }

    public GameObject GetCurrentPrefab()
    {
        return isFireWand ? fireballPrefab : lightningPrefab;
    }
}