using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
	public float fallSpeed;
	public float saveFallSpeed = 0.01f;
	float initialValue = 0;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;

	[SerializeField] private float addSpeed;
	public int lv;

	public bool isFever;

	[SerializeField] private float addRiseSpeed;

	GameManager gameManager;

	float feverCount = 0;
	[SerializeField] float feverTime = 3f;

	// Start is called before the first frame update
	void Start()
	{
		isFever = false;
		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
		initialValue = saveFallSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fall();
		//Loop();

		if(isFever == true)
		{
			feverCount += Time.deltaTime;
			if(feverCount >= feverTime)
			{
				//フィーバー終了
				isFever = false;
				feverCount = 0;
				//lvを0に
				lv = 0;
				//スピードを初期値に
				saveFallSpeed = initialValue;
			}
		}

		if (gameManager.isRise == true)
		{
			fallSpeed += addRiseSpeed;
			if(fallSpeed >= saveFallSpeed)
			{
				fallSpeed = saveFallSpeed;
			}
		}
		else
		{
			fallSpeed -= addRiseSpeed;
			if (fallSpeed <= -saveFallSpeed)
			{
				fallSpeed = -saveFallSpeed;
			}
		}
	}

	//自動で落ちる
	public void Fall()
	{
		var pos = transform.position;

		pos.y += fallSpeed;

		transform.position = pos;
	}

	//public void Loop()
	//{
	//	var pos = transform.position;

	//	if(transform.position.y <= -loopzone)
	//	{
	//		pos.y = 0;
	//	}
	//	if(transform.position.y >= 0)
	//	{
	//		pos.y = -loopzone;
	//	}

	//	transform.position = pos;
	//}

	//横移動
	public void Move()
	{
		var pos = transform.position;

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= moveSpeed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += moveSpeed;
		}

		if(transform.position.x <= -width)
		{
			pos.x = width - 0.1f;
		}
		if (transform.position.x >= width)
		{
			pos.x = -width + 0.1f;
		}

		transform.position = pos;
	}

	public void LvUp()
	{
		if(lv < 5)
		{
			lv++;
			saveFallSpeed += addSpeed;
		}

		//lv5以上でフィーバー
		if(lv >= 5)
		{
			isFever = true;
		}
	}
}
