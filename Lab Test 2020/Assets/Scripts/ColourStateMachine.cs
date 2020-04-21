using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourStateMachine : MonoBehaviour
{
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    void Update()
    {
        //StartCoroutine(GreenCoroutine());
        //StartCoroutine(YellowCoroutine());
        //StartCoroutine(RedCoroutine());
    }

    IEnumerator GreenCoroutine()
    {
        r.material.color = new Color(0, 255, 0);
        yield return new WaitForSeconds(Random.Range(5, 10));
    }

    IEnumerator YellowCoroutine()
    {
        r.material.color = new Color(255, 255, 0);
        yield return new WaitForSeconds(4);
    }

    IEnumerator RedCoroutine()
    {
        r.material.color = new Color(255, 0 ,0);
        yield return new WaitForSeconds(Random.Range(5, 10));
    }
}
