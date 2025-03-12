using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsAndGameOver : MonoBehaviour
{
    public int points;

    private float secondsLeft;
    public int minutesLeft;
    private bool doorSpamPrevention = true;
    [SerializeField] private TMP_Text[] _text;

    private void Start()
    {
        points = 0;
    }

    private void Update()
    {
        if (secondsLeft <= 0 && minutesLeft > 0)
        {
            secondsLeft = 10;
            minutesLeft--;
        }

        if (minutesLeft > 0 || secondsLeft > 0.1)
        { 
            secondsLeft -= Time.deltaTime; 
        }
        else if (doorSpamPrevention)
        {
            
            doorSpamPrevention = false;
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
