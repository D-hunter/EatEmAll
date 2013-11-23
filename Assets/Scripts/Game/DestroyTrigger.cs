using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class DestroyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var satiety = other.gameObject.GetComponent<InsectInfo>().OnDestroySatietySub;
            ScoreAndSatiety.Satiety += satiety;
            Destroy(other.gameObject);
        }
    }
}
