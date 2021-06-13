using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject text;
    public GameObject player;
    bool timerOn = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //timer = 0f;
        }

        TimeSpan t = TimeSpan.FromSeconds(timer);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);
        text.GetComponent<Text>().text = timer == 0 ? "0s" : answer;
    }

    private void OnTriggerEnter(Collider other)
    {
        timerOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        timerOn = false;
    }
}
