using UnityEngine;

namespace Assets.Scripts.Game
{
    public class InsectInfo : MonoBehaviour
    {
        public float Speed = 100;
		public byte OnEatScoreAdd = 1;
		public int OnEatSatietyAdd = 1;
		public int OnDestroySatietySub = -1;
		public byte OnDestroyScoreAdd = 0;
		public bool IsBonusInsect = false;

        private void Start()
        {
            FlySound();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        private void FlySound()
        {
            audio.Play();
            audio.loop = true;
        }
    }
}
