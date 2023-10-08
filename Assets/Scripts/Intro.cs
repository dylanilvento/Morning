using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    GameObject logoGO;
    SpriteRenderer logo;
    SpriteRenderer bg;

    bool canPlay = false;

    //AsyncOperation loading;

    public Text[] startText = new Text[8]; //index 6 is title

    // Use this for initialization
    void Start()
    {
        logoGO = GameObject.Find("Ward Logo");
        logo = logoGO.GetComponent<SpriteRenderer>();
        bg = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        //bg.color = new Color(0.22f, 0.22f, 0.22f, 1f);

        logo.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine("StartIntro");

        foreach (Text word in startText)
        {
            word.color = new Color(1f, 1f, 1f, 0f);
        }

        //bool gameStarted = true;
        //Analytics.CustomEvent("gameStart", new Dictionary<string, object>
        //	{
        //		{ "gameStarted", true }

        //	});

        //loading = SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canPlay)
        {
            StartCoroutine(LoadingScene());
        }
    }

    IEnumerator LoadingScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator StartIntro()
    {
        // yield return new WaitForSeconds(2f);

        // for (float i = 0.1f; i <= 1f; i += 0.1f) {
        // 	logo.color = new Color(1f, 1f, 1f, i);
        // 	yield return new WaitForSeconds(0.05f);
        // }

        // yield return new WaitForSeconds(3f);

        // for (float i = 1f; i >= 0f; i -= 0.1f) {
        // 	logo.color = new Color(1f, 1f, 1f, i);
        // 	yield return new WaitForSeconds(0.01f);
        // }

        // Destroy(logoGO);

        yield return new WaitForSeconds(0.5f);

        for (float j = 0.922f; j >= 0.22f; j = j - 0.078f)
        {
            bg.color = new Color(j, j, j, 1f);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 6; i++)
        {
            for (float j = 0.1f; j <= 1f; j += 0.1f)
            {
                startText[i].color = new Color(1f, 1f, 1f, j);
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);

        for (float j = 1f; j > -0.1f; j -= 0.1f)
        {
            for (int i = 0; i < 6; i++)
            {
                startText[i].color = new Color(1f, 1f, 1f, j);
            }

            yield return new WaitForSeconds(0.05f);
        }

        for (float j = 0.1f; j <= 1f; j += 0.1f)
        {
            startText[6].color = new Color(1f, 1f, 1f, j);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        for (float j = 0.1f; j <= 1f; j += 0.1f)
        {
            startText[7].color = new Color(1f, 1f, 1f, j);
            yield return new WaitForSeconds(0.05f);
        }

        canPlay = true;
    }
}
