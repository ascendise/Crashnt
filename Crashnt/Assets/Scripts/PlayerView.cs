using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highscoreText;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        player.Crash += Player_OnCrash;
    }

    private void Player_OnCrash(object sender, EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{GetRoundedScore(player.Score)} km";
        highscoreText.text = $"{GetRoundedScore(player.Highscore)} km";
    }

    private String GetRoundedScore(float score)
    {
        var twoDecimalPlaces = "{0:0.00}";
        return String.Format(twoDecimalPlaces, score);
    }
}
