using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private Player player;
    [SerializeField]
    private GameObject GameOverScreen;

    private void Start()
    {
        player = Player.Instance;
        player.Crash += Player_OnCrash;
    }

    private void Player_OnCrash(object sender, EventArgs e)
    {
        GameOverScreen.SetActive(true);
    }
}
