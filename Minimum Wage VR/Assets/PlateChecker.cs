using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateChecker : MonoBehaviour
{
    public int hasBunBot;
	public int hasBunTop;
	public int hasBurger;
	public int hasCheese;
	public int hasLettuce;
	public int hasTomato;
	
	public bool timeStart = false;
	public float timeLeft = 0.1f;
	
	public GameObject foodKiller;
 
	void Update()
		{
			if (timeStart == true)
			{
				timeLeft -= Time.deltaTime;
					if (timeLeft <= 0)
					{
						KillKiller();
						Debug.Log("Timer ended");
						timeStart = false;
						timeLeft = 0.1f;
					}
			}
		 
		}
 
	private void OnTriggerEnter (Collider other) {
		Debug.Log("Collision!");
		//RandomOrder randomOrder
		if (other.gameObject.name == "Tablo"){
			if (other.transform.TryGetComponent(out RandomOrder randomOrder)){
				if (randomOrder.bunBotReq == hasBunBot && randomOrder.bunTopReq == hasBunTop && randomOrder.burgerReq == hasBurger && randomOrder.cheeseReq == hasCheese && randomOrder.lettuceReq == hasLettuce && randomOrder.tomatoReq == hasTomato) {
				Debug.Log("Bliksem wat lekker omnomnom");
				randomOrder.WaitForNewOrder();
				foodKiller.SetActive(true);
				timeStart = true;
				}else {
				Debug.Log("Dit is niet mijn bestelling, ik wil de manager spreken!");
				} 
			}
		}
		
		if (other.gameObject.name == "BunBottom"){hasBunBot += 1;}
		if (other.gameObject.name == "BunTop"){hasBunTop += 1;}
		if (other.gameObject.name == "Burger"){
			if (other.transform.TryGetComponent(out Burger burger)){
			if (burger.cookingProg >0 && burger.cookingProg < 3){
			hasBurger += 1;}
			}
		}
		if (other.gameObject.name == "Cheese"){hasCheese += 1;}
		if (other.gameObject.name == "Lettuce"){hasLettuce += 1;}
		if (other.gameObject.name == "Tomato"){hasTomato += 1;}
	}
	
    private void OnTriggerExit (Collider other) {
        if (other.gameObject.name == "BunBottom"){hasBunBot -= 1;}
		if (other.gameObject.name == "BunTop"){hasBunTop -= 1;}
		if (other.gameObject.name == "Burger"){
			if (other.transform.TryGetComponent(out Burger burger)){
			if (burger.cookingProg >0 && burger.cookingProg < 3){
			hasBurger -= 1;}
			}
		}
		if (other.gameObject.name == "Cheese"){hasCheese -= 1;}
		if (other.gameObject.name == "Lettuce"){hasLettuce -= 1;}
		if (other.gameObject.name == "Tomato"){hasTomato -= 1;}
    }
	
	void KillKiller()
	{
		Debug.Log("Foodkiller uitgeschakeld");
		foodKiller.SetActive(false);
		
		hasBunBot = 0;
		hasBunTop = 0;
		hasBurger = 0;
		hasCheese = 0;
		hasLettuce = 0;
		hasTomato = 0;
	}
}
