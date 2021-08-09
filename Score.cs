using UnityEngine;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        public void DontDestroyScoreOnLevelChange()
        {
            var score = FindObjectsOfType<Score>().Length;

            if (score > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
