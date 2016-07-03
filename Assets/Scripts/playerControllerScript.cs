using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playerControllerScript : MonoBehaviour {
	private static int level; // 難易度　１〜３
	private GameObject cube;
	public Texture2D cursor; // ポインタの画像
	public  GameObject ball;
	private newRandomBall randomBall;
	private GameObject nBall;
	private ballScript ballsc;
	private int newEnemyCount ;
	private int timeCount;
	public  GameObject pointText;
	private AudioSource beamgun3;
	public AudioClip sound;
	private pointTextScript Psc;
	public bulletDataScript bulDataSC;
	public GameObject nextImage;
	public Texture[] textures;
	// Use this for initialization
	void Start () {
		Vector2 vector2 = new Vector2(cursor.width / 2 , cursor.height / 2);
		Cursor.SetCursor(cursor, vector2 , CursorMode.ForceSoftware);
		cube = GameObject.Find ("Player");
		randomBall = cube.GetComponent<newRandomBall> ();
		setObject ();
		randomBall.MakeEnemy ();
		timeCount = 0;
		Psc = pointText.GetComponent<pointTextScript> ();
		beamgun3 = GetComponent<AudioSource>();
	}
	void setObject(){
		nBall = makeBall();
	}
	GameObject getObject(){
		return nBall;
	}
	// Update is called once per frame
	void Update () {
		timeCount++;

		if (timeCount >= 400) {
			timeCount = 0;
			randomBall.MakeEnemy ();
		}
		bool push = Input.GetMouseButtonUp(0);
		if (push) {
			GameObject obj = getObject ();
			if (obj != null) {
				beamgun3.PlayOneShot(sound);
				Vector3 position = Input.mousePosition;
				position.z = 0f;
				// マウス位置座標をスクリーン座標からワールド座標に変換する
				Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint (position);
				// ワールド座標に変換されたマウス座標を代入*/
				obj.transform.position = screenToWorldPointPosition;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);	// クリックした位置から真っ直ぐ奥に行く光線.
				RaycastHit hitInfo ;												// ヒット情報を格納する変数を作成
				Vector3 vec = ray.direction.normalized;
				if (Physics.Raycast (ray, out hitInfo)) {
					obj.GetComponent<Rigidbody> ().velocity = vec * 4;
					// Do something with the object that was hit by the raycast.
				} else {
					ballsc.setShotFlag ();
				}
			}
			setObject();
		}
	}

	GameObject makeBall(){
		GameObject	nextBall  =	Instantiate (ball,transform.position,ball.transform.rotation) as GameObject;//のちにマウスのポインタの座標に変更
		ballsc = nextBall.GetComponent<ballScript>();
		int[] tag = randomBall.selectBall ();
		ballsc.setTag (tag[1]);
		RawImage img = nextImage.GetComponent<RawImage> ();
		Texture texture = textures [tag[0]];
		img.texture = texture;
		return nextBall;
	}
	public void point (){
		Psc.disPlayText (100);
	}
}
