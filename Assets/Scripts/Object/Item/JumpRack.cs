﻿using UnityEngine;

public class JumpRack : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private			GameObject		jumpEffect;			// 점프 파티클

	// 인스펙터 비노출 변수
	// 일반
	private const	float			jumpPower = 10;     // 점프 파워
	private			Vector2			jumpWay;            // 점프 방향


	// 트리거 진입
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			// 물리
			Vector3 rotation = transform.parent.rotation.eulerAngles;
			float angle = rotation.z * Mathf.PI / 180;

			jumpWay = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));

			Rigidbody2D targetRigidbody = collision.GetComponent<Rigidbody2D>();

			targetRigidbody.velocity = Vector2.zero;
			targetRigidbody.AddForce(jumpWay * jumpPower, ForceMode2D.Impulse);

			// 파티클
			Vector3 position = transform.position;

			position.z = -15;
			position.y += 0.5f;

			Instantiate(jumpEffect, position, Quaternion.identity);
		}
	}
}
