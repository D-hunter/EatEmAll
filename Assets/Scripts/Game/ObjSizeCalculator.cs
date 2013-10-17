using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ObjSizeCalculator : MonoBehaviour
    {
//        public GameObject[] SpawnPoints;
//        public GameObject
        public float heightPercent;
        public float widthPercent;
        

        void Start()
        {
            

        }

        void Update()
        {
            CalculatePercents();
        }

        public void CalculatePercents()
        {
            heightPercent = Screen.height * 0.01f;
            widthPercent = Screen.width * 0.01f;
//            Debug.Log("Height percent = " + heightPercent + " total height = " + Screen.height);
//            Debug.Log("Width percent = " + widthPercent + " total width = " + Screen.width);
        }
    }
}
