using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int currentScore;

    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _finalScoreText;

    public Gun myGun;


    void Start()
    {
        currentScore= 0;

        myGun = FindObjectOfType<Gun>();

        myGun.scorePoint += GetScore;
    }

    void Update()
    {
        _scoreText.text = currentScore.ToString();
        //_finalScoreText.text = _scoreText.text;
    }


    public void GetScore()
    {
        currentScore += 1;
    }

    


}
