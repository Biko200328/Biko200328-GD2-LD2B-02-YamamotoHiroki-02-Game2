using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
	[SerializeField] GameObject hirameki;

	[SerializeField] private float spawnTimer = 3.0f;
	private float resetTime;

	bool isCreate = false;

	GameManager gameManager;
	PlayerMove playerMove;

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
			if(gameManager.isRise == false)
			{
				pos.y = playerMove.transform.position.y - 7.0f;
			}
			else
			{
				pos.y = playerMove.transform.position.y + 7.0f;
			}
			Instantiate(hirameki, pos, Quaternion.identity);
			isCreate = false;
			spawnTimer = resetTime;
		}
	}
}
