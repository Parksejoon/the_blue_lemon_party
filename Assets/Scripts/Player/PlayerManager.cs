﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private PlayerController				playerControl;              // 플레이어 컨트롤


	// 초기화
	private void Awake()
	{
		if (playerControl == null)
		{
			playerControl = GetComponent<PlayerController>();
		}
	}

	// 트리거 진입
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// 블록일 경우
		if (collision.CompareTag("Block") || collision.CompareTag("DangerBlock") || collision.CompareTag("Ball") || collision.CompareTag("SoilBlock"))
		{
			playerControl.ResetJump();
		}
	}
}
