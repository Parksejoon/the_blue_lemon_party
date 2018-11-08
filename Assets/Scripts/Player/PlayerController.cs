﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private Transform			playerTransform;            // 플레이어 트랜스폼
	[SerializeField]
	private Rigidbody2D			playerRigidbody2D;          // 플레이어 리지드바디 2D
	[SerializeField]
	private SpriteRenderer		spriteRenderer;             // 플레이어 스프라이트 렌더러
	[SerializeField]
	private MoveParticle		moveParticle;				// 움직임 파티클

	// 수치
	public	int					originJumpCount;			// 기본 점프 카운트

	[SerializeField]
	private float				moveSpeed;                  // 움직임 속도
	[SerializeField]
	private float				jumpPower;                  // 점프 파워

	// 인스펙터 비노출 변수
	// 수치
	private int					jumpCount;                  // 점프 카운트
	private float				horizontalMove;             // 좌우 이동
	private float				verticalMove;				// 상하 이동
	private bool				isJumping = false;          // 점프 여부


	// 초기화
	private void Awake()
	{
		if (playerTransform == null)
		{
			playerTransform = transform;
		}

		if (playerRigidbody2D == null)
		{
			playerRigidbody2D = GetComponent<Rigidbody2D>();
		}

		ResetJump();
	}

	// 프레임
	private void Update()
	{
		horizontalMove	= Input.GetAxis("Horizontal");
		verticalMove	= Input.GetAxis("Vertical");

		if (Input.GetButtonDown("Jump") && jumpCount > 0)
		{
			isJumping = true;
		}
	}

	// 고정 프레임
	private void FixedUpdate()
	{
		Run();
		Jump();
	}

	// 움직임
	private void Run()
	{
		Vector2 position = playerTransform.position;
		Vector3 velocity = playerRigidbody2D.velocity;

		position.x += horizontalMove * Time.deltaTime * moveSpeed;
		playerTransform.position = position;
		moveParticle.flagArray[0] = false;

		if (horizontalMove < 0)
		{
			spriteRenderer.flipX = true;
			moveParticle.flagArray[0] = true;

			if (velocity.x > 0)
			{
				playerRigidbody2D.velocity = new Vector3(velocity.x - 0.5f, velocity.y);
			}
		}
		else if (horizontalMove > 0)
		{
			spriteRenderer.flipX = false;
			moveParticle.flagArray[0] = true;

			if (velocity.x < 0)
			{
				playerRigidbody2D.velocity = new Vector3(velocity.x + 0.5f, velocity.y);
			}
		}

		if (verticalMove < 0)
		{
			playerRigidbody2D.AddForce(Vector3.down, ForceMode2D.Impulse);
		}
	}

	// 점프
	private void Jump()
	{
		if (isJumping)
		{
			Vector3 velocity = playerRigidbody2D.velocity;

			if (velocity.y < 0)
			{
				playerRigidbody2D.velocity = new Vector3(velocity.x, 0);
			}

			playerRigidbody2D.AddForce(Vector2.up * jumpPower * Input.GetAxis("Jump"), ForceMode2D.Impulse);

			jumpCount--;
			isJumping = false;
		}
	}

	// 점프 리셋
	public void ResetJump()
	{
		jumpCount = originJumpCount;
	}
}
