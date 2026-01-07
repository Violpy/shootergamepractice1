using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    
    [Header("Префабы врагов")]
    public GameObject bugPrefab;
    public GameObject smallSpiderPrefab;
    public GameObject largeSpiderPrefab;

    [Header("Точки спавна")]
    public Transform[] spawnPoints;

    public int currentWave = 0;
    private bool allWavesFinished = false;

    private int[,] waves = {
        {3, 0, 0}, // Wave 1: 3 Bugs
        {5, 0, 0}, // Wave 2: 5 Bugs
        {2, 2, 0}, // Wave 3: 2 Bugs, 2 Small Spiders
        {3, 3, 0}, // Wave 4: 3 Bugs, 3 Small Spiders
        {7, 0, 0}, // Wave 5: 7 Bugs
        {2, 2, 0}, // Wave 6: 2 Bugs, 2 Small Spiders
        {3, 3, 0}, // Wave 7: 3 Bugs, 3 Small Spiders
        {0, 7, 0}, // Wave 8: 7 Small Spiders
        {0, 5, 1}, // Wave 9: Small Spiders and 1 Large
        {3, 0, 2}  // Wave 10: 3 Bugs, 2 Large
    };

    void Awake() { Instance = this; }

    void Start() {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {
    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "lvl") {
        yield break; 
    }

    if (currentWave >= 10) {
        allWavesFinished = true;
        yield break;
    }

        int bugs = waves[currentWave, 0];
        int smallSpiders = waves[currentWave, 1];
        int largeSpiders = waves[currentWave, 2];

        for (int i = 0; i < bugs; i++) SpawnEnemy(bugPrefab);
        for (int i = 0; i < smallSpiders; i++) SpawnEnemy(smallSpiderPrefab);
        for (int i = 0; i < largeSpiders; i++) SpawnEnemy(largeSpiderPrefab);

        currentWave++;
    }

    void SpawnEnemy(GameObject prefab) {
        if (prefab == null) return;
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(prefab, sp.position, Quaternion.identity);
    }

    void Update() {
        // Проверка на победу
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            if (currentWave < 10) {
                StartCoroutine(SpawnWave());
            } else if (!allWavesFinished) {
                allWavesFinished = true;
                SceneLoader.Instance.LoadScene("Credits");
            }
        }
    }
}