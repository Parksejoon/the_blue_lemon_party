﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	private GameObject	weaponPrefab;		// 무기 프리팹
	private GameObject	currentWeapon;		// 현재 무기
	

	// 무기 장착
	public void SetWeapon(GameObject weapon)
	{
		weaponPrefab = weapon;
	}

	// 무기 삭제
	public void DeleteWeapon()
	{
		Destroy(currentWeapon);
	}

	// 무기 생성
	public void CreateWeapon()
	{
		 currentWeapon = Instantiate(weaponPrefab);
	}
}
