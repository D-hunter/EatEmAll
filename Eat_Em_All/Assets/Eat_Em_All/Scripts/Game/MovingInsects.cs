using UnityEngine;

namespace Assets.Eat_Em_All.Scripts.Game
{
    public class MovingInsects : MonoBehaviour
    {
        public GameObject[] StartFromArr = new GameObject[1];
        public GameObject[] EndToArr = new GameObject[1];
        public GameObject[] MovingObjectsArr = new GameObject[1];
        public float speed = 1;
        private Vector3[] _moveToCoords;

        private void Start()
        {
            _moveToCoords = getEndCordinates(StartFromArr);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Move();
            }
        }

        private Vector3[] getEndCordinates(GameObject[] endObjects)
        {
            Vector3[] coords = new Vector3[endObjects.Length];

            for (byte i = 0; i < coords.Length; i++)
            {
                coords[i] = endObjects[i].transform.position;
            }

            return coords;
        }

        private void Move()
        {
            for (byte i = 0; i < _moveToCoords.Length; i++)
            {
                MovingObjectsArr[i].transform.position = new Vector3(_moveToCoords[i].x*Time.deltaTime*speed,
                    _moveToCoords[i].y*Time.deltaTime*speed, MovingObjectsArr[i].transform.position.z);
            }
        }
    }
}
