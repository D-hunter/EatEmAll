using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameMenuButtonsController : MonoBehaviour
    {
        public GameObject GameMenu;
        public Material GameMenuActive;
        public Material GameMenuPassive;
        public GameObject Resume;
        public Material ResumeActive;
        public Material ResumePassive;
        public GameObject ToMenu;
        public Material ToMenuActive;
        public Material ToMenuPassive;

        public const float ZDepth = 100;

        private bool _isGameMenu = false;
        private bool _isToMenu = false;
        private bool _isResume = false;

        private float _screenWidth;
        
        private void Start()
        {
            LoadRecord();
            GetScreenParameters();
            CalibratePosition();
            SetSize();
            SetTextures();
        }

        private void Update()
        {
            GetScreenParameters();
            ShowButtons();
            CalibratePosition();
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
                            case "Menu":
                                {
                                    PushGameMenuButton();
                                    break;
                                }
                            case "Resume":
                                {
                                    PushResumeButton();
                                    break;
                                }
                            case "ToMainMenu":
                                {
                                    PushToMenuButton();
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void PushGameMenuButton()
        {
            _isGameMenu = true;
            MakePause();
        }

        private void PushToMenuButton()
        {
            _isToMenu = true;
            _isGameMenu = false;
            SaveRecord();
            ClearScores();
            MakeUnpause();
            Application.LoadLevel(0);
        }

        private void PushResumeButton()
        {
            _isResume = true;
            _isGameMenu = false;
            MakeUnpause();
        }

        private void SetTextures()
        {
            GameMenu.renderer.material = !_isGameMenu ? GameMenuPassive : GameMenuActive;
            ToMenu.renderer.material = !_isToMenu ? ToMenuPassive : ToMenuActive;
            Resume.renderer.material = !_isResume ? ResumePassive : ResumeActive;
        }

        private void CalibratePosition()
        {
            transform.position = new Vector3(0, 0, 100);

            GameMenu.transform.position = new Vector3(-_screenWidth / 3, _screenWidth / 1.65f, ZDepth);
            ToMenu.transform.position = new Vector3(0, _screenWidth / 6, ZDepth);
            Resume.transform.position = new Vector3(0, -_screenWidth / 6, ZDepth);
        }

        private void SetSize()
        {
            GameMenu.transform.localScale = new Vector3(_screenWidth / 4, _screenWidth / 4, 1);
            ToMenu.transform.localScale = new Vector3(_screenWidth / 4, _screenWidth / 4, 1);
            Resume.transform.localScale = new Vector3(_screenWidth / 4, _screenWidth / 4, 1);
        }

        private void ShowButtons()
        {
            if (!_isGameMenu)
            {
                GameMenu.renderer.enabled = true;
                ToMenu.renderer.enabled = false;
                Resume.renderer.enabled = false;

                GameMenu.collider.enabled = true;
                ToMenu.collider.enabled = false;
                Resume.collider.enabled = false;
            }
            else
            {
                GameMenu.renderer.enabled = false;
                ToMenu.renderer.enabled = true;
                Resume.renderer.enabled = true;

                GameMenu.collider.enabled = false;
                ToMenu.collider.enabled = true;
                Resume.collider.enabled = true;
            }
        }

        private void MakePause()
        {
            Time.timeScale = 0;
        }

        private void MakeUnpause()
        {
            Time.timeScale = 1;
        }

        private void SaveRecord()
        {
            int score = ScoreAndSatiety.Scores;

            if (ShowRecords.BestScore < score)
            {
                ShowRecords.SaveReecord(score);
            } 
        }

        private void LoadRecord()
        {
            ShowRecords.LoadRecord();
        }

        private void ClearScores()
        {
            ScoreAndSatiety.Scores = 0;
        }
    }
}