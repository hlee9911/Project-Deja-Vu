using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagement : MonoBehaviour
{
    public AudioClip keyCollect;
    public GameObject doorRemove;
    Vector3 initPosition;
    public float amplitude;
    public float speed = 1;

    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        transform.position = initPosition + new Vector3(0, amplitude * Mathf.Sin(Time.time * speed), 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(keyCollect, Camera.main.transform.position);
            gameObject.SetActive(false);
            doorRemove.SetActive(false);
        }
    }
}
