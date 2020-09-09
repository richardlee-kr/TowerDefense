using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameisOver;

    public GameObject GameoverUI;

    private void Start()
    {
        GameisOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameisOver)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        WaveSpawner.isWave = true;
        GameisOver = true;
        GameoverUI.SetActive(true);
    }
}
