using UnityEngine;
using System.Collections;

public class Keikoku : MonoBehaviour {

	public Material[]  materials; 
	private AudioSource warning03;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material = materials [0];
		warning03 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Teki") {
			GetComponent<Renderer> ().material = materials [1];
			warning03.PlayOneShot(sound);
		}
	}

	void OnTriggerExit(Collider collider){
				if (collider.gameObject.tag == "Teki") {
			GetComponent<Renderer>().material = materials[0]; 
		}
	}

}
