using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerControls : MonoBehaviour
    {
        [Header("General Setup Settings")]

        [Tooltip("How Fast Ship Moves Up and Down based upon player input")]
        [SerializeField] private float controlMovementSpeed = 30f;

        [Tooltip("How far player moves horizontally")] [SerializeField] private float xRange = 12f;
        [Tooltip("How far player moves vertically")] [SerializeField] private float yRange = 7f;

        [Header("Laser Gun Array")]

        [Tooltip("Add all players here.")]
        [SerializeField] private GameObject[] lasers;

        [Header("Screen position based tuning")]
        [SerializeField] private float xRotationFactor = -2f;
        [SerializeField] private float yRotationFactor = 2f;

        [Header("Player position based tuning")]
        [SerializeField] private float controlxRotationFactor = -10f;
        [SerializeField] private float controlRollFactor = -20f;


        private float xAxis;
        private float yAxis;
        void Update()
        {
            ProcessMovement();
            ProcessRotation();
            ProcessFiring();
        }

        private void ProcessMovement()
        {
            xAxis = Input.GetAxis("Horizontal");
            yAxis = Input.GetAxis("Vertical");

            var moveLeftRight = transform.localPosition.x + (xAxis * Time.deltaTime * controlMovementSpeed);
            var constrainMovementX = Mathf.Clamp(moveLeftRight, -xRange, +xRange);

            var moveUpDown = transform.localPosition.y + (yAxis * Time.deltaTime * controlMovementSpeed);
            var constrainMovementY = Mathf.Clamp(moveUpDown, -yRange, +yRange);

            transform.localPosition = new Vector3(constrainMovementX, constrainMovementY, transform.localPosition.z);
        }

        private void ProcessRotation()
        {
            var xRotationPosition = transform.localPosition.y * xRotationFactor;
            var xRotationControl = yAxis * controlxRotationFactor;

            var xRotation = xRotationPosition + xRotationControl;
            var yRotation = transform.localPosition.x * yRotationFactor;
            var zRotation = xAxis * controlRollFactor;


            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }

        private void ProcessFiring()
        {
            SetLasersActive(Input.GetButton("Fire1"));
            
        }

        private void SetLasersActive(bool mouseClick)
        {
            foreach (var laser in lasers)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = mouseClick;
                if (emissionModule.enabled)
                {
                    SetLaserAudioActive(laser);
                }
            }
        }

        private static void SetLaserAudioActive(GameObject laser)
        {
            AudioSource audioSource = laser.GetComponent<AudioSource>();
            AudioClip clip = audioSource.clip;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
