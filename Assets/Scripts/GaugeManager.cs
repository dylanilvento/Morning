using UnityEngine;
using System.Collections;

public class GaugeManager : MonoBehaviour {

    public int numbGood = 2;


    bool[] goodZoneBool;


	// Use this for initialization
	void Start () {
	   goodZoneBool = new bool[numbGood];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGoodZoneSucess(int index, bool val)
    {
        goodZoneBool[index] = val;
    }
    public bool[] GetZoneBool()
    {
        return goodZoneBool;
    }

    public bool GetZoneBool(int index)
    {
        return goodZoneBool[index];
    }

}
