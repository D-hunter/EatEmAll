using UnityEngine;
using System.Collections;
public class PlaySoundtrack : MonoBehaviour {
	void Update () {
		if(Input.GetKeyUp(KeyCode.D))
			PlayPause();
	}
	void PlayPause(){
		if(audio.isPlaying)
			audio.Pause();
		else audio.Play();
	}
}
