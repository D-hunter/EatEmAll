using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class Bonus : MonoBehaviour 
	{
		public static bool SlowSpeedActiv = false;
		public static bool SwarmActiv = false;
		public static bool MultiplyScoresActiv = false;
		
		private static float StartTimeSlowSpeed;
		private static float StartTimeSwarm;
		private static float StartTimeMultipliyScores;
		
		private float DurationSlowSpeed = 10f;
		private float DurationSwarm = 6f;
		private float DurationMultiplyScores = 8f;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			CheckBonusActuality();
		}

		void StopSwarm ()
		{
			SwarmActiv = false;
			StartTimeSwarm = 0f;
		}
		
		void CheckBonusActuality()
		{
			if(SlowSpeedActiv)
			{
				if(StartTimeSlowSpeed+DurationSlowSpeed<Time.time)
				{
 					StopSlowSpeed();
				}
			}
			if(SwarmActiv)
			{
				if(StartTimeSwarm+DurationSwarm<Time.time)
				{
					StopSwarm ();
				}
			}
			if(MultiplyScoresActiv)
			{
				if(StartTimeMultipliyScores+DurationMultiplyScores<Time.time)
				{
					MultiplyScoresActiv = false;
					StartTimeMultipliyScores = 0f;
				}
			}
		}
		
		public static void StartSlowSpeed()
		{
			if(SlowSpeedActiv) return;
			
			SlowSpeedActiv = true;
			StartTimeSlowSpeed = Time.time;
			float slowSpeed = 0.7f;
			Generator.SpeedBonus=slowSpeed;
		}
		
		public static void StartSwarm()
		{
			if(SwarmActiv) return;
			SwarmActiv = true;
			StartTimeSwarm = Time.time;
		}
		
		public static void StartMultiplyScores()
		{
			if(MultiplyScoresActiv) return;
			
			MultiplyScoresActiv = true;
			StartTimeMultipliyScores = Time.time;
			int scoreMultiplyer = 2;
			Generator.ScoreBonus = scoreMultiplyer;
		}
		
		private void StopSlowSpeed()
		{
			SlowSpeedActiv = false;
			StartTimeSlowSpeed = 0f;
			float standartSpeed = 1f;
			Generator.SpeedBonus = standartSpeed;				
		}
		
		
		
	}
}
