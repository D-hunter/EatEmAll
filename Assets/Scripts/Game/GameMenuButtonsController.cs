using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameMenuButtonsController : MonoBehaviour
    {
        public GameObject GameMenuSprite;
        public Collider GameMenuButton;
        public GameObject ResumeSprite;
        public Collider ResumeButton;
        public GameObject ToMenuSprite;
        public Collider ToMenuButton;
        public GameObject BackgroundSprite;
        
        public bool _isGameMenuActive = false;
        public bool _isToMenuActive = false;

        private void Start()
        {
            LoadRecord();
            try
            {
                ShowGameMenu();
            }
            catch (MissingReferenceException)
            {
            }
        }

        public void PushGameMenuButton()
        {
            try
            {
                _isGameMenuActive = true;
                ActivateGamePause();
                ShowGameMenu();
            }
            catch (MissingReferenceException)
            {
            }
        }

        private void PushToMenuButton()
        {
            try
            {
                _isToMenuActive = true;
                _isGameMenuActive = false;
                SaveRecord();
                ClearScores();
                DeactivateGamePause();
                Application.LoadLevel(0);
                ShowGameMenu();
            }
            catch (MissingReferenceException)
            {
            }
        }

        public void PushResumeButton()
        {
            try
            {
                _isGameMenuActive = false;
                DeactivateGamePause();
                ShowGameMenu();
            }
            catch (MissingReferenceException)
            {
            }
            
        }

        public void ShowGameMenu()
        {
            if (!_isGameMenuActive)
            {
                GameMenuSprite.GetComponent<UISprite>().enabled = true;
                ToMenuSprite.GetComponent<UISprite>().enabled = false;
                ResumeSprite.GetComponent<UISprite>().enabled = false;
                BackgroundSprite.GetComponent<UISprite>().enabled = false;

                GameMenuButton.GetComponent<Collider>().enabled = true;
                ToMenuButton.GetComponent<Collider>().enabled = false;
                ResumeButton.GetComponent<Collider>().enabled = false;
//                BackgroundButton.collider.enabled = false;
            }
            else
            {
                GameMenuSprite.GetComponent<UISprite>().enabled = false;
                ToMenuSprite.GetComponent<UISprite>().enabled = true;
                ResumeSprite.GetComponent<UISprite>().enabled = true;
                BackgroundSprite.GetComponent<UISprite>().enabled = true;

                GameMenuButton.GetComponent<Collider>().enabled = false;
                ToMenuButton.GetComponent<Collider>().enabled = true;
                ResumeButton.GetComponent<Collider>().enabled = true;
//                BackgroundButton.collider.enabled = true;
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