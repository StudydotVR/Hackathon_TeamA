using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class newRandomBall : MonoBehaviour {
	private int myVariety;//玉の種類-1
	private int totalVariety;//中性含めた玉の種類-1
	public GameObject enemyBall;
	public GameObject originEnemy;
	public bulletDataScript bullet;
	// Use this for initialization
	void Start () {
		myVariety = 4;
		//totalVariety = 9;
		selectBall ();
	}
	public	int selectBall(){
		int number = Random.Range (0, 4);
		if (number < 2) {			
			number = number - 2;
		} else {
			number--;
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
			Vector3 vec = new Vector3 (Random.Range (-1f, 2f) , Random.Range (0.7f, 1.2f), 7f);
			GameObject enemy =	Instantiate(enemyBall,vec,enemyBall.transform.rotation) as GameObject;
			snakeScript sSc = enemy.GetComponent<snakeScript> ();
			RawImage rawImage;
			GameObject canvas = enemy.transform.FindChild ("Canvas").gameObject;
			GameObject target = canvas.transform.FindChild ("RawImage").gameObject;
				   rawImage = target.GetComponent<RawImage> ();
					int chemicalNum = selectEnemy ();
					int[] tags = bullet.getTagArray ();
					int tag = tags [chemicalNum];
					sSc.setTag(tag);
					Texture[] texs = bullet.getImage ();
					Texture texture = texs [chemicalNum];
					
				//	string[] array = bullet.getchemicalArray ();
				//	string path = "Textures/" + array [chemicalNum];
				//	Texture tex = Resources.Load(path) as Texture;
			rawImage.texture = texture;
				
		//	}
			//GameObject canvas = enemy.transform.FindChild("Canvas").gameObject;
			//GameObject Image  = canvas.gameObject.


		}

	}
	public int selectEnemy(){
		return Random.Range (0, 16);
	}

}
