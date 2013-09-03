using System.Globalization;
using UnityEngine;

namespace Assets.Eat_Em_All.Scripts.Game
{
    public class Score : MonoBehaviour
    {
        public static int Scores;

        private void Update()
        {

            if (Input.GetMouseButtonUp(0))
            {
                Scores += 1;
                Debug.Log(Scores);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Scores -= 1;
                Debug.Log(Scores);
            }

        }

        private void OnGUI()
        {
            if (Scores >= 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), Scores.ToString());
            }
            else
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), "You Lose!");
            }
        }
    }
}
