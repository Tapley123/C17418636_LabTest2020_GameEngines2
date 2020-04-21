using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject tLightPrefab;
    private int amountOfLights = 10;
    private GameObject[] traficLights;
    

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
}
