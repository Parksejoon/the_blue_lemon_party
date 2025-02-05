﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 꿈의 마녀 NPC
// 던전 진입, 꿈 조각 설정 NPC 
public class DreamWitch : NPC
{
	private bool printingFlag = false;          // 출력 플래그

	// NPC와 대화 시작
	public override void StartConverse()
	{
		// 초기화
		Queue<string> textQueue = new Queue<string>();

		textQueue.Enqueue("Ahhhhhhhhhhhh!\nYou so fuckin' precious when you smile\nABC");
		textQueue.Enqueue("Im waking up.\nI feel it in my bones.\nEnough to make my systems blow.");

		textPrinterWindow.SetTextQueue(textQueue, "DreamWitch");
		converseSelectionWindow.SetChoices(new ConverseSelection.ChoiceCallback[] { EnterDungeon, ExitConverse },
										new string[] { "Enter Dungeon", "Exit" });

		printingFlag = true;
	}

	// 추가 상호작용
	public override void ExtraInteract()
	{
		if (printingFlag)
		{
			if (!textPrinterWindow.ProgressConverse())
			{
				converseSelectionWindow.EnableChoices();
				printingFlag = false;
			}
		}
		else
		{
		}
	}

	// 상호작용 종료
	public override void EndInteract()
	{
		textPrinterWindow.DisablePrint();

		base.EndInteract();
	}
	
	public void EnterDungeon()
	{
		EndInteract();
		SceneManager.LoadScene((int)SceneNumber.BattleScene);
	}

	public void ExitConverse()
	{
		EndInteract();
	}
}