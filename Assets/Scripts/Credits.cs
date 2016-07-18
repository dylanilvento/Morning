using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {
	public string[] passStrings = new string[9];
	public string[] failStrings = new string[9];
	bool[] results = new bool[9];

	Text creditText;
	Image creditBG;

	// Use this for initialization
	void Start () {
		
		creditText = GameObject.Find("Credits Text").GetComponent<Text>();
		creditText.color = Color.clear;
		creditBG = GameObject.Find("Credits Background").GetComponent<Image>();
		creditBG.color = Color.clear;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetResults(bool[] val) {
		results = val;
	}

	public void StartCredits (bool[] val) {

		results = val;
		
		foreach (bool result in results) {
			print(result);
		}

		StartCoroutine("RunCredits");

	}

	IEnumerator RunCredits () {
		int ii = 0;
		creditBG.color = new Color (1f, 1f, 1f, 0.5f);
		foreach (bool result in results) {
			

			string creditStr = (result) ? passStrings[ii] : failStrings[ii];
			creditText.text = creditStr;

			for (float jj = 0f; jj <= 1f; jj+= 0.1f) {
				creditText.color = new Color (0f, 0f, 0f, jj);
				yield return new WaitForSeconds(0.05f);
			}
				
				yield return new WaitForSeconds(6f);

			for (float jj = 1f; jj > 0f; jj-= 0.1f) {
				creditText.color = new Color (0f, 0f, 0f, jj);
				yield return new WaitForSeconds(0.05f);
			}
			creditText.color = Color.clear;

			yield return new WaitForSeconds(2f);
			ii++;
		}
	}
}
