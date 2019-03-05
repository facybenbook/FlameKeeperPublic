﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class ExampleAnim : MonoBehaviour
{
    public CinemachineVirtualCamera vc;
    public float blendWait;
    public float actionWait;
    public UnityEvent method;
    public string methodComponent;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void PlayExample()
    {
        StartCoroutine(ShowExample());
    }

    IEnumerator ShowExample()
    {
        ActivatableObject[] scriptComponents = this.GetComponents<ActivatableObject>();

        vc.Priority += 100;
        yield return new WaitForSeconds(blendWait);
        foreach (ActivatableObject comp in scriptComponents)
        {
            comp.enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        method.Invoke();
        yield return new WaitForSeconds(actionWait);
        vc.Priority -= 100;
        yield return new WaitForSeconds(blendWait);
    }
}
