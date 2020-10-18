using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public void AttackingHandler()
    {
        gameObject.SetActive(true);
        StartCoroutine(_punch(0.5f));
    }

    private IEnumerator _punch(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
