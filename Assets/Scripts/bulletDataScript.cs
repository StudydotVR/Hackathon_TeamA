using UnityEngine;
using System.Collections;

public class bulletDataScript : MonoBehaviour {
	private string[] chemicalFormulaArray;
	private int[] tagArray;
	// Use this for initialization
	void Start () {
		chemicalFormulaArray = new string[] {
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
		tagArray = new int[] {
			-3, -3, -3, -2, -2, -2, -2, -2, 3, 3, 3,3, 2, 2, 2, 2
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int[] getTagArray(){
		return tagArray;
	}

	public string[] getchemicalArray(){
		return chemicalFormulaArray;
	}
}
