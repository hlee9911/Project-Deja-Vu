using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    //public float alternatingSpeed = 1f;
    //public float lightThreshold = 0.5f;
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Mathf.Cos(Time.deltaTime * alternatingSpeed) < lightThreshold)
        {
            lights.SetActive(true);
        }

        if (Mathf.Cos(Time.deltaTime * alternatingSpeed) > lightThreshold)
        {
            lights.SetActive(false);
        }
        */

        lights.SetActive( ((Mathf.Floor(Time.time)) % 2) == 1);

    }
}
