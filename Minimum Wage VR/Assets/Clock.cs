using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float TimeTotal;
	public float TimeLeft;
	public bool TimerOn = false;
	public GameObject wijzer;
	public GameObject wijzer2;
	private float wVar;
	private float w2Var;
	
	private AudioSource audioSource;
	public AudioClip clockStart;
	public AudioClip clockEnd;
	
	// Start is called before the first frame update
    void Start()
    {
		TimeLeft = TimeTotal;
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
		{
			if(TimeLeft > 0)
			{
				TimeLeft -= Time.deltaTime;
				wVar = TimeLeft/TimeTotal*360;
				w2Var = wVar*60;
				wijzer.transform.eulerAngles = new Vector3(wijzer.transform.eulerAngles.x, wijzer.transform.eulerAngles.y, -wVar);
				wijzer2.transform.eulerAngles = new Vector3(wijzer2.transform.eulerAngles.x, wijzer.transform.eulerAngles.y, -w2Var);
			} else {
				Debug.Log("Time is up!");
				TimeLeft = 0;
				if(TimerOn == true){audioSource.clip = clockEnd; audioSource.Play();}
				TimerOn = false;
			}
		}
    }
	
	public void ClockActive(){
		if(TimerOn == false){audioSource.clip = clockStart; audioSource.Play();}
		TimerOn = true;
	}
}
