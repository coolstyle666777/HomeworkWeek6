using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        _damage.enabled = true;
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            _damage.color = new Color(1, 0, 0, t);
            yield return null;
        }

        _damage.enabled = false;
    }
}