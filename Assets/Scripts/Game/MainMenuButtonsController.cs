using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainMenuButtonsController : MonoBehaviour
    {
        private void PushPlayButton()
        {
            Application.LoadLevel(1);
        }

        private void PushExitButton()
        {
            Application.Quit();
        }
    }
}
