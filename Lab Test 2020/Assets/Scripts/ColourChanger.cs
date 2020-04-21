using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    private Renderer r;
    private Color[] colours = new Color[3]; //0 =  green, 1 = yellow, 2 = red
    public static bool green = false, yellow = false, red = false;
    private int rnum;

    private void Awake()
    {
        r = GetComponent<Renderer>();
        colours[0] = new Color(0, 255, 0); //green
        colours[1] = new Color(255, 255, 0); //yellow
        colours[2] = new Color(255, 0, 0); //red
    }

    void Start()
    {
        r.material.color = colours[RandomNumber()]; //randomise the colours

        int colourPicker = RandomNumber();
        if(colourPicker == 0)
        {
            green = true;
            yellow = false;
            red = false;

            StartCoroutine(GreenCoroutine());
        }
            
        if (colourPicker == 1)
        {
            green = false;
            yellow = true;
            red = false;

            StartCoroutine(YellowCoroutine()); StartCoroutine(YellowCoroutine());
        }
            
        if (colourPicker == 2)
        {
            green = false;
            yellow = false;
            red = true;

            StartCoroutine(RedCoroutine());
        }
        yellow = true;
    }

    private int RandomNumber()
    {
        int num = Random.Range(0, 3);
        return num;
    }


    IEnumerator GreenCoroutine()
    {
        r.material.color = colours[0];

        yield return new WaitForSeconds(Random.Range(5, 10));

        green = false;
        yellow = true;
        red = false;
        StartCoroutine(YellowCoroutine());
    }

    IEnumerator YellowCoroutine()
    {
        r.material.color = colours[1];

        yield return new WaitForSeconds(4);

        green = false;
        yellow = false;
        red = true;
        StartCoroutine(RedCoroutine());
    }

    IEnumerator RedCoroutine()
    {
        r.material.color = colours[2];

        yield return new WaitForSeconds(Random.Range(5, 10));

        green = true;
        yellow = false;
        red = false;
        StartCoroutine(GreenCoroutine());
    }
}
