using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ScoreAndSatiety : MonoBehaviour
    {
        public static int Scores = 0;
        public static int Satiety = 50;
        public GameObject SatietyBackground;
        public GameObject SatietyScale;

        private int oldSatiety = Satiety;
        private Vector3 _oldSatietyScale;

        private void Awake()
        {
            InitializeScale();
            ChangeScaleColor();
        }

        private void Update()
        {
            CheckSatietyState();
            WhenToChangeScale();
        }

        private void OnGUI()
        {
            ShowScoreOnBox();
        }

        private void InitializeScale()
        {
            SatietyScale = gameObject;
            SatietyScale.transform.localScale = new Vector3(SatietyScale.transform.localScale.x, Satiety * 2, SatietyScale.transform.localScale.z);
            _oldSatietyScale = SatietyScale.transform.localScale;
        }

        private void ShowScoreOnBox()
        {
            GUI.Box(new Rect(Screen.width / 3f, 10, Screen.width / 2f, Screen.width / 10f), "Scores  = " + Scores);
            new Rect();
        }

        private void WhenToChangeScale()
        {
            if (Satiety != oldSatiety)
            {
                ChangeScaleSize(OffsetDirection());
            }
        }

        private int OffsetDirection()
        {
            if (Satiety >= oldSatiety)
            {
                return 1;
            }
            else
            {
                return -1;    
            }
        }

        private void ChangeScaleSize(int offsetDirection)
        {
            SatietyScale.transform.localScale = new Vector3(SatietyScale.transform.localScale.x, Satiety * 2, SatietyScale.transform.localScale.z);

            float possitionOffset = (_oldSatietyScale.y - SatietyScale.transform.localScale.y) / 2;

            SatietyScale.transform.position += new Vector3(0, possitionOffset * offsetDirection, 0);

            ChangeScaleColor();
            _oldSatietyScale = SatietyScale.transform.localScale;
        }

        private void ChangeScaleColor()
        {
            SatietyScale.renderer.material.color = Color.Lerp(Color.red, Color.green, Satiety / 100.0f);
        }

        private void CheckSatietyState()
        {
            if (Satiety > 100)
            {
                Satiety = 100;
            }
            else if (Satiety < 0)
            {
                Satiety = 0;
            }
        }
    }
}
