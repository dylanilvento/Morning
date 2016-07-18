using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnTextbox : MonoBehaviour {

	public GameObject textbox;
	//GameObject camera;
	bool playerCollided = false;
	bool spawned = false;
	Player player;

	GameObject go;

	public string boxText;
	// Use this for initialization
	void Start () {
		//camera = GameObject.Find("Main Camera");
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space") && playerCollided && !spawned) {
			player.SetCanMove(false);
			spawned = true;
			print("Spawning text");
			SpawnText();
		}

		else if (Input.GetKeyDown("space") && playerCollided && spawned) {
			player.SetCanMove(true);
			spawned = false;
			//SpawnText();
			Destroy(go);
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
			spawned = false;
		}
	}

	void SpawnText () {
		print("Spawned text");
		go = (GameObject) Instantiate(textbox);
		go.name = "Text Box Group";
		go.transform.SetParent(GameObject.Find("Canvas").transform, false);
		go.transform.localPosition = new Vector2 (-400f, -350f);
		Text text = GameObject.Find("Text Box Text").GetComponent<Text>();
		text.text = boxText;

	}
}
