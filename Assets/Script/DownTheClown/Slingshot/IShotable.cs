using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShotable
{
    public void OnRelease();
    public void OnAttach(GameObject obj);
    bool IsShotable();
}
