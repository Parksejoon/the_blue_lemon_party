﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverseSelection : MonoBehaviour
{
	public delegate void ChoiceCallback();


	[SerializeField]
	private GameObject			choicePrefab;		// 선택지 프리팹
	[SerializeField]
	private Transform			choiceParent;       // 선택지 부모 transform

	public	ChoiceCallback[]	choicesCallbacks;   // 선택시 호출할 콜백 함수 목록
	private string[]			choicesNames;		// 선택지 이름 목록
	private List<GameObject>	choicesArray;       // 선택지 목록 array

	private int					choiceCount;		// 선택지 갯수


	// 초기화
	private void Awake()
	{
		ObjectPoolManager.Create("Choices", choicePrefab, 10, choiceParent);
	}

	// 선택지 설정
	public void SetChoices(ChoiceCallback[] callbacks, string[] names)
	{
		choicesCallbacks = callbacks;
		choicesNames = names;
		choiceCount = callbacks.Length;
	}

	// 선택지 활성화
	public void EnableChoices()
	{
		gameObject.SetActive(true);
		choicesArray = new List<GameObject>();

		for (int i = 0; i < choiceCount; i++)
		{
			GameObject target = ObjectPoolManager.GetGameObject("Choices", Vector3.positiveInfinity);

			target.GetComponent<ConverseChoice>().SetChoice(i, choicesNames[i]);
			choicesArray.Add(target);
		}
	}

	// 선택지 비활성화
	public void DisableChoices()
	{
		for (int i = choicesArray.Count - 1; i >= 0 ; i--)
		{
			ObjectPoolManager.Release("Choices", choicesArray[i]);
		}

		gameObject.SetActive(false);
	}

	// 선택
	public void ChooseChoice(int index)
	{
		choicesCallbacks[index]();

		DisableChoices();
	}
}