using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class PauseController : MonoBehaviour {
	
		bool IsPaused = false;
		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		void Update () 
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				if(!GameMenuButtonsController._isGameMenuActive)
				{
					GameMenuButtonsController.PushGameMenuButton();
				}
				else
				{
					GameMenuButtonsController.PushResumeButton();
				}				
			}		
		}
	}
}
