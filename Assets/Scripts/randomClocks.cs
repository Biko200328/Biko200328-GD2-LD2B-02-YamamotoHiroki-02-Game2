using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomClocks : MonoBehaviour
{
	[SerializeField] GameObject clock1;
	[SerializeField] GameObject clock2;
	[SerializeField] GameObject clock3;

	GameObject player;
	GameManager gameManager;

	[SerializeField] float createTime;
	[SerializeField] float timer;
	bool isCreate = false;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");

		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (isCreate == false)
		{
			timer += Time.deltaTime;
			if(timer >= createTime)
			{
				isCreate = true;
				timer = 0;
			}
		}
		if(isCreate == true)
		{
			var pos = Vector3.zero;
			pos.x = Random.Range(-3.6f, 3.6f);

			//‰º‚ª‚Á‚Ä‚é‚Æ‚«‚Í‰æ–Ê‚Ì‰º‚©‚ç
			if (gameManager.isRise == false)
			{
				pos.y = player.transform.position.y - 7.0f;
			}
			//ã‚ª‚Á‚Ä‚¢‚é‚Æ‚«‚É‚Í‰æ–Ê‚Ìã‚©‚ç
			else
			{
				pos.y = player.transform.position.y + 7.0f;
			}


			if (player.gameObject.transform.position.y <= -200)
			{
				int a = Random.Range(1, 6);
				if (a == 1)
				{
					Instantiate(clock1, pos, Quaternion.identity);
					isCreate = false;
				}
				else if (a >= 2 && a <= 4)
				{
					Instantiate(clock2, pos, Quaternion.identity);
					isCreate = false;
				}
				else
				{
					Instantiate(clock3, pos, Quaternion.identity);
					isCreate = false;
				}

			}
			else if (player.gameObject.transform.position.y <= -150)
			{
				int a = Random.Range(1, 6);
				if (a <= 2)
				{
					Instantiate(clock1, pos, Quaternion.identity);
					isCreate = false;
				}
				else if (a >= 3 && a <= 5)
				{
					Instantiate(clock2, pos, Quaternion.identity);
					isCreate = false;
				}
				else
				{
					Instantiate(clock3, pos, Quaternion.identity);
					isCreate = false;
				}
			}
			else if (player.gameObject.transform.position.y <= -100)
			{
				int a = Random.Range(1, 2);
				if (a == 1)
				{
					Instantiate(clock1, pos, Quaternion.identity);
					isCreate = false;
				}
				else
				{
					Instantiate(clock2, pos, Quaternion.identity);
					isCreate = false;
				}
			}
			else if (player.gameObject.transform.position.y <= -50)
			{
				Instantiate(clock1, pos, Quaternion.identity);
				isCreate = false;
			}
		}
		
	}
}
