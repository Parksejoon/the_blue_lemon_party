﻿using System.Collections;
using UnityEngine;

public class BlockReset : Skill
{
	[SerializeField]
	private ObjectGiver normalBlockGiver;			// 일반 블럭 공급자
	

	// 스킬 사용
	public override void ShotSkill()
	{
		Debug.Log(isCoolDowning);

		if (PlayerManager.instance.isGround && !isCoolDowning)
		{
			StartCoroutine(CoolDown());

			normalBlockGiver.GiveAllBlock();
		}
	}

	// 쿨다운
	protected override IEnumerator CoolDown()
	{
		isCoolDowning = true;

		yield return new WaitForSeconds(CoolDownTime);

		isCoolDowning = false;
	}

}
