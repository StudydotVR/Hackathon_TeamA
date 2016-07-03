using UnityEngine;
using System.Collections;

public class Keikoku : MonoBehaviour {

	public Material[]  materials; 
	private AudioSource warning03;
	public AudioClip sound;
	public Object[] HPImages;
	int i = 0;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material = materials [0];
		warning03 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "bullet") {
			warning03.PlayOneShot(sound);
			GetComponent<Renderer> ().material = materials [1];
		}
	}

	void OnTriggerExit(Collider collider){
		
		if (collider.gameObject.tag == "bullet") {
			GetComponent<Renderer> ().material = materials [0]; 
			Destroy (collider.gameObject);


			Destroy (HPImages [i]);
			i++;

				
			
		}
	}
	

}
