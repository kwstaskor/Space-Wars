using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject plasmaExplosionEffect;
        [SerializeField] private GameObject hitEffect;
       

        [Tooltip("How many score points per hit")][SerializeField] private int scorePerHit = 15;
        [Tooltip("How Many Hits must receive , to die")] [SerializeField] private int enemyHitPoints = 4;

        private ScoreBoard scoreBoard;
        private GameObject parentGameObject;
        void Start()
        {
            scoreBoard = FindObjectOfType<ScoreBoard>();
            parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
            this.gameObject.AddComponent<Rigidbody>().useGravity=false;
        }

        private void OnParticleCollision(GameObject other)
        {
            HittingEnemy();
            
            if (enemyHitPoints < 1)
            {
                ProcessingScore();
                KillingEnemy();
            }
        }

        private void ProcessingScore()
        {
            scoreBoard.IncreaseScore(scorePerHit);
        }

        private void HittingEnemy()
        {
            enemyHitPoints--;
            GameObject effect = Instantiate(hitEffect, this.transform.position, Quaternion.identity);
            effect.transform.parent = parentGameObject.transform;
        }
        
        private void KillingEnemy()
        {
            GameObject effect = Instantiate(plasmaExplosionEffect, this.transform.position, Quaternion.identity);
            effect.transform.parent = parentGameObject.transform;
            Destroy(this.gameObject);
        }
    }
}
