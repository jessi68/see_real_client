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
            openPosition = transform.position + new Vector3(0, 0, 1);
        } else {
            openPosition = transform.position - new Vector3(0, 0, 1);
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
            if (position.z < openPosition.z) {
                position.z += 1 * Time.deltaTime;
            }
        }
        if (!isLeftDoor) {
            if (position.z > openPosition.z) {
                position.z -= 1 * Time.deltaTime;
            }
        }
        transform.position = position;
    }

    public void closeDoor() {
        if (isLeftDoor) {
            if (position.z > closedPosition.z) {
                position.z += (-1) * Time.deltaTime;
            }
        }
        if (!isLeftDoor) {
            if (position.z < closedPosition.z) {
                position.z -= (-1) * Time.deltaTime;
            }
        }
        transform.position = position;
    }
}
