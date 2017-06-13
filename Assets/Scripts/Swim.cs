﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour {

	private int speed;
	public bool keepSwimming = true;
	public bool clickable = false;
	public int MIN_SPEED = 5;
	public int MAX_SPEED = 15;

	// Use this for initialization
	void Start () {
		speed = Random.Range (MIN_SPEED, MAX_SPEED);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!GlobalVariables.isPaused) {
			
			Vector3 pos = transform.localPosition;
			if ((speed > 0 && pos.x > 175) || (speed < 0 && pos.x < -175)) {
				if (keepSwimming) {
					speed *= -1;
					transform.Rotate (Vector3.up, 180);
					pos.y = (float)(.5 - Random.value) * 140;
				} else {
					Destroy (gameObject);
				}
			}

			transform.localPosition = new Vector3 (
				pos.x + (float)speed / 10,
				pos.y,
				pos.z
			);
		}
	}

	void OnMouseDown(){
		if (clickable && !GlobalVariables.isPaused) {
            GameObject source = GameObject.Find("Playsparkle");
            Sparklescript sparkle = source.GetComponent<Sparklescript>();
            sparkle.play();

            Debug.Log ("Add to aquarium");
			Destroy (gameObject);
		}
	}
}
