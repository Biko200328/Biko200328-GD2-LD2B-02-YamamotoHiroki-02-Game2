using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	GameManager gameManager;

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
			gameManager.GameEnd(gameManager.isClear);
		}
	}
}
