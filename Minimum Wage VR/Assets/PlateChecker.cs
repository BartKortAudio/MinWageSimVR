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
 
 
	private void OnTriggerEnter (Collider other) {
		Debug.Log("Collision!");
		//RandomOrder randomOrder
		if (other.gameObject.name == "Tablo"){
			if (other.transform.TryGetComponent(out RandomOrder randomOrder)){
				if (randomOrder.bunBotReq == hasBunBot && randomOrder.bunTopReq == hasBunTop && randomOrder.burgerReq == hasBurger && randomOrder.cheeseReq == hasCheese && randomOrder.lettuceReq == hasLettuce && randomOrder.tomatoReq == hasTomato) {
				Debug.Log("Bliksem wat lekker omnomnom");
				//randomOrder.WaitForNewOrder();
				}else {
				Debug.Log("Dit is niet mijn bestelling, ik wil de manager spreken!");
				} 
			}
		}
		
		if (other.gameObject.name == "Bun_Bottom"){hasBunBot += 1;}
		if (other.gameObject.name == "Bun_Top"){hasBunTop += 1;}
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
        if (other.gameObject.name == "Bun_Bottom"){hasBunBot -= 1;}
		if (other.gameObject.name == "Bun_Top"){hasBunTop -= 1;}
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
}
