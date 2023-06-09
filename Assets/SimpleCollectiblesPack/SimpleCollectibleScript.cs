﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Type1, Type2, Type3, Type4, Type5}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	//public AudioClip collectSound;

	public GameObject collectEffect;

	public Health health;

	public AudioManager audiomanager;

	// Use this for initialization
	void Start () 
	{
		audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		
		
		if (other.tag == "Player") {
			Collect (other.GetComponent<Entities>());
		}
	}

	public void Collect(Entities player)
	{
		//if(collectSound)
		//	AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType) {

			//Add in code here;
			//audiomanager.Play("Coin");
			audiomanager.PlaySfx(audiomanager.coin);
			Debug.Log ("Sume 100 puntos");

		}
		if (CollectibleType == CollectibleTypes.Type1) {

			//Add in code here;
			player.health.LifeRecovery(5);

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type2) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type3) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type4) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}

		Destroy (gameObject);
	}
}
