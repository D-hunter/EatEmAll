using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class PauseController : MonoBehaviour
    {
        public GameMenuButtonsController Controller;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!Controller._isGameMenuActive)
                {
                    Controller.PushGameMenuButton();
                }
                else
                {
                    Controller.PushResumeButton();
                }
            }
        }
    }
}
