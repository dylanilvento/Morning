using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnMinigame : MonoBehaviour {
	public GameObject minigame;
	GameObject camera;
	bool playerCollided = false;
	bool spawned = false;
	Player player;
	Text clockBG, clock;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera");
		player = GameObject.Find("Player").GetComponent<Player>();

		clockBG = GameObject.Find("Clock Background").GetComponent<Text>();
		clock = GameObject.Find("Clock").GetComponent<Text>();


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space") && playerCollided && !spawned) {
			player.SetCanMove(false);
			spawned = true;
			SpawnGame();
		}
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Contains("Player")) {
			playerCollided = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Contains("Player")) {
			playerCollided = false;
		}
	}

	void SpawnGame () {
		clock.enabled = false;
		clockBG.enabled = false;
		GameObject go = (GameObject) Instantiate(minigame);
		go.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y + 2f, 0f);

	}

}
