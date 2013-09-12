using UnityEngine;

namespace Assets.Eat_Em_All.Scripts.Game
{
    public class ScoreAndScale : MonoBehaviour
    {
        public static int Scores;
        public static int Scale = 1;

        private void Update()
        {
            ScoreChanger();
            ScaleCahnger();
        }

        private void OnGUI()
        {
            ShowScoreOnBox();
            ShowNumScaleOnBox();
        }

        void ScoreChanger()
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Scores += 1;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && Scores > -1)
            {
                Scores -= 1;
            }
        }

        void ScaleCahnger()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Scale += 1;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && Scale > 0)
            {
                Scale -= 1;
            } 
        }

        void ShowScoreOnBox()
        {
            if (Scores >= 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), "Scores  = " + Scores);
            }
            else
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), "You Lose!");
            }
        }

        void ShowNumScaleOnBox()
        {
            if (Scale >= 1)
            {
                GUI.Box(new Rect(10, Screen.height / 2 - 100, 100, 25), "Scale = " + Scale);
                
            }
            else
            {
                GUI.Box(new Rect(10, Screen.height / 2 - 100, 100, 25), "YOU DEAD!");
            }
        }
    }
}
