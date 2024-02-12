using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject RedDoorPrefab;
    public GameObject BlueDoorPrefab;
    public GameObject UnclaimedDoorPrefab;

    private GameObject UnclaimedDoor;

    // Start is called before the first frame update
    void Start()
    {
        UnclaimedDoor = Instantiate(UnclaimedDoorPrefab, transform.position, transform.rotation);
    }
}
