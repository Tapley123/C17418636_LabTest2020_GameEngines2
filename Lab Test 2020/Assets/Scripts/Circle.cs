using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject tLightPrefab;
    private int amountOfLights = 10;
    public static GameObject[] traficLights;
    public List<GameObject> greenLights;
    

    void Start()
    {
        traficLights = new GameObject[amountOfLights];

        for(int i = 0; i < amountOfLights; i ++)
        {
            GameObject tLightInstance = (GameObject)Instantiate(tLightPrefab);
            tLightInstance.transform.position = this.transform.position;
            tLightInstance.transform.parent = this.transform; //make the trafic lights children of this gameobject
            tLightInstance.name = "Trafic Light " + (i + 1);
            this.transform.eulerAngles = new Vector3(0, (360 / amountOfLights * -1) * i, 0);
            tLightInstance.transform.position = Vector3.forward * 10;
            traficLights[i] = tLightInstance;
        }
    }

    private void Update()
    {
        for (int i = 0; i < traficLights.Length; i++)
        {
            if (traficLights[i].GetComponent<ColourChanger>().green == true && !greenLights.Contains(traficLights[i]))
            {
                greenLights.Add(traficLights[i]);
            }

        }

        
        if(greenLights.Count >= 1)
        {
            for (int i = 0; i < greenLights.Count; i++)
            {
                if (greenLights[i].GetComponent<ColourChanger>().green == false)
                {
                    greenLights.Remove(greenLights[i]);
                }
            }
        }
    }
}
