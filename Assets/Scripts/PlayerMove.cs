using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	[SerializeField] private GameObject Graph0;
	[SerializeField] private GameObject Graph1;
	[SerializeField] private GameObject Graph2;
	[SerializeField] private GameObject Graph3;
	[SerializeField] private GameObject Graph4;
	[SerializeField] private GameObject Graph5;

	[SerializeField] Text text;
	

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
		if (gameManager.isRise == true)
		{
			transform.Rotate(new Vector3(0, 0, 2));
		}
		else
		{
			transform.Rotate(new Vector3(0, 0, -2));
		}
		Move();
		Fall();
		//Loop();
		FeverBoost();
		GraphChange();
		isFever2 = isFever;

		if (isFever == true)
		{
			feverCount += Time.deltaTime;
			if(feverCount >= feverTime)
			{
				//�t�B�[�o�[�I��
				isFever = false;
				//�^�C�}�[���Z�b�g
				feverCount = 0;
				//lv��0��
				lv = 0;
				//�X�s�[�h�������l��
				saveFallSpeed = initialValue;
			}
		}

		switch (lv)
		{
			case 0:
				saveFallSpeed = initialValue;
				break;
			case 1:
				saveFallSpeed = initialValue + addSpeed;
				break;
			case 2:
				saveFallSpeed = initialValue + addSpeed * 2;
				break;
			case 3:
				saveFallSpeed = initialValue + addSpeed * 3;
				break;
			case 4:
				saveFallSpeed = initialValue + addSpeed * 4;
				break;
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

		text.text = "" + transform.position.y.ToString("F");
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
		if(lv < 4)
		{
			lv++;
		}
		else if(lv == 4)
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
			// �t�B�[�o�[�J�n���玞�Ԃ��͂���
			boostTimer += Time.deltaTime;
			// �^�C�}�[����ȉ��̏ꍇ�̓X�s�[�h�𑫂�������(����)
			saveFallSpeed += addRiseSpeed;
			if (boostTimer >= 1.0f)
			{
				boostTimer = 1.0f;
				//�꒴�����ꍇ������؂�
				isFeverBoost = false;
			}
		}
		else
		{
			// �������؂��Ă���ꍇ
			// ���A���Ԃ���ȏ�c���Ă���(��������������)��Ԃ̎�
			if (boostTimer >= 1.0f)
			{
				// ����������t���O
				isBoostTimerDown = true;
			}
			if (isBoostTimerDown == true)
			{
				// �������鎞�Ԃ��͂���
				boostTimer -= Time.deltaTime;
				// 0�ȉ��ɂȂ�܂ő��x������������(����)
				saveFallSpeed -= addRiseSpeed;
				// 0�ȉ��ɂȂ�����
				if (boostTimer <= 0)
				{
					// ����������t���O��؂�
					isBoostTimerDown = false;
					// �^�C�}�[�̃��Z�b�g
					boostTimer = 0;
				}
			}
		}
	}

	private void GraphChange()
	{
		switch (lv)
		{
			case 0:
				Graph0.SetActive(true);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 1:
				Graph0.SetActive(false);
				Graph1.SetActive(true);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 2:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(true);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 3:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(true);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 4:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(true);
				Graph5.SetActive(false);
				break;
			case 5:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(true);
				break;
		}
	}
}
