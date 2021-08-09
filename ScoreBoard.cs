using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreBoard : MonoBehaviour
    {
        private int score;
        private TMP_Text scoreText;

        void Start()
        {
            scoreText = GetComponent<TMP_Text>();
            scoreText.text = score.ToString();
        }

        public void IncreaseScore(int amountToIncrease)
        {
            score += amountToIncrease;
            scoreText.text = score.ToString();
        }
    }
}
