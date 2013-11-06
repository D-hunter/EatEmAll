using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class PauseController : MonoBehaviour {
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
