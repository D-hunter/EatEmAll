using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
		public class Game : MonoBehaviour
		{

				public static bool IsPause = false;
				public static bool IsLose = false;
				public static float DifficultDecSatiety;
				public static float DifficultIncSatiety;
				public static float DifficultSpeed;
				public static float DecSatiety;
				public static float IncSatiety;
				public static float IncSpeed;
				
				public static GameObject TopCollider;
				public static GameObject MiddleCollider;
				public static GameObject BottomCollider;
				// Use this for initialization
				void  Start ()
				{
					SetDefaults();
					TopCollider = GameObject.FindGameObjectWithTag("top");
					MiddleCollider = GameObject.FindGameObjectWithTag("center");
					BottomCollider = GameObject.FindGameObjectWithTag("bottom");
        		}
        
				// Update is called once per frame
				void Update ()
				{
					
				}
				
				public static void DisableTocuhColliders()
				{
					TopCollider.GetComponent<BoxCollider>().collider.enabled = false;
					MiddleCollider.GetComponent<BoxCollider>().collider.enabled = false;
					BottomCollider.GetComponent<BoxCollider>().collider.enabled = false;	
				}
				public static void EnableTouchColliders()
				{
					TopCollider.GetComponent<BoxCollider>().collider.enabled = true;
					MiddleCollider.GetComponent<BoxCollider>().collider.enabled = true;
					BottomCollider.GetComponent<BoxCollider>().collider.enabled = true;				
				}
				public static void DifficultUp ()
				{
					DifficultDecSatiety += DecSatiety;
					DifficultIncSatiety += IncSatiety;
					DifficultSpeed += IncSpeed;
				}
				
				public static void SetDefaults()
				{
					DifficultDecSatiety = 1f;
					DifficultIncSatiety = 1f;
					DifficultSpeed = 1f;
					DecSatiety = 0.35f;
					IncSatiety = 0.2f;
					IncSpeed = 0.1f;	
					
					ScoreAndSatiety.Satiety = 50f;
					ScoreAndSatiety.Scores = 0;	
					
					IsLose = false;	
					
					Time.timeScale=1;	
					
					InsectsGenerator.NextStage = 200;
        		}
    }
}
