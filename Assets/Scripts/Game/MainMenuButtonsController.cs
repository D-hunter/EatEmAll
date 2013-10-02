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

        private bool isPlay = false;
        private bool isExit = false;

        private float _screenWidth;
        private float _screenHeight;

        void Start()
        {
            GetScreenParameters();
//            CalibratePosition();
//            SetTextures();
        }

        void Update()
        {
//            CalibratePosition();
            HandleTap();
        }

        private void GetScreenParameters()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
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
                            case "Play": PushPlayButton(); break;
                            case "Exit": PushExitButton(); break;
                        }
                    }
                }
            }
        }

        private void PushPlayButton()
        {
            Application.LoadLevel(1);
        }

        private void PushExitButton()
        {
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
            transform.localScale = Vector3.zero;
            Play.transform.localScale = Vector3.zero;
            Exit.transform.localScale = Vector3.zero;
            Play.transform.position = Vector3.zero;
            Exit.transform.position = Vector3.zero;

//            Play.pixelInset = new Rect(_screenWidth/2, _screenHeight/1.7f, 64, 64);
//            Exit.pixelInset = new Rect(Play.pixelInset.x, Play.pixelInset.y - _screenHeight/4, 64, 64);
        }
    }
}
