using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game{
	public class DestroyTrigger : MonoBehaviour {
		void OnTriggerEnter(Collider other){
			Destroy(other.gameObject);
			var score = other.gameObject.GetComponent<InsectInfo>().OnDestroyScoreAdd;
			var satiety = other.gameObject.GetComponent<InsectInfo>().OnDestroySatietySub;
			ScoreAndSatiety.Scores += score;
			ScoreAndSatiety.Satiety += satiety;
		}
	}
}
