using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour { //自分の玉 色のマテリアル準備
	private Rigidbody rigid;
	private GameObject ball;
	private bool shotFlag;
	public string mTag;
	// Use this for initialization
	void Start () {
		shotFlag = false;

	}
 
	// Update is called once per frame
	void Update () {
		
	}
	public void setShotFlag(){
		shotFlag = true;
	}
	public void setObject(GameObject obj){
		ball = obj;
		rigid = ball.GetComponent<Rigidbody> ();
	}
	public	void setTag(string tag){
		mTag = tag;
	}

	void FixedUpdate(){
		if (shotFlag) {
			rigid.AddForce (ball.transform.forward * 10);//まっすぐ飛ばす
			if (ball.transform.position.z >= -10) {
				Destroy (ball, 1f);
			}
		}

	}
}
