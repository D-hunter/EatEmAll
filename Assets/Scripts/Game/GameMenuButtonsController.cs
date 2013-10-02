﻿using UnityEngine;

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
            CalibratePosition();
            SetSize();
//            SetTextures();
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
//            PushToMenuButton();
//            PushResumeButton();
            MakePause();
        }

        private void PushToMenuButton()
        {
            _isGameMenu = false;
            SaveRecord();
            ClearScores();
            MakeUnpause();
            Application.LoadLevel(0);
        }

        private void PushResumeButton()
        {
            _isGameMenu = false;
            MakePause();
        }

        private void SetTextures()
        {
            GameMenu.renderer.material = !_isGameMenu ? GameMenuPassive : GameMenuActive;
            ToMenu.renderer.material = !_isToMenu ? ToMenuPassive : ToMenuActive;
            Resume.renderer.material = !_isResume ? ResumePassive : ResumeActive;
        }

        private void CalibratePosition()
        {
            transform.position = Vector3.zero;
            transform.localScale = Vector3.zero;

            GameMenu.transform.position = new Vector3(-_screenWidth / 8, _screenWidth / 8, ZDepth);
            ToMenu.transform.position = new Vector3(0, _screenWidth / 4, ZDepth);
            Resume.transform.position = new Vector3(0, -_screenWidth / 4, ZDepth);
        }

        private void SetSize()
        {
            GameMenu.transform.localScale = new Vector3(_screenWidth / 12, _screenWidth / 12, 1);
            ToMenu.transform.localScale = new Vector3(_screenWidth / 12, _screenWidth / 12, 1);
            Resume.transform.localScale = new Vector3(_screenWidth / 12, _screenWidth / 12, 1);
        }

        private void ShowButtons()
        {
            if (!_isGameMenu)
            {
                GameMenu.renderer.enabled = true;
                ToMenu.renderer.enabled = false;
                Resume.renderer.enabled = false;
            }
            else
            {
                GameMenu.renderer.enabled = false;
                ToMenu.renderer.enabled = true;
                Resume.renderer.enabled = true;
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
            int score = ScoreAndScale.Scores;

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
            ScoreAndScale.Scores = 0;
        }
    }
}


