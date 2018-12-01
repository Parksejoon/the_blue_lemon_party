﻿using System.Collections;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject	ballPrefab;			// 볼
	[SerializeField]
	private float		createMinDelay;     // 생성 최소 주기
	[SerializeField]
	private float		createMaxDelay;     // 생성 최대 주기
	[SerializeField]
	private float		shotPower;			// 발사 힘
	[SerializeField]
	private float		zPosition = 0;      // z 포지션

	private Vector2		shotWay;            // 발사 방향

	public bool enabledGenerate = false;    // 생성 상태


	// 초기화
	private void Awake()
	{
		StartCoroutine(GenerateCoroutine());
	
		Vector3 rotation = transform.rotation.eulerAngles;
		float angle = rotation.z * Mathf.PI / 180;
		
		shotWay = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));
	}

	// 라바 볼 생성
	private void GenerateLavaBall()
	{
		Vector3 position = transform.position;

		position.z = zPosition;
		//Rigidbody2D target = Instantiate(ballPrefab, position, Quaternion.identity).GetComponent<Rigidbody2D>();
		GameObject gameObj = ObjectPoolManager.GetGameObject("Ball", position);

		if (gameObj != null)
		{
			Rigidbody2D target = gameObj.GetComponent<Rigidbody2D>();

			target.AddForce(shotWay * shotPower, ForceMode2D.Impulse);
		}
	}

	// 생성 반복 코루틴
	private IEnumerator GenerateCoroutine()
	{
		yield return new WaitForSeconds(Random.Range(createMinDelay, createMaxDelay));

		if (enabledGenerate)
		{
			GenerateLavaBall();
		}

		StartCoroutine(GenerateCoroutine());
	}
}