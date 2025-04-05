using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float TimeLeft;
	public bool TimerOn = false;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
		{
			if(TimeLeft > 0)
			{
				TimeLeft -= Time.deltaTime;
			} else {
				Debug.Log("Time is up!");
				TimeLeft = 0;
				TimerOn = false;
			}
		}
    }
	
	void ClockActive(){
		TimerOn = true;
	}
	
	void updateTimer(float currentTime)
	{
		currentTime += 1;
		
		float minutes = Mathf.FloorToInt(currentTime / 60);
		float seconds = Mathf.FloorToInt(currentTime % 60);
	}
}
