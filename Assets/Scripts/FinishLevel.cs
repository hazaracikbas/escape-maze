using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject levelScreen;
    private void OnCollisionEnter(Collision collision)
    {
        levelScreen.SetActive(true);
    }
}
