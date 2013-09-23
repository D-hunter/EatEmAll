using UnityEngine;

namespace Assets.Scripts.Game
{
    public class PlaySoundtrack : MonoBehaviour
    {

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (Application.loadedLevel == 0)
            {
                Play();
            }

            if (Application.loadedLevel == 1)
            {
                Fade();
            }
        }

        private void Play()
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }

        private void Fade()
        {
            if (audio.isPlaying && audio.volume > 0)
            {
                audio.volume = audio.volume - 0.005f;
            }
            else
            {
                audio.Stop();
            }
        }
    }
}
