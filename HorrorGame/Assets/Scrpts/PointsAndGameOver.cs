using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PointsAndGameOver : MonoBehaviour
{
    public int points;

    private float secondsLeft;
    public int minutesLeft;
    private bool spamPrevention = true;
    private GameObject player;
    [SerializeField] private TMP_Text[] _text;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameOverUILose;
    [SerializeField] private GameObject gameOverUIWin;

    private void Start()
    {
        points = 0;
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (secondsLeft <= 0 && minutesLeft > 0)
        {
            secondsLeft = 60;
            minutesLeft--;
        }

        if (minutesLeft > 0 || secondsLeft > 0.1)
        { 
            secondsLeft -= Time.deltaTime; 
        }
        else if (spamPrevention)
        {
            player.GetComponent<PlayerInteraction>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            gameOverUI.SetActive(true);

            if (points < 15)
            {

                gameOverUILose.SetActive(true);
            }
            else if (points >= 15)
            {
                gameOverUIWin.SetActive(true);
            }



            spamPrevention = false;
        }




        int seconds = Mathf.FloorToInt(secondsLeft);
        string colonAndZero = ":";

        if (seconds < 10)  { colonAndZero = ":0"; }
        string minutesPlusZero;
        if (minutesLeft < 10) { minutesPlusZero = "0" + minutesLeft.ToString(); } else { minutesPlusZero = minutesLeft.ToString(); }
        


        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].text = minutesPlusZero + colonAndZero + seconds.ToString();
        }
        




    }
}
