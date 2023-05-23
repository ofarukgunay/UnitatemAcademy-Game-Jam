using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class levelController : MonoBehaviour
{
    private Scene _sahne;

    private void Awake()
    {
        //_sahne = GetComponent<Scene>();
        _sahne = SceneManager.GetActiveScene();
    }
    public void SonrakiSahne()
    {
        SceneManager.LoadScene(_sahne.buildIndex + 1);
        //PlayerPrefs.SetInt("ScoreCounts", score.instance.collectedPoint);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alaca��m�z zaman silece�iz. Yoksa �al��m�yor. Fakat, �imdilik test ederken g�rebilmemiz i�in durmas� gerekiyor.
        Application.Quit();
    }
}
