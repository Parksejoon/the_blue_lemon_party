﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private GameObject	explosion;			// 폭발

	// 인스펙터 비노출 변수
	// 일반
	private Tilemap		tileMap;			// 타일맵
	private Grid		grid;				// 그리드


	// 초기화
	private void Awake()
	{
		GameObject targetGrid = ClosestObject("SoilBlock");
		
		grid = targetGrid.transform.parent.GetComponent<Grid>();
		tileMap = targetGrid.GetComponent<Tilemap>();
	}

	// 시작
	private void Start()
	{
		StartCoroutine("BombCountDown");
	}

	// 폭발
	private void ComitBomb()
	{
		Vector3Int core = grid.WorldToCell(transform.position);

		for (int i = -4; i <= 4; i++)
		{
			for (int j = -4; j <= 4; j++)
			{
				tileMap.SetTile(new Vector3Int(core.x + i, core.y + j, 0), null);
			}
		}

		// 폭발 충돌체 소환
		Instantiate(explosion, transform.position, Quaternion.identity);

		Destroy(gameObject);
	}

	// 가장 가까운 오브젝트 반환
	private GameObject ClosestObject(string tag)
	{
		GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(tag);
		GameObject returnValue = null;
		float minLength = float.MaxValue;

		foreach (GameObject targetObject in targetObjects)
		{
			float lengthX = transform.position.x - targetObject.transform.position.x;
			float lengthY = transform.position.y - targetObject.transform.position.y;
			float newLength = Mathf.Sqrt(lengthX * lengthX + lengthY * lengthY);

			if (newLength < minLength)
			{
				minLength = newLength;
				returnValue = targetObject;
			}
		}

		return returnValue;
	}

	// 폭발 코루틴
	private IEnumerator BombCountDown()
	{
		yield return new WaitForSeconds(1f);

		ComitBomb();
	}
}
