using UnityEngine;

namespace Assets.Scripts.Game
{
    [ExecuteInEditMode]
    public class MenuParamsCalculator : MonoBehaviour
    {
        public GUIObject Sprite;
        public float heightPercent;
        public float widthPercent;

        private void Start()
        {
            CalculatePercents();
            CalibrateSizeAndPosition();
        }

        private void Update()
        {
            CalculatePercents();
            CalibrateSizeAndPosition();
        }

        private void CalculatePercents()
        {
            heightPercent = Screen.height * 0.01f;
            widthPercent = Screen.width * 0.01f;
        }

        private void CalibrateSizeAndPosition()
        {
            ChooseSettingsToSet(Sprite);
        }

        private void ChooseSettingsToSet(GUIObject currentObject)
        {
            if (currentObject.ChangeLeft)
            {
                Sprite.ElementSprite.transform.position = new Vector3(Sprite.LeftPercent * widthPercent, Sprite.ElementSprite.transform.position.y, Sprite.ElementSprite.transform.position.z);
                Sprite.ElementCollider.transform.position = Sprite.ElementSprite.transform.position;
            }
            if (currentObject.ChangeTop)
            {
                Sprite.ElementSprite.transform.position = new Vector3(Sprite.ElementSprite.transform.position.x, Sprite.TopPercent * heightPercent, Sprite.ElementSprite.transform.position.z);
                Sprite.ElementCollider.transform.position = Sprite.ElementSprite.transform.position;
            }
            if (currentObject.ChangeWidth)
            {
                Sprite.ElementSprite.transform.localScale = new Vector3(Sprite.WidthPercent * widthPercent, Sprite.ElementSprite.transform.localScale.y, 1f);
                Sprite.ElementCollider.transform.localScale = Sprite.ElementSprite.transform.localScale;
            }
            if (currentObject.ChangeHeight)
            {
                Sprite.ElementSprite.transform.localScale = new Vector3(Sprite.ElementSprite.transform.localScale.x, Sprite.HeightPercent * heightPercent, 1f);
                Sprite.ElementCollider.transform.localScale = Sprite.ElementSprite.transform.localScale;
            }
        }
    }

    [System.Serializable]
    [ExecuteInEditMode]
    public class GUIObject
    {
        public GameObject ElementCollider;
        public GameObject ElementSprite;
        public float LeftPercent;
        public float TopPercent;
        public float WidthPercent;
        public float HeightPercent;

        public bool ChangeLeft = true;
        public bool ChangeTop = true;
        public bool ChangeWidth = true;
        public bool ChangeHeight = true;
    }
}