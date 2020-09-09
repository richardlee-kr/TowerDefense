using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform blueEnemyPrefab;
    public Transform redEnemyPrefab;
    public Transform bossEnemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 5f;

    public static bool isWave = false;

    [Header("Text")]

    public Text waveCountdownIndex;
    public Text waveNumberIndex;

    public int waveNumber = 1;

    Enemy e;

    private void Start()
    {
        isWave = false;
    }
    void Update()
    {
        if (!isWave)
        {
            if (countdown <= 0f)
            {
                startWave();
            }
            countdown -= Time.deltaTime;
        }
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownIndex.text = string.Format("{0:00.0}", countdown);

        waveNumberIndex.text = ("Wave ")+waveNumber.ToString();
    }
    public void startWave()
    {
        waveNumber++;
        PlayerStats.Rounds++;

        if (waveNumber % 20 == 0)
        {
            StartCoroutine(SpawnBoss());
        }
        else
        {
            StartCoroutine(SpawnBlue());
            if (waveNumber >= 10)
            {
                StartCoroutine(SpawnRed());
            }
        }

        countdown = timeBetweenWaves;
    }
    IEnumerator SpawnBlue()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemyblue();
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator SpawnRed()
    {
        for (int i = 0; i < waveNumber-7; i++)
        {
            SpawnEnemyred();
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SpawnBoss()
    {
        for (int i = 0; i < waveNumber/20; i++)
        {
            SpawnEnemyBoss();
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemyblue()
    {
        Instantiate(blueEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemyred()
    {
        Instantiate(redEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemyBoss()
    {
        Instantiate(bossEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
