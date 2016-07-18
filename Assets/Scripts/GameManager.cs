using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	Player player;
	bool[] actions = new bool[9];
	//0 = alarm
	//1 = glasses
	//2 = shower
	//3 = teeth
	//4 = pants
	//5 = toaster
	//6 = coffee
	//7 = weather
	//8 = shoes
	Camera mainCam, creditCam;
	Text clockBG, clock;
	Timer timer, timerBG;
	Credits credits;

	// Use this for initialization
	
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
		/*foreach (bool action in actions) {
			print(action);
		}*/
		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		creditCam = GameObject.Find("Credits Camera").GetComponent<Camera>();
		
		clockBG = GameObject.Find("Clock Background").GetComponent<Text>();
		clock = GameObject.Find("Clock").GetComponent<Text>();
		clock.color = Color.red;
		
		timer = clock.GetComponent<Timer>();
		timerBG = clockBG.GetComponent<Timer>();

		credits = GetComponent<Credits>();

		clock.enabled = false;
		clockBG.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetActions (int index, bool val) {
		actions[index] = val;
	}

	public bool GetAction (int index) {
		return actions[index];
	}

	public bool[] GetActions () {
		return actions;
	}


	public void SetMinigameState (string name, string state) {
		//StartCoroutine("ChangeState");
		StartCoroutine(ChangeState(name, state));
	}

	IEnumerator ChangeState (string name, string state) {
		print("Name: " + name + ", State: " + state);
		Animator anim = null;
		GameObject go = null;
		float loseTime = 0f;
		float winTime = 0f;
		int index = 0;
		bool incr = true;

		if (name.Contains("Alarm")) {
			go = GameObject.Find("Alarm Group");
			anim = GameObject.Find("Alarm Minigame").GetComponent<Animator>();
			loseTime = 4f;
			winTime = 2f;
			index = 0;

			if (state.Contains("win")) {
				incr = false;
			}

		}

		else if (name.Contains("Glasses")) {
			go = GameObject.Find("Glasses Group(Clone)");
			anim = GameObject.Find("Glasses Minigame").GetComponent<Animator>();
			loseTime = 4f;
			winTime = 3f;
			index = 1;

		}

		else if (name.Contains("Shower")) {
			go = GameObject.Find("Shower Group(Clone)");
			anim = GameObject.Find("Shower Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 2f;
			index = 2;

		}

		else if (name.Contains("Toothbrush")) {
			go = GameObject.Find("Toothbrush Group(Clone)");
			anim = GameObject.Find("Toothbrush Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 2f;
			index = 3;

		}

		else if (name.Contains("Pant")) {
			go = GameObject.Find("Pants Group(Clone)");
			anim = GameObject.Find("Pants Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 4f;
			index = 4;
		}

		else if (name.Contains("Toast")) {
			go = GameObject.Find("Toaster Group(Clone)");
			anim = GameObject.Find("Toaster Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 3f;
			index = 5;

		}

		else if (name.Contains("Coffee")) {
			go = GameObject.Find("Coffee Group(Clone)");
			anim = GameObject.Find("Coffee Minigame").GetComponent<Animator>();
			loseTime = 4f;
			winTime = 3f;
			index = 6;

		}
		
		else if (name.Contains("Weather")) {
			go = GameObject.Find("Weather Group(Clone)");
			anim = GameObject.Find("Weather Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 4f;
			index = 7;

		}

		else if (name.Contains("Shoe")) {
			go = GameObject.Find("Shoe Group(Clone)");
			anim = GameObject.Find("Shoe Minigame").GetComponent<Animator>();
			loseTime = 3f;
			winTime = 2f;
			index = 8;

		}


		//********************
		if (state.Contains("lose")) {
			anim.SetTrigger("lose");
			yield return new WaitForSeconds(loseTime);
			Destroy(go);

		}
		else if (state.Contains("win")) {
			anim.SetTrigger("win");
			actions[index] = true;
			yield return new WaitForSeconds(winTime);
			Destroy(go);

		}

		if (incr) {
			timer.IncrementTime();
			timerBG.IncrementTime();
		}

		if (timer.GetTime() < 510f) {
			clock.enabled = true;
			clockBG.enabled = true;

			player.SetCanMove(true);
		}

		else {
			EndGame();
		}
		
	}

	void EndGame () {
		mainCam.enabled = false;
		creditCam.enabled = true;

		Analytics.CustomEvent("gameCompleted", new Dictionary<string, object> 
			{
				{ "gameCompleted", true }

			});

		credits.StartCredits(actions);
	}






}
