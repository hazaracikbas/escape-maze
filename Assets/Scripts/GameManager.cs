using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using GameAnalyticsSDK;


public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController pc;
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject startScreen;
    [SerializeField] ParticleSystem[] confetti;
    [SerializeField] PlayerData playerData;
    [SerializeField] TextMeshProUGUI scoreText, levelText;
    [SerializeField] int score, level;

    private bool isGameStarted = false;

    private void Awake()
    {
        playerData = SaveSystem.Load();
    }
    void Start()
    {
        //GameAnalytics.Initialize();

        level = playerData.playerLevel;
        score = playerData.playerCurrency;
    }

    void Update()
    {
        StartGame();

        levelText.text = "Level " + level.ToString();
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        if (!isGameStarted && Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            startScreen.SetActive(false);
        }
        else if (isGameStarted == false)
            startScreen.SetActive(true);
    }

    public void LevelComplete()
    {
        level++;

        playerData.playerCurrency = score;
        playerData.playerLevel = level;

        SaveSystem.Save(playerData);

        canvas.SetActive(false);

        confetti[0].Play();
        confetti[1].Play();

        Taptic.Success();

        Debug.Log(level);

        StartCoroutine(WaitGameEnd());
    }

    public void CollectGems()
    {
        score += 10;
        Taptic.Medium();
    }

    public void NextLevel()
    {
        isGameStarted = false;

        int i = SceneManager.GetActiveScene().buildIndex;

        //Time.timeScale = 1.0f;

        score = playerData.playerCurrency;
        level = playerData.playerLevel;

        if (i < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(i + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    IEnumerator WaitGameEnd()
    {
        yield return new WaitForSecondsRealtime(2.5f);

        levelScreen.SetActive(true);
    }

}
