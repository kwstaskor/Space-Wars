using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneManagment : MonoBehaviour
    {
        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }


        public void LoadFirstScene()
        {
            SceneManager.LoadScene(1);
        }


        //public void Test()
        //{
        //    string me = "GEIA";
        //    StartCoroutine(SendScore(me));
        //}

        //public static IEnumerator SendScore(string score)
        //{
        //    string json = JsonUtility.ToJson(score);

        //    using (UnityWebRequest request = UnityWebRequest.Post("https://localhost:44369/account/PostScoreTest" , score))
        //    {
        //        request.SetRequestHeader("Content-Type", "application/json");
        //        yield return request.SendWebRequest();

        //        if (request.isHttpError || request.isNetworkError)
        //        {
        //            Debug.LogError("Error on sending the score: " + request.error);
        //        }
        //        else
        //        {
        //            Debug.Log("Sent score, possible answer: " + request.downloadHandler.text);
        //        }
        //    }
        //}

    }
}
