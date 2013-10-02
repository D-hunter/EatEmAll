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

        public const float ZDepth = 100;

        private bool isPlay = false;
        private bool isExit = false;

        private float _screenWidth;
        
        void Start()
        {
            GetScreenParameters();
            CalibratePosition();
            SetTextures();
            SetSize();
        }

        void Update()
        {
            CalibratePosition();
            SetSize();
            HandleTap();
        }

        private void GetScreenParameters()
        {
            _screenWidth = Screen.width;
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
            isPlay = true;
            SetTextures();
            Application.LoadLevel(1);
        }

        private void PushExitButton()
        {
            isExit = true;
            SetTextures();
            Application.Quit();
        }

        private void SetTextures()
        {
            Play.renderer.material = !isPlay ? PlayPassive : PlayActive;
            Exit.renderer.material = !isExit ? ExitPassive : ExitActive;
        }

        private void CalibratePosition()
        {
            transform.position = Vector3.zero;
            Play.transform.position = new Vector3(0, _screenWidth / 4, ZDepth);
            Exit.transform.position = new Vector3(0, -_screenWidth / 4, ZDepth);
        }

        private void SetSize()
        {
            Play.transform.localScale = new Vector3(_screenWidth / 4, _screenWidth / 4, 1);
            Exit.transform.localScale = new Vector3(_screenWidth / 4, _screenWidth / 4, 1);
        }
    }
}
