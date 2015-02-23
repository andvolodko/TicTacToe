using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GameSounds : MonoBehaviour
{

		public AudioClip click;
		public AudioClip won;

		void PlayerVsPlayer ()
		{
				audio.PlayOneShot (click);
		}
	
		void PlayerVsAI ()
		{
				audio.PlayOneShot (click);
		}

		void OnlineGame ()
		{
				audio.PlayOneShot (click);
		}

		void NewGame ()
		{
				audio.PlayOneShot (click);
		}

		void playerTurned ()
		{
				audio.PlayOneShot (click);
		}

		void AITurned ()
		{
				audio.PlayOneShot (click);
		}

		void XWon ()
		{
				audio.PlayOneShot (won);
		}

		void OWon ()
		{
				audio.PlayOneShot (won);
		}

}
