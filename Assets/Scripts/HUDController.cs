using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider hpBar;
    public Text scoreText;
    public Text timerText;

    void Update()
    {
        hpBar.value = PlayerStats.Instance.currentHP;
        scoreText.text = "Score: " + PlayerStats.Instance.score;
        timerText.text = Mathf.FloorToInt(Time.timeSinceLevelLoad).ToString();
    }
}
