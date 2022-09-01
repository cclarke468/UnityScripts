using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnScreen : MonoBehaviour
{
    public bool onScreen = false;

    private void Awake()
    {
        onScreen = false;
    }
}
