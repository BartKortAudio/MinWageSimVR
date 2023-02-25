using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateChecker : MonoBehaviour
{
    public bool burgerCheck;
	public Material plateMat;
	public Material checkMat;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision col)
	{
		burgerCheck = true;
		GetComponent<Renderer>().material = checkMat;
	}
	
	void OnCollisionExit(Collision col)
	{
		burgerCheck = false;
		GetComponent<Renderer>().material = plateMat;
	}
}
