﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스탯
public struct Statistics
{
	public int		max_health_point;   // 최대 체력
	public int		attack_damage;      // 공격력
	public float	move_speed;         // 이동 속도
	public float	attack_speed;       // 공격 속도
	public int		abillity_power;     // 마력
	public float	defensive_power;    // 방어력
}

public class Character : MonoBehaviour
{
	private Statistics	stats;            // 스탯
	public Statistics Stats
	{
		get { return stats; }
		private set { stats = value; }
	}

	private int healthPoint;		// 현재 체력
	public int HealthPoint
	{
		get { return healthPoint; }
		private set { healthPoint = value; }
	}


	// 대미지 받음
	public virtual void Dealt(int damage, Vector3 attackPosition)
	{
		HealthPoint -= damage;

		Debug.Log(HealthPoint + "/" + stats.max_health_point + "|| CharacterName: <" + gameObject.name + ">");

		if (HealthPoint <= 0)
		{
			HealthPoint = 0;
			Dead();
		}
	}

	// 사망
	protected virtual void Dead()
	{
		Debug.Log("CharacterName: <" + gameObject.name + "> is dead.");
	}

	// 스탯 초기화
	public void SetStats(Statistics _stats)
	{
		stats = _stats;

		ResetHealth();
	}

	// 체력 초기화
	public void ResetHealth()
	{
		HealthPoint = stats.max_health_point;
	}

	// 스탯 추가
	public void AddStats(Statistics stats)
	{
		stats.max_health_point += stats.max_health_point;
		stats.attack_damage += stats.attack_damage;
		stats.move_speed += stats.move_speed;
		stats.attack_speed += stats.attack_speed;
		stats.abillity_power += stats.abillity_power;
		stats.defensive_power += stats.defensive_power;
	}
}
