using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public bool isgameover = false;
    void Start()
    {
        if (instance == null)
            instance = this;
        else if(instance != null)
            Destroy(instance);
    }

}
