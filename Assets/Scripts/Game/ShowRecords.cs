using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ShowRecords : MonoBehaviour
    {
        public static int BestScore = 0;

        public static void SaveReecord(int score)
        {
            PlayerPrefs.SetInt("Score", score);
            BestScore = score;
            PlayerPrefs.Save();
        }

        public static int LoadRecord()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                int score = PlayerPrefs.GetInt("Score");
                BestScore = score;
                return score;
            }
            return 0;
        }

        public void OnGUI()
        {
            ShowLable();
        }

        private void ShowLable()
        {
            GUI.Box(new Rect(Screen.width*0.9f, 10, 24, 24), BestScore.ToString());
        }
    }
}
