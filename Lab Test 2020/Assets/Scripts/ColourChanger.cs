using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    /// <summary>
    /// ///////////////only have the green bool*(**********
    /// </summary>

    private Renderer r;
    private Color[] colours = new Color[3]; //0 =  green, 1 = yellow, 2 = red
    public bool green = false;
    private int rnum;
    private Circle circle;
    GameObject go;

    private void Awake()
    {
        circle = GetComponentInParent<Circle>();
        r = GetComponent<Renderer>();
        colours[0] = new Color(0, 255, 0); //green
        colours[1] = new Color(255, 255, 0); //yellow
        colours[2] = new Color(255, 0, 0); //red
        go = GetComponent<GameObject>();
    }

    void Start()
    {
        r.material.color = colours[RandomNumber()]; //randomise the colours

        int colourPicker = RandomNumber();
        if(colourPicker == 0)
        {
            green = true;
            StartCoroutine(GreenCoroutine());
        }
            
        if (colourPicker == 1)
        {
            green = false;
            StartCoroutine(YellowCoroutine()); StartCoroutine(YellowCoroutine());
        }
            
        if (colourPicker == 2)
        {
            green = false;
            StartCoroutine(RedCoroutine());
        }
    }

    private int RandomNumber()
    {
        int num = Random.Range(0, 3);
        return num;
    }


    IEnumerator GreenCoroutine()
    {
        r.material.color = colours[0];
        //circle.greenLights.Add(go);

        yield return new WaitForSeconds(Random.Range(5, 10));

        //circle.greenLights.Remove(go);
        green = false;
        StartCoroutine(YellowCoroutine());
    }

    IEnumerator YellowCoroutine()
    {
        r.material.color = colours[1];

        yield return new WaitForSeconds(4);

        green = false;
        StartCoroutine(RedCoroutine());
    }

    IEnumerator RedCoroutine()
    {
        r.material.color = colours[2];

        yield return new WaitForSeconds(Random.Range(5, 10));

        green = true;
        StartCoroutine(GreenCoroutine());
    }
}
