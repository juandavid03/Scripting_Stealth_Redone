﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementShader : MonoBehaviour
{
    public Shader replacementShader;

    private void OnEnable()
    {
        if (replacementShader != null)
        {
            GetComponent<Camera>().SetReplacementShader(replacementShader, "");

        }
    }

    private void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }

}
