using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Ball")
        //{
        //    SceneManager.LoadScene(other.gameObject.GetComponent<LevelName>()?.levelName);
        //}

        if(other.gameObject.tag == "Ball")
        {
            StartCoroutine("LoadSceneAsync", other.gameObject.GetComponent<LevelName>()?.levelName);
        }
    }

    private IEnumerator LoadSceneAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
