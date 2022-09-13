using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    public float disappearTime;

    bool canReset, disappearing = false;
    public float resetTime;
    float disappearRateX, disappearRateZ;


    // Start is called before the first frame update
    void Start()
    {
        disappearRateX = (transform.localScale.x / disappearTime);
        disappearRateZ = (transform.localScale.z / disappearTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (disappearing && transform.localScale.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x - (disappearRateX * Time.deltaTime), transform.localScale.y, transform.localScale.z - (disappearRateZ * Time.deltaTime));
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            disappearing = true;
        }
    }
}
