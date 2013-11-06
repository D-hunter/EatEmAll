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
        public GameObject Background;
        public Material BackgroundMaterial;

        public static bool _isGameMenuActive = false;
        public static bool _isToMenuActive = false;

        private void Start()
        {
            LoadRecord();
            SetTextures();
        }

        private void Update()
        {
            ShowGameMenu();
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

        public static void PushGameMenuButton()
        {
            _isGameMenuActive = true;
            ActivateGamePause();
        }

        private void PushToMenuButton()
        {
            _isToMenuActive = true;
            _isGameMenuActive = false;
            SaveRecord();
            ClearScores();
            DeactivateGamePause();
            Application.LoadLevel(0);
        }

        public static void PushResumeButton()
        {
            _isGameMenuActive = false;
            DeactivateGamePause();
        }

        private void SetTextures()
        {
            GameMenu.renderer.material = !_isGameMenuActive ? GameMenuPassive : GameMenuActive;
            ToMenu.renderer.material = !_isToMenuActive ? ToMenuPassive : ToMenuActive;
            Resume.renderer.material = !_isGameMenuActive ? ResumePassive : ResumeActive;
            Background.renderer.material = BackgroundMaterial;
        }

        private void ShowGameMenu()
        {
            if (!_isGameMenuActive)
            {
                GameMenu.renderer.enabled = true;
                ToMenu.renderer.enabled = false;
                Resume.renderer.enabled = false;
                Background.renderer.enabled = false;

                GameMenu.collider.enabled = true;
                ToMenu.collider.enabled = false;
                Resume.collider.enabled = false;
                Background.collider.enabled = false;
            }
            else
            {
                GameMenu.renderer.enabled = false;
                ToMenu.renderer.enabled = true;
                Resume.renderer.enabled = true;
                Background.renderer.enabled = true;

                GameMenu.collider.enabled = false;
                ToMenu.collider.enabled = true;
                Resume.collider.enabled = true;
                Background.collider.enabled = true;
            }
        }

        public static void ActivateGamePause()
        {
            Time.timeScale = 0;
        }

        public static void DeactivateGamePause()
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