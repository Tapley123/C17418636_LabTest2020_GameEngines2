using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    private Renderer r;
    private Color[] colours = new Color[3]; //0 =  green, 1 = yellow, 2 = red

    private void Awake()
    {
        r = GetComponent<Renderer>();
        colours[0] = new Color(0, 255, 0); //green
        colours[1] = new Color(255, 255, 0); //yellow
        colours[2] = new Color(255, 0, 0); //red
    }

    void Start()
    {
        r.material.color = colours[Random.Range(0, 3)];
    }

    void Update()
    {
        //StartCoroutine(GreenCoroutine());
        //StartCoroutine(YellowCoroutine());
        //StartCoroutine(RedCoroutine());
    }

    IEnumerator GreenCoroutine()
    {
        r.material.color = colours[0];
        yield return new WaitForSeconds(Random.Range(5, 10));
    }

    IEnumerator YellowCoroutine()
    {
        r.material.color = colours[1];
        yield return new WaitForSeconds(4);
    }

    IEnumerator RedCoroutine()
    {
        r.material.color = colours[2];
        yield return new WaitForSeconds(Random.Range(5, 10));
    }
}
