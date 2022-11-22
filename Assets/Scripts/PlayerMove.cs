using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float fallSpeed;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;

	[SerializeField] private float addSpeed;
	[SerializeField] public int lv;

	[SerializeField] private bool isFever;

	// Start is called before the first frame update
	void Start()
	{
		isFever = false;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fall();
	}

	//自動で落ちる
	public void Fall()
	{
		var pos = transform.position;

		pos.y -= fallSpeed + addSpeed;

		transform.position = pos;
	}

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
			fallSpeed += addSpeed;
		}

		//lv5以上でフィーバー
		if(lv >= 4)
		{
			isFever = true;
		}
	}
}
