using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    private Renderer rend;
    private Color[] colours = new Color[3]; //array of colours ----> 0 =  green, 1 = yellow, 2 = red
    public bool green = false; //check if the light is green

    private void Awake()
    {
        rend = GetComponent<Renderer>(); //get a refrence to the renderer
        colours[0] = new Color(0, 255, 0); //green
        colours[1] = new Color(255, 255, 0); //yellow
        colours[2] = new Color(255, 0, 0); //red
    }

    void Start()
    {
        int colourPicker = RandomNumber();
        rend.material.color = colours[colourPicker]; //randomise the first colour
        
        if(colourPicker == 0) //if green
        {
            green = true;
            StartCoroutine(GreenCoroutine()); //start the green colour coroutine 
        }
            
        if (colourPicker == 1) //if yellow
        {
            green = false;
            StartCoroutine(YellowCoroutine()); //start the yellow colour coroutine 
        }
            
        if (colourPicker == 2) //if red
        {
            green = false;
            StartCoroutine(RedCoroutine()); //start the red colour coroutine 
        }
    }

    private int RandomNumber()
    {
        int num = Random.Range(0, 3); //pick a random number
        return num; //return the random number
    }


    IEnumerator GreenCoroutine()
    {
        rend.material.color = colours[0]; //set the colour to green

        yield return new WaitForSeconds(Random.Range(5, 10)); //wait for 5-10 seconds

        green = false;
        StartCoroutine(YellowCoroutine()); //start the yellow Courotine
    }

    IEnumerator YellowCoroutine()
    {
        rend.material.color = colours[1]; //set the colour to yellow

        yield return new WaitForSeconds(4); //wait for 4 seconds

        green = false;
        StartCoroutine(RedCoroutine()); //start the red Coroutine
    }

    IEnumerator RedCoroutine()
    {
        rend.material.color = colours[2]; //set the colour to red

        yield return new WaitForSeconds(Random.Range(5, 10)); //wait foir 5-10 seconds

        green = true;
        StartCoroutine(GreenCoroutine()); //start the green coroutine
    }
}
