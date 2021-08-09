using UnityEngine;

namespace Assets.Scripts
{
    public class Destuct : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy = 3f;
        void Start()
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}
