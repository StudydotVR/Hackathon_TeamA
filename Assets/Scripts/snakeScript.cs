using UnityEngine;
using System.Collections;

public class snakeScript : MonoBehaviour {
	private int Count;
	private GameObject self;
	private Rigidbody rigid;
	public GameObject enemy;
	private float maxX;
	private float minX;
	private float maxY;
	private float minY;
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject player;
	private Vector3 startVec;
	private Vector3 EndVec;
	private float zPoint;
	public int mTag;
	private int deleteCount;
	private bool deleteFlag;
	public Material[] materials;
	private playerControllerScript playerSC;
	// Use this for initialization
	void Start () {
		Count = 0;
		rigid = GetComponent<Rigidbody>();
		//Vector3 vec = randomMove();
		//rigid.AddForce (vec);
		deleteFlag = false;
		minX = -5.2f;
		maxX = -2.96f;
		minY = 0.0f;
		maxY = 0.1f;
		zPoint = player.transform.position.z/ 3;
		startVec = new Vector3 (Random.Range ( minX, maxX), Random.Range (minY, maxY), transform.position.z);
		EndVec = new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), zPoint);
		player = GameObject.Find ("Player");
		playerSC = player.GetComponent<playerControllerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		

	}
	public void setTag(int tag){
		mTag = tag;
		int soeji = mTag + 4;
		Debug.Log (soeji);
		GetComponent<Renderer>().material = materials[soeji]; 
	}
	void FixedUpdate(){
		if (deleteFlag) {
			deleteCount++;
			if (deleteCount >= 50) {
				
				playerSC.point ();
				Destroy (gameObject);
			}
		}
		Count++;
		startVec = transform.position;
		transform.position = Vector3.Lerp (startVec, EndVec,Time.deltaTime * 0.01f );
		if (Count >= 50) {
			zPoint = zPoint + zPoint;
			Count = 0;
			EndVec = new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), zPoint);
			//transform.position = Vector3.Lerp (startVec, EndVec,Time.time );
			//方向転換
		}
		if (transform.position.z <= -200 ) {
			Destroy (gameObject,1f);
		}

	}

/*	Vector3 randomMove(){
		Vector3 vec = new Vector3 (Random.Range (-10f, 10f) , Random.Range (-1f, 2f) , -5f);
		return vec;
	}*/

	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "myBullet") {
			deleteCount = 0;
			GameObject myBullet = other.collider.gameObject;
			ballScript bsc = myBullet.GetComponent<ballScript> ();
			int tag = bsc.getTag ();
			mTag = mTag + tag;
			mTag =	Mathf.Clamp (mTag, -4, 4);
			if (mTag == 1 || mTag == 0 || mTag == -1) {
				deleteFlag = true;
			} else {
				deleteFlag = false;
			}
			}
			Debug.Log (mTag);
			int soeji = mTag + 4;
			GetComponent<Renderer>().material = materials[soeji]; 
		}


}
