using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject tLightPrefab; //traffic light gameobject prefab
    private int amountOfLights = 10; 
    public static GameObject[] traficLights; //array of treaffic light
    public static List<GameObject> greenLights; //list of green traffic lights
    

    void Start()
    {
        traficLights = new GameObject[amountOfLights]; //set the size of the traffic light array to the amount of traffic lights

        for(int i = 0; i < amountOfLights; i ++) //loop through all the traffic lights
        {
            GameObject tLightInstance = (GameObject)Instantiate(tLightPrefab); //instanciate the light
            tLightInstance.transform.position = this.transform.position;
            tLightInstance.transform.parent = this.transform; //make the trafic lights children of this gameobject
            tLightInstance.name = "Trafic Light " + (i + 1); //name the lights in order from 1-10
            this.transform.eulerAngles = new Vector3(0, (360 / amountOfLights * -1) * i, 0);//rotate the lights so they can be placed in a circle
            tLightInstance.transform.position = Vector3.forward * 10; //position the lights
            traficLights[i] = tLightInstance; //add the light to the array
        }
    }

    private void Update()
    {
        for (int i = 0; i < traficLights.Length; i++) //loop through all the lights
        {
            if (traficLights[i].GetComponent<ColourChanger>().green == true && !greenLights.Contains(traficLights[i])) //check if the light is green and if it is not in the greenlights list
            {
                greenLights.Add(traficLights[i]); //adding a green light to the list of green lights
            }
        }

        
        if(greenLights.Count >= 1) //if there are any elements in the green light array
        {
            for (int i = 0; i < greenLights.Count; i++) //loop through the green lights list
            {
                if (greenLights[i].GetComponent<ColourChanger>().green == false) //if the light is not green
                {
                    greenLights.Remove(greenLights[i]); //remove the lights that arent green from the greenlights list
                }
            }
        }
    }
}
