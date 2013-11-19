using UnityEngine;

namespace Assets.Scripts.Game
{
		public class ScoreAndSatiety : MonoBehaviour
		{
				public static int Scores = 0;
				public static float Satiety = 50f;
				public GameObject SatietyBackground;
				public GameObject SatietyScale;
		
				public static int FullSatiety = 100;
				public static int HalfSatiety = 50;
				public TextMesh ScoreLable;

				private float oldSatiety = Satiety;
				private Vector3 _oldSatietyScale;

				private void Awake ()
				{
						InitializeScale ();
						ChangeScaleColor ();
				}

				private void Update ()
				{
						CheckSatietyState ();
						WhenToChangeScale ();
						ShowScoreOnBox ();
				}

				private void InitializeScale ()
				{
						SatietyScale.transform.localScale = new Vector3 (SatietyScale.transform.localScale.x, Satiety * 2, SatietyScale.transform.localScale.z);
						_oldSatietyScale = SatietyScale.transform.localScale;
				}

				private void ShowScoreOnBox ()
				{
						ScoreLable.text = Scores.ToString();
				}

				private void WhenToChangeScale ()
				{
						if (Satiety != oldSatiety) {
								ChangeScaleSize (OffsetDirection ());
						}
				}

				private int OffsetDirection ()
				{
						if (Satiety != oldSatiety) {
								return -1;
						}
						return 1;
				} 

				private void ChangeScaleSize (int offsetDirection)
				{
						SatietyScale.transform.localScale = new Vector3 (SatietyScale.transform.localScale.x, Satiety * 2, SatietyScale.transform.localScale.z);

						float possitionOffset = (_oldSatietyScale.y - SatietyScale.transform.localScale.y) / 2;

						SatietyScale.transform.position += new Vector3 (0, possitionOffset * offsetDirection, 0);

						ChangeScaleColor ();
						_oldSatietyScale = SatietyScale.transform.localScale;
				}

				private void ChangeScaleColor ()
				{
						SatietyScale.renderer.material.color = Color.Lerp (Color.red, Color.green, Satiety / 100.0f);
				}

				private void CheckSatietyState ()
				{
						if (Satiety > 100) {
								Satiety = 100;
						} else if (Satiety < 0) {
								Satiety = 0;
						}
				}
				private void CheckFulfilledSatiety ()
				{
						if (Satiety >= 100)
								Bonus.StartFullSatiety ();
				}
		}
}
