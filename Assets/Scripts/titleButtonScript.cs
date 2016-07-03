using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleButtonScript : MonoBehaviour
{
	public	static string leveltag;
	public static int level;

	// Use this for initialization
	void Start ()
	{	
		level = 9;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnClick ()
	{switch (gameObject.transform.tag) {
		case "levelfirst":
			{
				level = 1;
				break;
			}
		case "levelsecond":
			{
				level = 2;
				break;
			}
		case "levelthird":
			{
				level = 3;
				break;
			}
		}

		SceneManager.LoadScene ("IScene4");


	}

	public static int getLevel ()
	{
		return level;
	}
}
