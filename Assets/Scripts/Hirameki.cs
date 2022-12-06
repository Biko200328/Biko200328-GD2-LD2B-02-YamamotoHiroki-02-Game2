using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hirameki : MonoBehaviour
{
	PlayerMove playerMove;

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			//当たった時にプレイヤーのレベルを上げる
			playerMove.LvUp();
			
		}

		//自身を消す
		Destroy(this.gameObject);
	}
}
