﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver
{
	private static Dictionary<string, object> dataMap = new Dictionary<string, object>();       // 임시로 저장할 데이터 맵

	private static JsonData jsonData;			// json 데이터


	// 데이터 저장
	public static void SaveData(string key, object value)
	{
		dataMap[key] = value;
	}

	// 데이터 삭제
	public static void RemoveData(string key)
	{
		if (dataMap.ContainsKey(key)) dataMap.Remove(key);
	}

	// 데이터 가져오기
	public static object GetData(string key)
	{
		return dataMap.ContainsKey(key) ? dataMap[key] : null;
	}
}
