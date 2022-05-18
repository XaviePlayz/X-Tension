using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    private Animator anim;
    public float timeDelay;

    public void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(MovingObjet());
    }

    IEnumerator MovingObjet()
    {
        timeDelay = Random.Range(25f, 30f);
        yield return new WaitForSeconds(timeDelay);
        anim.SetBool("isMoving", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isFinished", true);
    }
}
