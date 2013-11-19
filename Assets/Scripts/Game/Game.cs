using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
		public class Game : MonoBehaviour
		{

				public static bool IsPause = false;
				public static bool IsLose = false;

				public GameMenuButtonsController Controller;
				// Use this for initialization
				void  Start ()
				{
		
				}
		
				// Update is called once per frame
				void Update ()
				{
		
				}
				public void CheckPause ()
				{
						if (Input.GetKeyUp (KeyCode.Escape)) {
								if (!Controller._isGameMenuActive) {
										Controller.PushGameMenuButton ();
								} else {
										Controller.PushResumeButton ();
								}
						}
				}
				
				public void DisableTocuhColliders()
				{
				
				}

		}
}
