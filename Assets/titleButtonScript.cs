using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class titleButtonScript : MonoBehaviour {
	static string leveltag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		leveltag = gameObject.tag;
		SceneManager.LoadScene ("TScene");

	}
}
