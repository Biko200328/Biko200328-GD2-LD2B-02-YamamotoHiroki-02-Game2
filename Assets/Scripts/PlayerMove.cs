using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
	bool isFever2;
	public bool isFeverBoost;
	private bool isBoostTimerDown;
	private float boostTimer = 0f;

	[SerializeField] private float addRiseSpeed;

	GameManager gameManager;

	float feverCount = 0;
	[SerializeField] float feverTime = 3f;
	

	// Start is called before the first frame update
	void Start()
	{
		isFever = false;
		isFeverBoost = false;
		isBoostTimerDown = false;
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
		FeverBoost();
		isFever2 = isFever;

		if (isFever == true)
		{
			feverCount += Time.deltaTime;
			if(feverCount >= feverTime)
			{
				//�t�B�[�o�[�I��
				isFever = false;
				feverCount = 0;
				//lv��0��
				lv = 0;
				//�X�s�[�h�������l��
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

	//�����ŗ�����
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

	//���ړ�
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

		//lv5�ȏ�Ńt�B�[�o�[
		if(isFever == false && lv >= 5)
		{
			isFever = true;
		}

		if(isFever == true && isFever2 == true && lv == 5)
		{
			isFeverBoost = true;
		}
	}

	public void FeverBoost()
	{
		if (isFeverBoost == true)
		{
			boostTimer += Time.deltaTime;
			saveFallSpeed += addRiseSpeed;
			if(boostTimer >= 1f)
			{
				isFeverBoost = false;
			}
		}
		else
		{
			if(boostTimer >= 1f)
			{
				isBoostTimerDown = true;
			}
			if(isBoostTimerDown == true)
			{
				boostTimer -= Time.deltaTime;
				saveFallSpeed -= addRiseSpeed;
				if(boostTimer <= 0)
				{
					isBoostTimerDown = false;
					boostTimer = 0;
				}
			}
		}
	}
}
