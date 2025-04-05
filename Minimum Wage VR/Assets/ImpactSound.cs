using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip impactSfx;
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > 1)
		{
			audioSource.clip = impactSfx;
			audioSource.Play();
		}
	}
}
