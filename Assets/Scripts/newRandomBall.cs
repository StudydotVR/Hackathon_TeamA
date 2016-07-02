using UnityEngine;
using System.Collections;

public class newRandomBall : MonoBehaviour {
	private int myVariety;//玉の種類-1
	private int totalVariety;//中性含めた玉の種類-1
	public GameObject enemyBall;
	public GameObject originEnemy;
	// Use this for initialization
	void Start () {
		myVariety = 4;
		//totalVariety = 9;
		selectBall ();

	}
	public	int selectBall(){
		int number = Random.Range (0, 4);
		if (number > 1) {
			number = number + 1 ;
		} else {			
			number = number - 4;

		}
		Debug.Log (number);
		return number;
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeEnemy(){
		int enemyCount = Random.Range (1, 5);
		for (int i = 0; i < enemyCount; i++) {
			Vector3 vec = new Vector3 (Random.Range (-3f, 3f)  - 4f, Random.Range (0.5f, 1f), -3f);
			GameObject enemy =	Instantiate(enemyBall,vec,enemyBall.transform.rotation) as GameObject;
			snakeScript sSc = enemy.GetComponent<snakeScript> ();
			sSc.setTag(selectBall());
		}

	}

}
