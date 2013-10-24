using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainMenuButtonsController : MonoBehaviour
    {
        public GameObject Play;
        public Material PlayActive;
        public Material PlayPassive;
        public GameObject Exit;
        public Material ExitActive;
        public Material ExitPassive;

        private bool isPlayActive = false;
        private bool isExitActive = false;

        private void Start()
        {
            SetTextures();
        }

        private void Update()
        {
            HandleTap();
        }

        private void HandleTap()
        {
            Touch touch;
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit))
                    {
                        string hitTag = hit.collider.gameObject.tag;
                        switch (hitTag)
                        {
                            case "Play":
                            {
                                PushPlayButton();
                                break;
                            }
                            case "Exit":
                            {
                                PushExitButton();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void PushPlayButton()
        {
            isPlayActive = true;
            SetTextures();
            Application.LoadLevel(1);
        }

        private void PushExitButton()
        {
            isExitActive = true;
            SetTextures();
            Application.Quit();
        }

        private void SetTextures()
        {
            Play.renderer.material = !isPlayActive ? PlayPassive : PlayActive;
            Exit.renderer.material = !isExitActive ? ExitPassive : ExitActive;
        }
    }
}
