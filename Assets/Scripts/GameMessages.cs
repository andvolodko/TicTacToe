﻿using UnityEngine;
using System.Collections;

public class GameMessages : MonoBehaviour
{
		GameObject message;
		TextMesh messageText;
		GameData gameData;
	
		void Start ()
		{
				gameData = GetComponent<GameData> ();
				message = GameObject.Find ("Message");
				messageText = message.GetComponent<TextMesh> ();
				messageText.text = "";
		}

		void GameStarted ()
		{
				if (!gameData.modeAI) {
						messageText.text = GameGlobals.MSG_PLAYER_ONE_TURN;
				} else {
						if (!gameData.AIfirst)
								messageText.text = GameGlobals.MSG_PLAYER_TURN;
						else
								messageText.text = GameGlobals.MSG_AI_TURN;
				}

			if (gameData.modeOnline) {
				if (gameData.youFirst)
					messageText.text = GameGlobals.MSG_YOUR_TURN;
				else
					messageText.text = GameGlobals.MSG_OPPONENT_TURN;
			}			
		}

		void GameEnded ()
		{
				messageText.text = "";
		}

		void XWon ()
		{
				if (!gameData.modeAI)
						messageText.text = GameGlobals.MSG_PLAYER_ONE_WON;
				else {
						if (gameData.AIfirst)
								messageText.text = GameGlobals.MSG_AI_WON;
						else
								messageText.text = GameGlobals.MSG_PLAYER_WON;
				}
				if (gameData.modeOnline) {
					if(!gameData.youFirst) messageText.text = GameGlobals.MSG_YOU_LOSE;
					else messageText.text = GameGlobals.MSG_YOU_WON;
				}
		}
	
		void OWon ()
		{
				if (!gameData.modeAI)
						messageText.text = GameGlobals.MSG_PLAYER_TWO_WON;
				else {
						if (gameData.AIfirst)
								messageText.text = GameGlobals.MSG_PLAYER_WON;
						else
								messageText.text = GameGlobals.MSG_AI_WON;
				}
			if (gameData.modeOnline) {
				if(gameData.youFirst) messageText.text = GameGlobals.MSG_YOU_LOSE;
				else messageText.text = GameGlobals.MSG_YOU_WON;
			}
		}

		void Tie ()
		{
				messageText.text = GameGlobals.MSG_TIE;
		}

		void playerTurned ()
		{
				if (gameData.gameOver)
						return;
				if (!gameData.modeAI) {
						if (gameData.playerOneTurn)
								messageText.text = GameGlobals.MSG_PLAYER_ONE_TURN;
						else
								messageText.text = GameGlobals.MSG_PLAYER_TWO_TURN;
				} else {
						messageText.text = GameGlobals.MSG_AI_TURN;
				}

			if (gameData.modeOnline) {
				if (gameData.playerOneTurn && gameData.youFirst) messageText.text = GameGlobals.MSG_YOUR_TURN;
				if (!gameData.playerOneTurn && !gameData.youFirst) messageText.text = GameGlobals.MSG_YOUR_TURN;

				if (!gameData.playerOneTurn && gameData.youFirst) messageText.text = GameGlobals.MSG_OPPONENT_TURN;
				if (gameData.playerOneTurn && !gameData.youFirst) messageText.text = GameGlobals.MSG_OPPONENT_TURN;
			}
		}

		void AITurned ()
		{
				if (gameData.gameOver)
						return;
				if (gameData.playerOneTurn && !gameData.AIfirst)
						messageText.text = GameGlobals.MSG_PLAYER_TURN;
				if (gameData.playerOneTurn && gameData.AIfirst)
						messageText.text = GameGlobals.MSG_AI_TURN;
				if (!gameData.playerOneTurn && gameData.AIfirst)
						messageText.text = GameGlobals.MSG_PLAYER_TURN;
				if (!gameData.playerOneTurn && !gameData.AIfirst)
						messageText.text = GameGlobals.MSG_AI_TURN;
		}

		void WaitinigForOpponent ()
		{
				messageText.text = GameGlobals.MSG_WAITING_PLAYER;
		}

		void PlayerExit ()
		{
				messageText.text = GameGlobals.MSG_PLAYER_EXIT;
		}

		void OnlineGameStart ()
		{
				GameStarted ();
		}

}
