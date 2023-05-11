using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private Vector3 position;
    private Vector3 closedPosition;
    private Vector3 openPosition;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        closedPosition = transform.position;
        openPosition = transform.position + new Vector3(0, 0, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }

    public void openDoor()
    {
        if (position.z < openPosition.z) {
            position.z += 1 * Time.deltaTime;
        }
        transform.position = position;
    }

    public void closeDoor() {
        if (position.z > closedPosition.z) {
            position.z += (-1) * Time.deltaTime;
        }
    
        transform.position = position;
    }
}
