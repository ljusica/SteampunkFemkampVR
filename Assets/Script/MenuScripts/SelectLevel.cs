using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public Animator animator;
    public GameObject levelObject;
    private AsyncOperation asyncLoad;

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Ball")
        //{
        //    SceneManager.LoadScene(other.gameObject.GetComponent<LevelName>()?.levelName);
        //}

        if(other.gameObject.tag == "Ball")
        {
            levelObject = other.gameObject;
            animator.SetTrigger("FadeOut");
        }
    }

    private IEnumerator LoadSceneAsync(string levelName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(levelName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadScene(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
        animator.SetTrigger("FadeOut");
    }
}
