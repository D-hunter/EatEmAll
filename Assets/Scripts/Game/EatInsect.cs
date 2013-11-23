using UnityEngine;

namespace Assets.Scripts.Game
{
		public class EatInsect : MonoBehaviour
		{
		
				private void OnTriggerEnter2D (Collider2D insect)
				{
						var score = insect.gameObject.GetComponent<InsectInfo> ().OnEatScoreAdd;
						var satietyInc = insect.gameObject.GetComponent<InsectInfo> ().OnEatSatietyAdd;
						var satietyDec = insect.gameObject.GetComponent<InsectInfo> ().OnEatSatietyDec;
						ScoreAndSatiety.Scores += score;
						ScoreAndSatiety.Satiety += satietyInc;
						ScoreAndSatiety.Satiety -= satietyDec;
						if (insect.gameObject.GetComponent<InsectInfo> ().IsBonusInsect) {
								ChooseAndPerformBonus ();
						}
						Destroy (insect.gameObject);
				}

				private void ChooseAndPerformBonus ()
				{
						
						float controlParameter = Random.value;
						if (controlParameter <= 0.25f) {
								Bonus.StartSlowSpeed ();
						}
						if (controlParameter > 0.25f && controlParameter <= 0.50f) {
								Bonus.StartMultiplyScores ();
						}
						if (controlParameter > 0.50f && controlParameter <= 0.75f) {
								Bonus.StartFastSpeed ();
						}
						if (controlParameter > 0.75f && controlParameter <= 1f) {
								Bonus.StartSwarm ();
						}
						Notification.ShowBonus();
				}

				private void ChangeSatiety (int satiety)
				{
						if (ScoreAndSatiety.Satiety > 100f) {
								ScoreAndSatiety.Satiety = 100f;
						} else if (ScoreAndSatiety.Satiety < 0f) {
								ScoreAndSatiety.Satiety = 0f;
						} else {
								ScoreAndSatiety.Satiety += satiety;
						}
				}
		}
}
