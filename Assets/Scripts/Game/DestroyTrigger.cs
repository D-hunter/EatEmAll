using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class DestroyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var satiety = other.gameObject.GetComponent<InsectInfo>().OnDestroySatietySub;
            ScoreAndSatiety.Satiety += satiety;
            Destroy(other.gameObject);
        }
    }
}
