using UnityEngine;
using System.Collections;

public class playerControllerScript : MonoBehaviour {
	private GameObject cube;
	public Texture2D cursor; // ポインタの画像
	public  GameObject ball;
	private newRandomBall randomBall;
	private GameObject nBall;
	private ballScript ballsc;
	// Use this for initialization
	void Start () {
		Vector2 vector2 = new Vector2(cursor.width / 2 , cursor.height / 2);
		Cursor.SetCursor(cursor, vector2 , CursorMode.ForceSoftware);
		cube = GameObject.Find ("Player");
		randomBall = cube.GetComponent<newRandomBall> ();
		setObject ();

	}
	void setObject(){
		nBall = makeBall();
	}
	GameObject getObject(){
		return nBall;
	}
	// Update is called once per frame
	void Update () {
		
		bool push = Input.GetMouseButtonUp(0);
		if (push) {


			GameObject obj = getObject ();
			Vector3 position = Input.mousePosition;
			position.z = 2f;
			// マウス位置座標をスクリーン座標からワールド座標に変換する
			Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
			// ワールド座標に変換されたマウス座標を代入
			obj.transform.position = screenToWorldPointPosition;
			ballScript sc = obj.GetComponent<ballScript> ();
			sc.setShotFlag ();
			sc.setObject (obj);
			setObject();


		}
	}

	GameObject makeBall(){
		GameObject	nextBall  =	Instantiate (ball,transform.position,transform.rotation) as GameObject;//のちにマウスのポインタの座標に変更
		ballsc = nextBall.GetComponent<ballScript>();
		ballsc.setTag (randomBall.selectBall ().ToString());
		return nextBall;
	}
}
