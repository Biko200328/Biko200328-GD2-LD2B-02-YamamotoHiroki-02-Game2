using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square2 : MonoBehaviour
{
	GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();
		var pos = transform.position;
		pos.y = -gameManager.stageSize / 2;
		transform.position = pos;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameManager.isRise == true)
		{
			var pos = collision.gameObject.transform.position;

			pos.y += gameManager.stageSize;

			collision.gameObject.transform.position = pos;
		}
	}
}