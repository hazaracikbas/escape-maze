using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject joyStick;
    [SerializeField] PlayerData playerData;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score;

    private void Awake()
    {
        playerData = SaveSystem.Load();
    }
    void Start()
    {
        score = playerData.playerCurrency;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void LevelComplete()
    {
        playerData.playerCurrency = score;
        SaveSystem.Save(playerData);

        levelScreen.SetActive(true);
        Time.timeScale = 0.0f;
        joyStick.SetActive(false);
    }

    public void CollectGems()
    {
        score += 10;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        int i = SceneManager.GetActiveScene().buildIndex;

        Time.timeScale = 1.0f;

        score = playerData.playerCurrency;

        if (i < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(i + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

}
