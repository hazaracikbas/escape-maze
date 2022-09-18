using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.LevelComplete();
    }


}
