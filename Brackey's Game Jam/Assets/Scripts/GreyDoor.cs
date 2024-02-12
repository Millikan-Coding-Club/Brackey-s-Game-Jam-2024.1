using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyDoor : MonoBehaviour
{
    public GameObject BlueDoorPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        Instantiate(BlueDoorPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
