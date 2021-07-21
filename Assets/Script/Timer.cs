using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/ // Tuto utilisé pour le chrono

public class Timer : MonoBehaviour 
{
    private Text text;
    private float time = 120f;
    private float timeBip = 1f;
    private float lastTimeBip = 0f;
    private bool endTime;
    private EndAnimation end;
    private AudioSource bip;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Timer").GetComponent<Text>();
        end = GameObject.Find("EndScreen").GetComponent<EndAnimation>();
        bip = GameObject.Find("bipTimer").GetComponent<AudioSource>();
        endTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endTime)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (time < 0)
                    time = 0;
                DisplayTime(time);
            }
            else
            {
                endTime = true;
                end.EndScreen();
                text.text = "0:00:000";
            }
            if (time <= 6)
            {
                if (Time.time - lastTimeBip > timeBip) // + Une partie du votre sur la gestion de temps dans le tuto tir
                {
                    bip.Play();
                    lastTimeBip = Time.time;
                }
            }
            if (time == 0)
                bip.Stop();
        }
    }

    private void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float secondes = Mathf.FloorToInt(time % 60);
        float millisecondes = (time % 1) * 1000;

        text.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, secondes, millisecondes);
    }

    public void ResetTimer()
    {
        time = 120f;
        endTime = false;
    }
}
