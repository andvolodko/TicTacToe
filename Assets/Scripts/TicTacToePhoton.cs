using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class TicTacToePhoton : Photon.MonoBehaviour
{
	
		bool AutoConnect = false;
		bool ConnectInUpdate = true;
		GameData gameData;
	
		public virtual void Start ()
		{
				gameData = GetComponent<GameData> ();
				PhotonNetwork.autoJoinLobby = false;
		}
	
		public virtual void Update ()
		{
				if (ConnectInUpdate && AutoConnect && !PhotonNetwork.connected) {
						Debug.Log ("Calling: PhotonNetwork.ConnectUsingSettings();");
						ConnectInUpdate = false;
						PhotonNetwork.ConnectUsingSettings ("0.1");
				}
		}

		void OnlineGame ()
		{
				AutoConnect = true;
				SendMessage ("WaitinigForOpponent");
		}

		void GameStarted ()
		{
				if (gameData.modeOnline)
						SendMessage ("FreezeCells", true);
		}

		void NewGame ()
		{
				Disconnect ();
		}

		void Disconnect ()
		{
				if (PhotonNetwork.connected)
						PhotonNetwork.Disconnect ();
				AutoConnect = false;
				ConnectInUpdate = true;
		}

		public virtual void OnConnectedToMaster ()
		{
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
						Debug.LogWarning ("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions [0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
				Debug.Log ("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
				PhotonNetwork.JoinRandomRoom ();
		}
	
		public virtual void OnPhotonRandomJoinFailed ()
		{
				Debug.Log ("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 2}, null);");
				PhotonNetwork.CreateRoom (null, new RoomOptions () { maxPlayers = 2 }, null);
		}
		
		public virtual void OnFailedToConnectToPhoton (DisconnectCause cause)
		{
				Debug.LogError ("Cause: " + cause);
				SendMessage ("FreezeCells", true);
		}
	
		public void OnJoinedRoom ()
		{
				Debug.Log ("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
				if (PhotonNetwork.isMasterClient)
						gameData.youFirst = true;
				else
						gameData.youFirst = false;
				CheckIfPlayerCanTurn ();
		}

		public void OnPhotonPlayerConnected (PhotonPlayer player)
		{
				Debug.Log ("OnPhotonPlayerConnected: " + player);
				CheckIfPlayerCanTurn ();
		}

		public void OnPhotonPlayerDisconnected (PhotonPlayer player)
		{
				Debug.Log ("OnPlayerDisconneced: " + player);
				Disconnect ();
				SendMessage ("PlayerExit");
				SendMessage ("FreezeCells", true);
		}

		void CheckIfPlayerCanTurn ()
		{
				if (PhotonNetwork.playerList.Length == 2) {
						SendMessage ("OnlineGameStart");
						if (gameData.youFirst && gameData.playerOneTurn) {
								SendMessage ("FreezeCells", false);
						}
				}
		}

		void OnGUI ()
		{
				GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		}
	
		[RPC]
		public void CellRPC (string cellKey, PhotonMessageInfo mi)
		{
				if (gameData.gameOver)
						return;
				string senderName = "anonymous";
		
				if (mi != null && mi.sender != null) {
						if (!string.IsNullOrEmpty (mi.sender.name)) {
								senderName = mi.sender.name;
						} else {
								senderName = "player " + mi.sender.ID;
						}
				}
		
				Debug.Log (senderName + ": " + cellKey);

				if (!mi.sender.isLocal)
						gameData.cells [cellKey].cellClicked ();
		}

		void PlayerEndTurn ()
		{
				if (!gameData.modeOnline)
						return;
				if (gameData.playerOneTurn && gameData.youFirst)
						SendMessage ("FreezeCells", false);
				if (!gameData.playerOneTurn && !gameData.youFirst)
						SendMessage ("FreezeCells", false);
				if (gameData.playerOneTurn && !gameData.youFirst)
						SendMessage ("FreezeCells", true);
				if (!gameData.playerOneTurn && gameData.youFirst)
						SendMessage ("FreezeCells", true);
		}

}
