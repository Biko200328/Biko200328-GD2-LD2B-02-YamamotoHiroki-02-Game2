using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea : MonoBehaviour
{
	GameManager gameManager;

	public GameObject a;

	// Start is called before the first frame update
	void Start()
	{
		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player")
		{
			gameManager.IdeaSound();
			gameManager.isClear = true;
			a.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
