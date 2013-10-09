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
            ChangeSatiety(satiety);
            Destroy(insect.gameObject);
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
