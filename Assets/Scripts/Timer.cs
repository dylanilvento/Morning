using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {
	float time = 390f;
	Text timer;
	double minutes;
	string fmt = "00";
	//bool roundEnd = false;

	// Use this for initialization
	void Start () {
		timer = GetComponent<Text>();
		minutes = (Math.Truncate(time) % 60);
		timer.text = ((int) time / 60) + ":" + minutes.ToString(fmt);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			
		}
	}

	public void IncrementTime () {
		time += 15f;
		minutes = (Math.Truncate(time) % 60);
		timer.text = ((int) time / 60) + ":" + minutes.ToString(fmt);

		if (time == 495f) {

		}
	}

	public float GetTime () {
		return time;
	}
}
