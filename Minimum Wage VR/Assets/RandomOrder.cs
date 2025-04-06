using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomOrder : MonoBehaviour
{
	
	public int burgerReq = 0;
	public int cheeseReq = 0;
	public int lettuceReq = 0;
	public int tomatoReq = 0;
	public int bunBotReq = 1;
	public int bunTopReq = 1;
	
	public bool timeStart = false;
	public float timeLeft = 30.0f;
	
	public GameObject textSign;
	
	public TMP_Text burgerTxt;
	public TMP_Text cheeseTxt;
	public TMP_Text lettuceTxt;
	public TMP_Text tomatoTxt;
	
    // Start is called before the first frame update
    void Start()
    {
		
		CreateRandomOrder();

		
    }
	

    // Update is called once per frame
    void Update()
    {
     
		if (timeStart == true)
		{
			
			timeLeft -= Time.deltaTime;
			
				if (timeLeft <= 0)
				{
					CreateRandomOrder();
					timeStart = false;
					timeLeft = 30.0f;
				}
			
		}
	 
    }
	
	//Creeërt een random order
	void CreateRandomOrder()
	{
		
		burgerReq = Random.Range(0, 10);
			
			if (burgerReq > 1)
			{
				burgerReq = Random.Range(1, 4);
			}
			
		cheeseReq = Random.Range(0, 2);
			
			if (cheeseReq > 0)
			{
				cheeseReq = Random.Range(1, 3);
			}
			
		lettuceReq = Random.Range(0, 2);
		
			if (lettuceReq > 0)
			{
				lettuceReq = Random.Range(1, 3);
			}
			
		tomatoReq = Random.Range(0, 2);
		
			if (tomatoReq > 0)
			{
				tomatoReq = Random.Range(1, 3);
			}
		
		textSign.SetActive(true);	
		burgerTxt.text = "Burger  x  " + burgerReq;
		cheeseTxt.text = "Cheese  x  " + cheeseReq;
		lettuceTxt.text = "Lettuce  x  " + lettuceReq;
		tomatoTxt.text = "Tomato  x  " + tomatoReq;
		
	}
	
	//Reset order en begint timer
	public void WaitForNewOrder()
	{
		
	textSign.SetActive(false);
		
	burgerReq = 0;
	cheeseReq = 0;
	lettuceReq = 0;
	tomatoReq = 0;
	bunBotReq = 1;
	bunTopReq = 1;
	
	timeStart = true;
	
	Debug.Log("Nieuwe klant, here comes the money");
		
	}
	
}

