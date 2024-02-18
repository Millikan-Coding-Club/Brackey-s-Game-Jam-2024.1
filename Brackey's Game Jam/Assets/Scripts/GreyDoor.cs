using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreyDoor : MonoBehaviour
{
    [SerializeField] private GameObject BlueDoorPrefab;
    [SerializeField] private GameObject RedDoorPrefab;
    [SerializeField] private GameController GameController;

    private void OnMouseDown()
    {
        if (GameController.LetPlayerSelectDoor)
        {
            SpawnBlueDoor();
            GameController.LetPlayerSelectDoor = false;
        }
    }
    public void SpawnBlueDoor()
    {
        Instantiate(BlueDoorPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void SpawnRedDoor()
    {
        Instantiate(RedDoorPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
