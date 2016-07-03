using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour { //自分の玉 色のマテリアル準備
	private Rigidbody rigid;
	private GameObject ball;
	private bool shotFlag;
	public int mTag;
	private int i = 0;
	public Material[] materials;
	// Use this for initialization
	void Start () {
		shotFlag = false;
		rigid = GetComponent<Rigidbody> ();

	}
 
	// Update is called once per frame
	void Update () {
		i++;
		if (i >= 2000) {
			Destroy (gameObject);
			i = 0;
		}
	}
	public void setShotFlag(){
		shotFlag = true;
	}


	public	void setTag(int tag){
		mTag = tag;
		int soeji = mTag + 2;
		soeji = Mathf.Clamp (soeji, 0, 4);
		GetComponent<Renderer>().material = materials[soeji]; 
	}
	public int getTag(){
		return mTag;
	}
	void FixedUpdate(){
		if (shotFlag) {
			rigid.AddForce (0,0, Mathf.Abs(transform.position.z)  * 10);//まっすぐ飛ばす


		}
		if (transform.position.z >= 10) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "bullet")
			Destroy (gameObject);

	}

}
