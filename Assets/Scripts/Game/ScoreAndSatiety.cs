using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ScoreAndSatiety : MonoBehaviour
    {
        public static int Scores = 0;
        public static int Satiety = 10;
		
        private void OnGUI()
        {
            ShowScoreOnBox();
            ShowNumSatietyOnBox();
        }

        void ShowScoreOnBox()
        {
            if (Scores >= 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), "Scores  = " + Scores);
            }
        }

        void ShowNumSatietyOnBox()
        {
            if (Satiety >= 1)
            {
                GUI.Box(new Rect(10, Screen.height / 2 - 100, 100, 25), "Scale = " + Satiety);
                
            }
            else
            {
                GUI.Box(new Rect(10, Screen.height / 2 - 100, 100, 25), "YOU DEAD!");
            }
        }
    }
}
