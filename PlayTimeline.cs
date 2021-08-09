using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTimeline : MonoBehaviour
{
    void OnEnable()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
