using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameMenuButtonsController : MonoBehaviour
    {
        public GUITexture Open;
        public Texture2D OpenActive;
        public Texture2D OpenPassive;
        public GUITexture ToMenu;
        public Texture2D ToMenuActive;
        public Texture2D ToMenuPassive;
        public GUITexture Resume;
        public Texture2D ResumeActive;
        public Texture2D ResumePassive;

        private bool _isOpen = false;
        private bool _isToMenu = false;
        private bool _isResume = false;

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
            ShowButtons();
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
                    OpenButton();
                    ToMenuButton();
                    ResumeButton();
                }
            }
        }

        private void OpenButton()
        {
            if (Open.HitTest(_touch.position) && !_isOpen)
            {
                _isOpen = true;
                ToMenuButton();
                ResumeButton();
                Time.timeScale = 0;
            }
        }

        private void ToMenuButton()
        {
            if (ToMenu.HitTest(_touch.position))
            {
                Debug.Log("ToMenu");
                _isOpen = false;
                Time.timeScale = 1;
                Application.LoadLevel(0);
            }
        }

        private void ResumeButton()
        {
            if (Resume.HitTest(_touch.position))
            {
                Debug.Log("ToMenu");
                _isOpen = false;
                Time.timeScale = 1;
            }
        }

        private void SetTextures()
        {
            Open.guiTexture.texture = !_isOpen ? OpenPassive : OpenActive;
            ToMenu.guiTexture.texture = !_isToMenu ? ToMenuPassive : ToMenuActive;
            Resume.guiTexture.texture = !_isResume ? ResumePassive : ResumeActive;
        }

        private void CalibratePosition()
        {
            transform.position = Vector3.zero;
            transform.localScale = Vector3.zero;
            Open.transform.localScale = Vector3.zero;
            ToMenu.transform.localScale = Vector3.zero;
            Open.transform.position = Vector3.zero;
            ToMenu.transform.position = Vector3.zero;
            Resume.transform.position = Vector3.zero;
            Resume.transform.position = Vector3.zero;

            Open.pixelInset = new Rect(_screenWidth * 0.08f, _screenHeight * 0.8f, 64, 64);
            ToMenu.pixelInset = new Rect(_screenWidth * 0.08f, _screenHeight/1.7f, 64, 64);
            Resume.pixelInset = new Rect(ToMenu.pixelInset.x, ToMenu.pixelInset.y - _screenHeight/4, 64, 64);
        }

        private void ShowButtons()
        {
            if (!_isOpen)
            {
                Open.enabled = true;
                ToMenu.enabled = false;
                Resume.enabled = false;
            }
            else
            {
                Open.enabled = false;
                ToMenu.enabled = true;
                Resume.enabled = true;
            }
        }
    }
}


