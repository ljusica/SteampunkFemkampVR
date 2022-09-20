using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassFunction : MonoBehaviour
{
    public SelectLevel lvl;

    public void PassFunc()
    {
        lvl.StartCoroutine("LoadSceneAsync", lvl.levelObject.GetComponent<LevelName>()?.levelName);
    }
}
