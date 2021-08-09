using UnityEngine;

namespace Assets.Scripts
{
    public class ShipAudio : MonoBehaviour
    {
        private AudioClip shipAudioClip;

        private AudioSource audioSource;


        private void Start()
        {
            PlayShipSound();
        }
        private void PlayShipSound()
        {
            audioSource = GetComponent<AudioSource>();
            shipAudioClip = GetComponent<AudioClip>();
            audioSource.Play();
        }
    }
}
