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
			//フラグ反転
			//下がっている状態なら上げるように
			//上がっている状態なら下げるように
			gameManager.isRise = !gameManager.isRise;
		}

		//自身を消滅させる
		Destroy(this.gameObject);
	}
}
