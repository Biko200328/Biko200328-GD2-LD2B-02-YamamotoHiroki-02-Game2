using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	PlayerMove playerMove;
	GameManager gameManager;

	[SerializeField] GameObject Graph0;
	[SerializeField] GameObject Graph1;

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
		if(playerMove.isFever)
		{
			Graph0.SetActive(false);
			Graph1.SetActive(true);
		}
		else
		{
			Graph0.SetActive(true);
			Graph1.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//�t�B�[�o�[���Ȃ��������悤��
			if(playerMove.isFever)
			{
				playerMove.LvUp();
			}
			//�t���O���]
			//�������Ă����ԂȂ�グ��悤��
			//�オ���Ă����ԂȂ牺����悤��
			else gameManager.isRise = !gameManager.isRise;
		}

		//���g�����ł�����
		Destroy(this.gameObject);
	}
}
