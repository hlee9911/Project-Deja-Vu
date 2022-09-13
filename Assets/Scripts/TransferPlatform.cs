using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPlatform : MonoBehaviour
{

    public float speed;


    public Transform startPoint, endPoint;


    public float changeDirectionDelay;

    [SerializeField] bool move_on_input = false;

    private Transform destinationTarget, departTarget;
    private float journeyLength;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!move_on_input)
            timer += Time.fixedDeltaTime;
        else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            timer += Time.fixedDeltaTime;
        Move();
    }

    void Move() {
        if ((Vector3.Distance(transform.position, destinationTarget.position)) > .01f) {
                float distCovered = timer * speed;
                float fractOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractOfJourney);
        }
        else {
            changeDestination();
        }
    }

    void changeDestination() {
        timer = 0.0f;
        if (departTarget == endPoint && destinationTarget == startPoint) {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.transform.parent = null;
        }
    }
}
