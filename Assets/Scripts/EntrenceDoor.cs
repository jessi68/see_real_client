using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrenceDoor : MonoBehaviour
{
    [SerializeField]
    private bool isLeftDoor;
    
    private Vector3 position;
    private Vector3 closedPosition;
    private Vector3 openPosition;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        closedPosition = transform.position;
        if(isLeftDoor) {
            openPosition = transform.position + new Vector3(1, 0, 0);
        } else {
            openPosition = transform.position - new Vector3(1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }

    public void openDoor()
    {
        if (isLeftDoor) {
            if (position.x < openPosition.x) {
                position.x += 1 * Time.deltaTime;
            }
        }
        if (!isLeftDoor) {
            if (position.x > openPosition.x) {
                position.x -= 1 * Time.deltaTime;
            }
        }
        transform.position = position;
    }

    public void closeDoor() {
        if (isLeftDoor) {
            if (position.x > closedPosition.x) {
                position.x += (-1) * Time.deltaTime;
            }
        }
        if (!isLeftDoor) {
            if (position.x < closedPosition.x) {
                position.x -= (-1) * Time.deltaTime;
            }
        }
        transform.position = position;
    }
}
