using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float loadDelayTime = 1f;
        [SerializeField] private ParticleSystem bigExplosionEffect;
        [SerializeField] private Collider[] customColliders;

       
        private AudioSource shipAudioSource;
        private void OnTriggerEnter(Collider other)
        {
            StartCrashSequence();
        }

        private void StartCrashSequence()
        {
            GetComponent<MeshRenderer>().enabled = false;
            PlayExplosion();
            StopShipSound();
            DisableCustomColliders();
            GetComponent<PlayerControls>().enabled = false;
            Invoke("ReloadLevel", loadDelayTime);
        }

        private void PlayExplosion()
        {
            bigExplosionEffect.Play();
            var audioSource = bigExplosionEffect.GetComponent<AudioSource>();
            audioSource.Play();
        }

        private void DisableCustomColliders()
        {
            foreach (var col in customColliders)
            {
                col.enabled = false;
            }
        }

        public void StopShipSound()
        {
            shipAudioSource = GetComponent<AudioSource>();
            shipAudioSource.Stop();
        }

        private void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
