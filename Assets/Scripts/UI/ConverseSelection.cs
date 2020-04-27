﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverseSelection : MonoBehaviour
{
	public delegate void ChoiceCallback();

	public ChoiceCallback[] choiceCallbacks;	// 선택시 호출할 콜백 함수 목록

	[SerializeField]
	private GameObject	choicePrefab;			// 선택지 프리팹
	[SerializeField]
	private Transform	choiceParent;			// 선택지 부모 transform

	private int			choiceCount;			// 선택지 갯수


	// 선택지 설정
	public void SetChoices(ChoiceCallback[] callbacks)
	{
		choiceCallbacks = callbacks;
		choiceCount = callbacks.Length;
	}

	// 선택지 활성화
	public void EnableChoices()
	{
		gameObject.SetActive(true);
	
		for (int i = 0; i < choiceCount; i++)
		{
			// (!! 오브젝트 풀 사용 !!)
			Instantiate(choicePrefab, choiceParent);
		}
	}

	// 선택
	public void ChooseChoice(int index)
	{
		choiceCallbacks[index]();
		gameObject.SetActive(false);
	}
}
