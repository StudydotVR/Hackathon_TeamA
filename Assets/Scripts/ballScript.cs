using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour { //自分の玉
	private Rigidbody rigid;
	public GameObject ball;
	private string mTag;
	// Use this for initialization
	void Start () {
		
		rigid = GetComponent<Rigidbody>();
		rigid.AddForce (0,0,0);//まっすぐ飛ばす

	}
 
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z >= -5) {
			Destroy (ball, 1f);
		}
	}

	public	void setTag(string tag){
		mTag = tag;
	}

}
