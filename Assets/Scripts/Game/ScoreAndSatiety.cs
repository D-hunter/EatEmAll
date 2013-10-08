using System.Runtime.Serialization.Formatters;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ScoreAndSatiety : MonoBehaviour
    {
        public static int Scores = 0;
        public static int Satiety = 50;
        public GameObject SatietyBackground;
        public GameObject SatietyScale;

        void Awake()
        {
            SatietyScale = gameObject;
        }

        void Update()
        {
            ChangeScaleSize();
        }

        private void OnGUI()
        {
            ShowScoreOnBox();
//            ShowNumSatietyOnBox();
        }

        void ShowScoreOnBox()
        {
            if (Scores >= 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 10, 200, 25), "Scores  = " + Scores);
            }
        }

//        void ShowNumSatietyOnBox()
//        {
//            if (Satiety >= 1)
//            {
//                GUI.Box(new Rect(Screen.width - 50, Screen.height / 2 - 100, ChangeScaleSize(), 25), "Scale = " + Satiety);
//            }
//            else
//            {
//                GUI.Box(new Rect(10, Screen.height / 2 - 100, 100, 25), "YOU DEAD!");
//            }
//        }

        private void ChangeScaleSize()
        {
            Vector3 oldScaleSize = SatietyScale.transform.localScale;
            float difference = oldScaleSize.y - SatietyScale.transform.localScale.y;

            SatietyScale.transform.localScale = new Vector3(SatietyScale.transform.localScale.x, Satiety, SatietyScale.transform.localScale.z);
            SatietyScale.transform.position += new Vector3(0, difference, 0);

            oldScaleSize = SatietyScale.transform.localScale;
        }

    }
}
