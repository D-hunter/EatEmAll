using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
		public class DestroyTrigger : MonoBehaviour
		{
				void OnTriggerEnter (Collider other)
				{
						Destroy (other.gameObject);
						var satiety = other.gameObject.GetComponent<InsectInfo> ().OnDestroySatietySub;
						ScoreAndSatiety.Satiety += satiety;
				}
		}
}
