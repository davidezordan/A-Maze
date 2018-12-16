using System;
using UnityEngine;

public class StaticCheck : MonoBehaviour {
    void Start ()
    {
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (!obj.isStatic)
            {
                Debug.Log(String.Format("Not static: {0}", obj.name));
            }
        }
    }
}