using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square2 : MonoBehaviour
{
	GameManager gameManager;

	Spuare1 spuare1;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();
		//var pos = transform.position;
		//pos.y = -gameManager.stageSize / 2;
		//transform.position = pos;
		GameObject spuare1Obj = GameObject.Find("Square1");
		spuare1 = spuare1Obj.GetComponent<Spuare1>();
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

			if (collision.gameObject.tag == "wave1")
			{
				if (pos.y >= 82.31f)
				{
					collision.gameObject.transform.position = pos;
				}
			}
			
			if(collision.gameObject.tag == "wave2")
			{
				if (pos.y >= -4.37f)
				{
					collision.gameObject.transform.position = pos;
				}
			}

			if (collision.gameObject.tag == "Item")
			{
				collision.gameObject.transform.position = pos;
			}
		}
	}
}
