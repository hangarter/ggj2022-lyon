using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    private bool running;
    public float startingTimeInSeconds = 300f;

    public UnityEvent OnTimesUp; 

    //public GameObject countdownText;
    public TMP_Text countdownText;

    void Start()
    {
        running = true;
        currentTime = startingTimeInSeconds;
    }
    void Update()
    {
        if(running && currentTime == 0)
        {
            OnTimesUp.Invoke();
            running = false;
        }
        //Debug.Log(currentTime);
        currentTime -= 1 * Time.deltaTime;

        currentTime = Mathf.Clamp(currentTime, 0f, startingTimeInSeconds);

        TimeSpan duration = new TimeSpan(0, 0, 0, (int) currentTime);
        countdownText.text = $"{duration.Minutes}:{duration.Seconds:00}";
    }
}
