using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            foreach (Renderer renderer in _renderers)
            {
                foreach (Material rendererMaterial in renderer.materials)
                {
                    rendererMaterial.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }

            yield return null;
        }
    }
}