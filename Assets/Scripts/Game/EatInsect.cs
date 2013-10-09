using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game{
	public class EatInsect : MonoBehaviour {
		void OnTriggerEnter(Collider insect)
		{
			var score = insect.gameObject.GetComponent<InsectInfo>().OnEatScoreAdd;
			var satiety = insect.gameObject.GetComponent<InsectInfo>().OnEatSatietyAdd;
			ScoreAndSatiety.Scores+=score;
			ScoreAndSatiety.Satiety+=satiety;
			if(insect.gameObject.GetComponent<InsectInfo>().IsBonusInsect)
			{
				ChooseAndPerformBonus();
			}
			Destroy(insect.gameObject);
		}	
		
		void ChooseAndPerformBonus()
		{
			float controlParameter = Random.value;
			if(controlParameter<=0.33f)
			{
				Bonus.StartSlowSpeed();	
			}
			if(controlParameter>0.33f&&controlParameter<=0.66f)
			{
				Bonus.StartMultiplyScores();	
			}
			if(controlParameter>0.66f&&controlParameter<=1f)
			{
				
			}
		}
	}
}
