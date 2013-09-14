using UnityEngine;

namespace Assets.Scripts.Game
{
    public class MovingInsects : MonoBehaviour
    {
        public float Speed = 100;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
    }
}
