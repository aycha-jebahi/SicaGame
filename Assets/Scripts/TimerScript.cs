using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timeText;
    public int seconds, minutes;
    void Start()
    {
        addToSecond();
    }

    void Update()
    {
        
    }
    private void addToSecond()
    {
        seconds++;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }
        timeText.text = minutes + ":" + seconds;
        Invoke(nameof(addToSecond),time:1);
    }

    public void stopTimer()
    {
        CancelInvoke(nameof(addToSecond));
    }
}
