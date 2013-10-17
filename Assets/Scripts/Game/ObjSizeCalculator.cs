using UnityEngine;

namespace Assets.Scripts.Game
{
    [ExecuteInEditMode]
    public class ObjSizeCalculator : MonoBehaviour
    {
        public SceneObject[] SceneObjects = new SceneObject[1];
        public float heightPercent;
        public float widthPercent;

        void Start()
        {
            CalibrateSizeAndPosition();
            
        }

        void Update()
        {
            CalculatePercents();
        }

        private void CalculatePercents()
        {
            heightPercent = Screen.height * 0.01f;
            widthPercent = Screen.width * 0.01f;
        }

        private void CalibrateSizeAndPosition()
        {
            for (int i = 0; i < SceneObjects.Length; i++)
            {
                SceneObjects[i].SceneElement.transform.position = new Vector3(SceneObjects[i].LeftPercent * widthPercent, SceneObjects[i].TopPercent * heightPercent);
                SceneObjects[i].SceneElement.transform.localScale = new Vector3(SceneObjects[i].WidthPercent * widthPercent, SceneObjects[i].HeightPercent * heightPercent, 1f);
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
    }
}
