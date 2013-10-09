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
		
		void CheckBonusActuality()
		{
			if(SlowSpeedActiv)
			{
				if(StartTimeSlowSpeed+DurationSlowSpeed<Time.time)
				{
					SlowSpeedActiv = false;
					StartTimeSlowSpeed = 0f;
					Generator.SpeedBonus = 1f;
				}
			}
			if(SwarmActiv)
			{
				if(StartTimeSwarm+DurationSwarm<Time.time)
				{
					SwarmActiv = false;
					StartTimeSwarm = 0f;
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
			Generator.SpeedBonus=0.7f;
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
			Generator.ScoreBonus = 2;
			
		}
	}
}
