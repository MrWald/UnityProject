﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {

	// Use this for initialization
	void Start() {
		StartCoroutine (DestroyLater());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Launch(float direction)
	{
		GetComponent<Rigidbody2D>().velocity=new Vector2(direction, 0);
	}
	
	IEnumerator DestroyLater() {
		yield return new WaitForSeconds (3.0f); Destroy (gameObject);
	}
	
	protected override void OnRabitHit (PlayerController rabit) 
	{
		rabit.GetComponent<Animator>().SetBool("death", true);
	}
}
