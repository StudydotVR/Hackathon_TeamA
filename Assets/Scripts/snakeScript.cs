﻿using UnityEngine;
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
	private GameObject player;
	private Vector3 startVec;
	private Vector3 EndVec;
	private float zPoint;
	public int mTag;
	private int deleteCount;
	private bool deleteFlag;
	public Material[] materials;
	private playerControllerScript playerSC;
	private bool gimFlag;
	// Use this for initialization
	void Start () {
		Count = 0;
		rigid = GetComponent<Rigidbody>();
		//Vector3 vec = randomMove();
		//rigid.AddForce (vec);
		deleteFlag = false;
		minX = -1f;
		maxX = 3f;
		minY = 0.7f;
		maxY = 4f;


		player = GameObject.Find ("Player");
		zPoint = player.transform.position.z;
		startVec = new Vector3 (Random.Range (minX, maxX) , transform.position.y, Random.Range(minY,maxY) );
		EndVec = new Vector3 (Random.Range (minX, maxX),Random.Range(minY,maxY), zPoint);
		playerSC = player.GetComponent<playerControllerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void setTag(int tag){
		mTag = tag;
		int soeji = mTag + 2;
		Debug.Log (soeji);
		if (titleButtonScript.getLevel () < 3) {
			
			GetComponent<Renderer> ().material = materials [soeji]; //レベルが２以下の時
		} else {
			GetComponent<Renderer> ().material = materials [5];
		}
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
		if (Count >= 10000) {
			Count = 0;
			EndVec = new Vector3 (Random.Range (minX, maxX), zPoint, Random.Range(minY,maxY));
			//transform.position = Vector3.Lerp (startVec, EndVec,Time.time );
			//方向転換
		} else {
			transform.position = Vector3.Lerp (transform.position, EndVec, Time.deltaTime *0.1f);
		}
		if (transform.position.y <= -50 ) {
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
			if (gimFlag) {
				
			} else {
				int tag = bsc.getTag ();
				mTag = mTag + tag;
				mTag =	Mathf.Clamp (mTag, -2, 2);
				if (mTag == 0) {
					deleteFlag = true;
				} else {
					deleteFlag = false;
				}
				int soeji = mTag + 2;
				GetComponent<Renderer> ().material = materials [soeji]; 
			}
		}
			Debug.Log (mTag);
			
		}
	public void setGim(bool gim){
		gimFlag = gim;
	}
}
