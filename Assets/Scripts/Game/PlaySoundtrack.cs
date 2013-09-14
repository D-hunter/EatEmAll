using UnityEngine;

namespace Assets.Scripts.Game
{
    public class PlaySoundtrack : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                PlayPause();
            }
        }

        private void PlayPause()
        {
            if (audio.isPlaying)
            {
                audio.Pause();
            }
            else
            {
                audio.Play();
            }
        }
    }
}
