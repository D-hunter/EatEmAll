using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class Bonus : MonoBehaviour 
	{
		public static bool SlowSpeedActiv = false;
		public static bool SwarmActiv = false;
		public static bool MultiplyScoresActiv = false;
		public static bool FastSpeedActiv = false;
		
		private static float StartTimeSlowSpeed;
		private static float StartTimeSwarm;
		private static float StartTimeMultipliyScores;
		private static float StartTimeFastSpeed;
		
		private float DurationSlowSpeed = 10f;
		private float DurationSwarm = 6f;
		private float DurationMultiplyScores = 8f;
		private float DurationFastSpeed = 10f;
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
 					StopSlowSpeed();
				}
			}
			if(SwarmActiv)
			{
				if(StartTimeSwarm+DurationSwarm<Time.time)
				{
					StopSwarm();
				}
			}
			if(MultiplyScoresActiv)
			{
				if(StartTimeMultipliyScores+DurationMultiplyScores<Time.time)
				{
					StopMultiplyScores();
				}
			}
			if(FastSpeedActiv)
			{
				if(StartTimeFastSpeed+DurationFastSpeed<Time.time)
				{
					StopFastSpeed();
				}
			}
		}
		
		public static void StartSlowSpeed()
		{
			if(SlowSpeedActiv) return;
			
			if(FastSpeedActiv) StopFastSpeed();
			
			SlowSpeedActiv = true;
			StartTimeSlowSpeed = Time.time;
			float slowSpeed = 0.7f;
			InsectInfo.SpeedBonus = slowSpeed;
		}
		
		public static void StartSwarm()
		{
			if(SwarmActiv) return;
			SwarmActiv = true;
			StartTimeSwarm = Time.time;
			
			Generator.StandartInsectRate = 1f;
			Generator.S_GreenInsectRate = 1f;
			Generator.S_RedInsectRate = 0f;
			Generator.ExtraInsectRate = -1f;
			Generator.BonusInsectRate = -1f;
			InsectsGenerator.SpawnDelay = 0.1f;
			
			InsectInfo.Controler = -1;
		}
		
		public static void StartMultiplyScores()
		{
			if(MultiplyScoresActiv) return;
			
			MultiplyScoresActiv = true;
			StartTimeMultipliyScores = Time.time;
			byte scoreMultiplier = 2;
			InsectInfo.ScoreMultiplier = scoreMultiplier;
		}
		
		public static void StartFastSpeed()
		{
			if(FastSpeedActiv) return;
			
			if(SlowSpeedActiv) StopSlowSpeed();
			
			FastSpeedActiv = true;
			StartTimeFastSpeed = Time.time;
			float fastSpeed = 1.7f;
			InsectInfo.SpeedBonus = fastSpeed;
		}
		
		private static void StopSlowSpeed()
		{
			SlowSpeedActiv = false;
			StartTimeSlowSpeed = 0f;
			float standartSpeed = 1f;			
			InsectInfo.SpeedBonus = standartSpeed;
		}
		
		private static void StopSwarm ()
		{
			SwarmActiv = false;
			StartTimeSwarm = 0f;
			
			Generator.StandartInsectRate = 0.89f;
			Generator.S_GreenInsectRate = 0.46f;
			Generator.S_RedInsectRate = 0.54f;
			Generator.ExtraInsectRate = 0.1f;
			Generator.BonusInsectRate = 0.01f;
			
			InsectsGenerator.SpawnDelay = 0.3f;
			
			InsectInfo.Controler = 1;
		}//		
		
		private static void StopFastSpeed()
		{
			FastSpeedActiv = false;
			StartTimeFastSpeed = 0f;
			float standartSpeed = 1f;
			InsectInfo.SpeedBonus = standartSpeed;
		}
		
		private static void StopMultiplyScores ()
		{
			MultiplyScoresActiv = false;
			StartTimeMultipliyScores = 0f;
			byte standartMultiply = 1;
			Generator.ScoreBonus = standartMultiply;
		}
	}
}
