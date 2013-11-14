using UnityEngine;

namespace Assets.Scripts.Game
{
		public class InsectInfo : MonoBehaviour
		{
				private float CofSpeed = 1f;
				public static float SpeedBonus = 1f;
				public float Speed = 100f;
				public int BasicOnEatScoreAdd = 1;
				public static int ScoreMultiplier = 1;
				public int OnEatScoreAdd;
				public int OnEatSatietyAdd = 1;
				public float OnDestroySatietySub = -1f;
				public float OnEatSatietyDec = 0f;
				public bool IsBonusInsect = false;

				private static float DifficultDecSatiety = 1f;
				private static float DifficultIncSatiety = 1f;
				private static float DifficultSpeed = 1f;
				private static float DecSatiety = 0.35f;
				private static float IncSatiety = 0.2f;
				private static float IncSpeed = 0.1f;
		
				public static int ControlParam = 1; 
		
				private void Start ()
				{		
						FlySound ();
						CofSpeed = Screen.width / 1920f;
						Speed = Speed * SpeedBonus * CofSpeed * DifficultSpeed;
						OnDestroySatietySub *= ControlParam;
						OnEatScoreAdd = BasicOnEatScoreAdd * ScoreMultiplier * (int)DifficultDecSatiety;
						OnDestroySatietySub *= DifficultDecSatiety;
						OnEatSatietyDec *= DifficultDecSatiety;
				}

				private void Update ()
				{
						Move ();
				}

				private void Move ()
				{
						transform.Translate (Vector3.left * Time.deltaTime * Speed);
				}

				private void FlySound ()
				{
						audio.Play ();
						audio.loop = true;
				}
				public static void DifficultUp ()
				{
						DifficultDecSatiety += DecSatiety;
						DifficultIncSatiety += IncSatiety;
						DifficultSpeed += IncSpeed;
				}
		}
}
