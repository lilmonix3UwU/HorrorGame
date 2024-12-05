using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsAndGameOver : MonoBehaviour
{
    private float secondsLeft;
    public int minutesLeft;
    [SerializeField] private TMP_Text text;
    private void Update()
    {
        if (secondsLeft <= 0)
        {
            secondsLeft = 60;
            minutesLeft--;
        }
        if (minutesLeft != 0 || secondsLeft > 0) { secondsLeft -= Time.deltaTime; }
        //else { timer done}


        int seconds = Mathf.FloorToInt(secondsLeft);
        string colonAndZero = ":";

        if (seconds < 10)  { colonAndZero = ":0"; }
        string minutesPlusZero;
        if (minutesLeft < 10) { minutesPlusZero = "0" + minutesLeft.ToString(); } else { minutesPlusZero = minutesLeft.ToString(); }
        

        text.text =  minutesPlusZero + colonAndZero + seconds.ToString();
    }
}
