using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
	[SerializeField] GameObject hirameki;
	[SerializeField] GameObject clock;

	[SerializeField] private float spawnTimer = 3.0f;
	private float resetTime;

	bool isCreate = false;

	GameManager gameManager;
	PlayerMove playerMove;

	[SerializeField] private int randomNum = 5;

	// Start is called before the first frame update
	void Start()
	{
		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();

		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();

		resetTime = spawnTimer;
	}

	// Update is called once per frame
	void Update()
	{
		spawnTimer -= Time.deltaTime;
		if(spawnTimer <= 0)
		{
			isCreate = true;
		}

		if(isCreate == true)
		{
			var pos = Vector3.zero;
			pos.x = Random.Range(-3.6f, 3.6f);

			//下がってるときは画面の下から
			if(gameManager.isRise == false)
			{
				pos.y = playerMove.transform.position.y - 7.0f;
			}
			//上がっているときには画面の上から
			else
			{
				pos.y = playerMove.transform.position.y + 7.0f;
			}

			//1/randomNumの確率で生成されるアイテムが時計に
			int a = Random.Range(1, randomNum);
			if (a == 1)
			{
				Instantiate(clock, pos, Quaternion.identity);
			}
			else
			{
				Instantiate(hirameki, pos, Quaternion.identity);
			}
			isCreate = false;
			spawnTimer = resetTime;
		}
	}
}
