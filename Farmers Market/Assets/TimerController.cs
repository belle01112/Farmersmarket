using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    public float StartTime; //Timer will count down from this value
    private float TimeLeft;

    public TMP_Text TimerText;
    public Button StartButton;


    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0)
        {
            //Time tick down
            TimeLeft -= Time.deltaTime;
            if(TimeLeft > 60)
            {
                //Mins + Secs
                FormatToMinSec();

            }
            else
            {
                TimerText.text = TimeLeft.ToString("0.00");
            }
            
        }
        else
        {
            //Timer Finished

            StartButton.gameObject.SetActive(true);
            TimerText.gameObject.SetActive(false);
        }
    }

    public void StartClicked()
    {
        TimeLeft = StartTime;
        StartButton.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(true);
    }
    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(TimeLeft / 60);
        float secs = Mathf.FloorToInt(TimeLeft % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }

}





