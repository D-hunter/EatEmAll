using UnityEngine;

namespace Assets.Scripts.Game
{
    public class InsectInfo : MonoBehaviour
    {
		public float BasicSpeed = 100f;
		public static float SpeedBonus = 1f;
        public float Speed;
		public int BasicOnEatScoreAdd = 1;
		public static int ScoreMultiplier = 1;
		public int OnEatScoreAdd;
		public int OnEatSatietyAdd = 1;
		public int OnDestroySatietySub = -1;
		public byte OnDestroyScoreAdd = 0;
		public bool IsBonusInsect = false;
		
		public static int Controler=1;
		
        private void Start()
        {		
            FlySound();
			Speed = BasicSpeed*SpeedBonus;
			OnDestroySatietySub*=Controler;
			OnEatScoreAdd = BasicOnEatScoreAdd*ScoreMultiplier;
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
