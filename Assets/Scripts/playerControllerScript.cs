using UnityEngine;
using System.Collections;

public class playerControllerScript : MonoBehaviour {
	private GameObject cube;
	public GameObject ball;
	private newRandomBall randomBall;
	// Use this for initialization
	void Start () {
		cube = GameObject.Find ("Player");
		randomBall = cube.GetComponent<newRandomBall> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		bool push = Input.GetMouseButton (0);
		if (push) {
			GameObject nextBall  =	Instantiate (ball,transform.forward * 2,transform.rotation) as GameObject;//のちにマウスのポインタの座標に変更
			ballScript ballsc = nextBall.GetComponent<ballScript>();
			ballsc.setTag (randomBall.selectBall ().ToString());

		}
	}


}
