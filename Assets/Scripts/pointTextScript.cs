using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class pointTextScript : MonoBehaviour {
	public static int totalScore = 0;
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void disPlayText(int score){
		totalScore = totalScore + score;
		Debug.Log (totalScore);
		text.text = totalScore.ToString ();
	}
}
