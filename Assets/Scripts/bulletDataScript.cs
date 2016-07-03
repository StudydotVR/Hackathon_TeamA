using UnityEngine;
using System.Collections;

public class bulletDataScript : MonoBehaviour {
	private string[] chemicalFormulaArray = new string[] {
		"HCl",
		"HNO",
		"HSO",
		"CHCOOH",
		"HCN",
		"COOH",
		"HS",
		"NAOH",
		"KOH",
		"CaOH",
		"BaOH",
		"NH",
		"CuOH",
		"MgOH",
		"FeOH"
	};
	private int[] tagArray = new int[] {
		-2, -2, -2, -2, -1, -1, -1, -1, 2,2, 2,2, 1, 1, 1, 1
	};

	public Texture[] textImages;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int[] getTagArray(){
		return tagArray;
	}
	public int getTag(int i){
		return tagArray [i];
	}
	public string[] getchemicalArray(){
		return chemicalFormulaArray;
	}
	public Texture[] getImage(){
		return textImages;
	}
}
