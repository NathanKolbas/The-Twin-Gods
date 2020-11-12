using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public void Punch(bool facingLeft)
    {
        gameObject.SetActive(true);
        var flipX = facingLeft ? -1 : 1;
        gameObject.transform.localPosition = new Vector3(
            flipX * Math.Abs(gameObject.transform.localPosition.x),
            gameObject.transform.localPosition.y,
            gameObject.transform.localPosition.z
        );
        StartCoroutine(_punch(0.5f));
    }

    private IEnumerator _punch(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
