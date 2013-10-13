using UnityEngine;

namespace Assets.Scripts.Game
{
    public class EatInsect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider insect)
        {
            var score = insect.gameObject.GetComponent<InsectInfo>().OnEatScoreAdd;
            var satiety = insect.gameObject.GetComponent<InsectInfo>().OnEatSatietyAdd;
            ScoreAndSatiety.Scores += score;
            ScoreAndSatiety.Satiety += satiety;
            if (insect.gameObject.GetComponent<InsectInfo>().IsBonusInsect)
            {
                ChooseAndPerformBonus();
            }
            Destroy(insect.gameObject);
        }

        private void ChooseAndPerformBonus()
        {
            float controlParameter = Random.value;
            if (controlParameter <= 0.25f)
            {
                Bonus.StartSlowSpeed();
            }
            if (controlParameter > 0.25f && controlParameter <= 0.50f)
            {
                Bonus.StartMultiplyScores();
            }
            if (controlParameter > 0.50f && controlParameter <= 0.75f)
            {
				Bonus.StartFastSpeed();
            }
			if (controlParameter > 0.75f && controlParameter <= 1f)
            {
            }
        }

        private void ChangeSatiety(int satiety)
        {
            if (ScoreAndSatiety.Satiety > 100)
            {
                ScoreAndSatiety.Satiety = 100;
            }
            else if (ScoreAndSatiety.Satiety < 0)
            {
                ScoreAndSatiety.Satiety = 0;
            }
            else
            {
                ScoreAndSatiety.Satiety += satiety;
            }
        }
    }
}
