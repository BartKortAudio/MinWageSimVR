using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Burger : MonoBehaviour
{
    public float cookLvl;
	public bool isCooking;
	public int cookingProg = 0;
	public float cookDuration;
	public float burntDuration;
	public float burntIndicator;
	
	public AudioSource audioClip;
	public AudioSource audioBurn;
	
	public GameObject smokeObject;
	public GameObject bsmokeObject;
	public Material cookedMat;
	public Material burntMat;
	
	
	// Start is called before the first frame update
    void Start()
    {
        smokeObject = transform.GetChild(0).gameObject;
		bsmokeObject = transform.GetChild(1).gameObject;
		burntIndicator = burntDuration * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking == true && cookingProg != 3)
		{
			cookLvl += 1.0f * Time.deltaTime;
			Debug.Log(cookLvl);
			
			if (cookingProg == 0 && cookLvl >= cookDuration){
				BurgerReady();
			}
			if (cookingProg == 1 && cookLvl >= burntIndicator){
				BurgerIndicate();
			}
			
			if (cookingProg == 2 && cookLvl >= burntDuration){
				BurgerBurnt();
			}
		}
    }
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "HotTag" && cookingProg < 3)
		{
			isCooking = true;
			smokeObject.SetActive(true);
			audioClip.Play();
			Debug.Log("It's getting hot in here");
		}
		if (col.gameObject.tag == "HotTag" && cookingProg >= 2){
				bsmokeObject.SetActive(true);
			}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "HotTag")
		{
		isCooking = false;
		smokeObject.SetActive(false);
		bsmokeObject.SetActive(false);
		audioClip.Stop();
		Debug.Log("Cooling down!");
		}
	}
	
	void BurgerReady()
	{
		cookingProg = 1;
		GetComponent<Renderer>().material = cookedMat;
		//this.gameObject.transform.localScale += new Vector3(0.1f, 0f, 0.1f);
		Debug.Log("ready!");
	}
	
	void BurgerIndicate()
	{
		cookingProg = 2;
		bsmokeObject.SetActive(true);
	}
	
	void BurgerBurnt()
	{
		cookingProg = 3;
		GetComponent<Renderer>().material = burntMat;
		smokeObject.SetActive(false);
		audioClip.Stop();
		audioBurn.Play();
		Debug.Log("burnt!");
	}
	
}
