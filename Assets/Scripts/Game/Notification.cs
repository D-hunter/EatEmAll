using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class Notification : MonoBehaviour {
	
	
		private static GameObject bonus;
		private static float startTime=0f;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () {
			if(startTime+1.3f<Time.time)
			HideBonus();		
		}

		public static void ShowBonus()
		{
			startTime = Time.time;
			LabelController.EnableBonusLabel();
		}
		private static void HideBonus()
		{
			LabelController.DisableBonusLabel();
		}
	}
}
