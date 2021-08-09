using UnityEngine;

namespace Assets.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        private void Awake()
        {
            var players = FindObjectsOfType<MusicPlayer>().Length;

            if (players > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
