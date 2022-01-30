using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 300f;

    //public GameObject countdownText;
    public TMP_Text countdownText;

    void Start()
    {
        //coundownTimer = countdownText.GetComponent<TMP_Text>();
        startingTime = 300f;
        currentTime = startingTime;
    }
    void Update()
    {
        Debug.Log(currentTime);
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
    }
}
