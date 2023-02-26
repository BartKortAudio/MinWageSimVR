using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
	
	public AudioSource music;
	public bool isPlaying = true;
	
    // Start is called before the first frame update
    void Start()
    {
        //music.Play();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
	
	/*void OnCollisionEnter(Collision col)
	{
		if (isPlaying == false){
			music.Play();
			isPlaying = true;
		}else {
			music.Stop();
			isPlaying = false;
		}
	}
	*/
	
	public void turnOnOff()
	{
		if (isPlaying == false){
			music.Play();
			isPlaying = true;
		}else {
			music.Stop();
			isPlaying = false;
		}
	}
	
}
