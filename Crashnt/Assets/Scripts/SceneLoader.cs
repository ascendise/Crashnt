using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private Player player;
    [SerializeField]
    private GameOverScreen GameOverScreen;
    [SerializeField]

    private void Start()
    {
        player = Player.Instance;
        player.Crash += Player_OnCrash;
        GameOverScreen.ContinueButtonClick += GameOverScreen_ContinueButtonClick;
    }

    private void Player_OnCrash(object sender, EventArgs e)
    {
        GameOverScreen.gameObject.SetActive(true);
    }

    private void GameOverScreen_ContinueButtonClick(object sender, EventArgs e)
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void RestoreScene()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
