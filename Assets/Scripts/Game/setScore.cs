using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ShowRecords : MonoBehaviour
    {
        private static int _bestScore = 0;

        public static void SaveReecord(int score)
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.SetInt("Score", score);
                _bestScore = score;
                PlayerPrefs.Save();
            }
        }

        public static int LoadRecord()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                int score = PlayerPrefs.GetInt("Score");
                _bestScore = score;
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
            GUI.Box(new Rect(Screen.width*0.9f, 50, 24, 24), _bestScore.ToString());
        }
    }
}
