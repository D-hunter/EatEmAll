using UnityEngine;

namespace Assets.Scripts.Game
{
    [ExecuteInEditMode]
    public class ObjSizeCalculator : MonoBehaviour
    {
        public SceneObject SceneObject = new SceneObject();
        public float heightPercent;
        public float widthPercent;

        private void Start()
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
            ChooseSettingsToSet(SceneObject);
        }

        private void ChooseSettingsToSet(SceneObject currentObject)
        {
            if (currentObject.ChangeLeft)
            {
                SceneObject.SceneElement.transform.position = new Vector3(SceneObject.LeftPercent * widthPercent, SceneObject.SceneElement.transform.position.y, SceneObject.SceneElement.transform.position.z);
            }
            if (currentObject.ChangeTop)
            {
                SceneObject.SceneElement.transform.position = new Vector3(SceneObject.SceneElement.transform.position.x, SceneObject.TopPercent * heightPercent, SceneObject.SceneElement.transform.position.z);
            }
            if (currentObject.ChangeWidth)
            {
                SceneObject.SceneElement.transform.localScale = new Vector3(SceneObject.WidthPercent * widthPercent, SceneObject.SceneElement.transform.localScale.y, 1f);
            }
            if (currentObject.ChangeHeight)
            {
                SceneObject.SceneElement.transform.localScale = new Vector3(SceneObject.SceneElement.transform.localScale.x, SceneObject.HeightPercent * heightPercent, 1f);
            }
        }
    }

    [System.Serializable]
    public class SceneObject
    {
        public GameObject SceneElement;
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
