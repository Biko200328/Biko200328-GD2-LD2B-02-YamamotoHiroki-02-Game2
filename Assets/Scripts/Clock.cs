using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
	PlayerMove playerMove;
	GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();

		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//ƒtƒ‰ƒO”½“]
			//‰º‚ª‚Á‚Ä‚¢‚éó‘Ô‚È‚çã‚°‚é‚æ‚¤‚É
			//ã‚ª‚Á‚Ä‚¢‚éó‘Ô‚È‚ç‰º‚°‚é‚æ‚¤‚É
			gameManager.isRise = !gameManager.isRise;
		}

		//©g‚ğÁ–Å‚³‚¹‚é
		Destroy(this.gameObject);
	}
}
