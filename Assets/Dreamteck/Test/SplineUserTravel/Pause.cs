using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool Enable = true;

    public void Trigger()
    {
        if (!Enable) return;
        Debug.Break();
    }
}
