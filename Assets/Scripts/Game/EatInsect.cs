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
			Destroy(insect.gameObject);
		}	
	}
}
