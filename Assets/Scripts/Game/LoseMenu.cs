using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
		public class LoseMenu : MonoBehaviour
		{

				GameObject Menu;
				GameObject Restart;
				GameObject Background;
				// Use this for initialization
				void Start ()
				{
						Menu = GameObject.Find ("Menu");
						Restart = GameObject.Find ("Restart");	
						Background = GameObject.Find("LoseMenuBackground");
						HideLoseMenu();					
				}
		
				// Update is called once per frame
				void Update ()
				{
						CheckIsLose ();
				}

				private void HideLoseMenu()
				{
					Menu.collider.enabled = false;
					Menu.GetComponentInChildren<UISprite> ().enabled = false;
					Restart.collider.enabled = false;
					Restart.GetComponentInChildren<UISprite> ().enabled = false;
					Background.GetComponent<UISprite>().enabled = false;
				}
				
				private void ShowLoseMenu()
				{
					Menu.collider.enabled = true;
					Menu.GetComponentInChildren<UISprite> ().enabled = true;
					Restart.collider.enabled = true;
					Restart.GetComponentInChildren<UISprite> ().enabled = true;	
					Background.GetComponent<UISprite>().enabled = true;
        		}

				private void CheckIsLose ()
				{
						if (Game.IsLose) {
							ShowLoseMenu();
							//Game.DisableTocuhColliders();
						}
				}
				private void PushRestart()
				{					
					HideLoseMenu();
					//Game.EnableTouchColliders();
					Game.SetDefaults();
					Game.IsLose = false;
					ScoreAndSatiety.Satiety = 50f;
					ScoreAndSatiety.Scores = 0;
					Time.timeScale = 1;
					Application.LoadLevel(1);
				}
				
		}
}
