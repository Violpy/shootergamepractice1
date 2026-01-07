using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public int totalWaves = 10;
    public int currentWave = 1;

    void Update()
    {
        if (currentWave >= totalWaves)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        SceneManager.LoadScene("Credits");
    }
}