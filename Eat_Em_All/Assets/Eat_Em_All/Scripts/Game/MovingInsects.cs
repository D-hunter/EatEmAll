using UnityEngine;

namespace Assets.Eat_Em_All.Scripts.Game
{
    public class MovingInsects : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Move();
            }
        }

        private void Move()
        {
            transform.Translate(Vector3.forward);
        }
    }
}
