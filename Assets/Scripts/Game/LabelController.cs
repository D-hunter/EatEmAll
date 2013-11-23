using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class LabelController : MonoBehaviour {
	
		// Use this for initialization
		public static GameObject BonusLabel;
		
		void Start () {
			BonusLabel = GameObject.Find("BonusLabel");
			DisableBonusLabel();
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		private static void ChooseBonusLabel()
		{
			if(Bonus.FastSpeedActiv)
				BonusLabel.GetComponent<UILabel>().text = "Speed x2";
			if(Bonus.MultiplyScoresActiv)
				BonusLabel.GetComponent<UILabel>().text = "Score x2";
			if(Bonus.SlowSpeedActiv)
				BonusLabel.GetComponent<UILabel>().text = "Slow";
			if(Bonus.SwarmActiv)
				BonusLabel.GetComponent<UILabel>().text = "SWARM!!";		
		}
		public static void EnableBonusLabel()
		{
			ChooseBonusLabel();
			BonusLabel.GetComponent<TweenScale>().enabled = true;
			BonusLabel.GetComponent<UILabel>().enabled = true;
		}
		public static void DisableBonusLabel()
		{
			BonusLabel.GetComponent<TweenScale>().enabled = false;
			BonusLabel.GetComponent<UILabel>().enabled = false;
			BonusLabel.GetComponent<TweenScale>().Reset();
		}
	}
}