using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Keikoku : MonoBehaviour {

	public Material[]  materials; 
	private AudioSource warning03;
	private AudioSource failed;
	public AudioClip[] sounds;
	public Object[] HPImages;
	public GameObject player;
	public GameObject text;
	int i = 0;
	public 
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material = materials [0];
		warning03 = GetComponent<AudioSource>();
		failed = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "bullet") {
			warning03.PlayOneShot (sounds [0]);
			GetComponent<Renderer> ().material = materials [1];
		}
	}

	void OnTriggerExit(Collider collider){
		
		if (collider.gameObject.tag == "bullet") {
			GetComponent<Renderer> ().material = materials [0]; 
			Destroy (collider.gameObject);
			Destroy (HPImages [i]);
			i++;


			if (i == 5) {
				GetComponent<Renderer> ().material = materials [1];
				failed.PlayOneShot (sounds [1]);
				Text tex = text.GetComponent<Text> ();
				tex.color = Color.white;
				Destroy (player);

			} 
			}
				
			
		}

	

}
