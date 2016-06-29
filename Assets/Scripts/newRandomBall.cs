using UnityEngine;
using System.Collections;

public class newRandomBall : MonoBehaviour {
	private int variety;//玉の種類
	// Use this for initialization
	void Start () {
		
		selectBall ();

	}
	public	int selectBall(){
		int number = Random.Range (1, variety);
		return number;
	}
	// Update is called once per frame
	void Update () {
		selectBall ();
	}
}
