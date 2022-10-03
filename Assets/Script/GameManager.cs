using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isDoingPenthathlonRun;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool pentathlonUnlocked()
    {
        return
            SaveManager.Instance.hasPlayedBloodlust &&
            SaveManager.Instance.hasPlayedSkullHunt &&
            SaveManager.Instance.hasPlayedTeddyKnockdown &&
            SaveManager.Instance.hasPlayedClubTheCub &&
            SaveManager.Instance.hasPlayedEyeBall;
    }

    public IEnumerator GoToNextGameInPenthathlon()
    {
        yield return new WaitForSecondsRealtime(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
