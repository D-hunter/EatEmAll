using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MainMenuButtonsController : MonoBehaviour
    {
        public GUITexture Play;
        public Texture2D PlayActive;
        public Texture2D PlayPassive;
        public GUITexture Exit;
        public Texture2D ExitActive;
        public Texture2D ExitPassive;

        private bool isPlay = false;
        private bool isExit = false;

        private float _screenWidth;
        private float _screenHeight;
        private Touch _touch;

        private void Start()
        {
            CalibratePosition();
            SetTextures();
        }

        private void Update()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
            CalibratePosition();
            HandleTap();
        }

        private void HandleTap()
        {
            var count = Input.touchCount;
            for (int i = 0; i < count; i++)
            {
                _touch = Input.GetTouch(i);
                if (_touch.tapCount != 0)
                {
                    PlayButton();
                    ExitButton();
                }
            }
        }

        private void PlayButton()
        {
            if (Play.HitTest(_touch.position) && !isPlay)
            {
                Debug.Log("Play");
                Application.LoadLevel(1);
            }
        }

        private void ExitButton()
        {
            if (Exit.HitTest(_touch.position) && !isExit)
            {
                Debug.Log("Exit");
                Application.Quit();
            }
        }

        private void SetTextures()
        {
            Play.guiTexture.texture = !isPlay ? PlayPassive : PlayActive;
            Exit.guiTexture.texture = !isExit ? ExitPassive : ExitActive;
        }

        private void CalibratePosition()
        {
            transform.position = Vector3.zero;
            transform.localScale = Vector3.zero;
            Play.transform.localScale = Vector3.zero;
            Exit.transform.localScale = Vector3.zero;
            Play.transform.position = Vector3.zero;
            Exit.transform.position = Vector3.zero;

            Play.pixelInset = new Rect(_screenWidth / 2, _screenHeight / 1.7f, 64, 64);
            Exit.pixelInset = new Rect(Play.pixelInset.x, Play.pixelInset.y - _screenHeight / 4, 64, 64);
        }
    }
}
