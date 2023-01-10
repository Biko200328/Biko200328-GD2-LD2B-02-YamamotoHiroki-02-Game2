using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spuare1 : MonoBehaviour
{
	GameManager gameManager;

	[SerializeField] GameObject Idea1;
	[SerializeField] GameObject Idea2;
	[SerializeField] GameObject Idea3;

	float idea1PosY;
	public float idea2PosY;
	float idea3PosY;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameObject = GameObject.Find("GameManager");
		gameManager = gameObject.GetComponent<GameManager>();
		//var pos = transform.position;
		//pos.y = gameManager.stageSize / 2;
		//transform.position = pos;

		idea1PosY = Idea1.transform.position.y;
		idea2PosY = Idea2.transform.position.y;
		idea3PosY = Idea3.transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(gameManager.isRise == false)
		{
			var pos = collision.gameObject.transform.position;
			pos.y -= gameManager.stageSize;

			if (collision.gameObject.tag == "wave1" && pos.y >= idea1PosY)
			{
				collision.gameObject.transform.position = pos;
			}

			if (collision.gameObject.tag == "wave2"/* && pos.y >= idea2PosY*/)
			{
				collision.gameObject.transform.position = pos;
			}

			if (collision.gameObject.tag == "Item")
			{
				collision.gameObject.transform.position = pos;
			}
		}
	}
}
