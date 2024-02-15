using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public GameObject BlueDudePrefab;
    public Sprite OpenDoorSprite;

    [SerializeField] private float DudeCount;
    private bool DoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!DoorOpen)
        {
            for (int i = 0; i < DudeCount; i++) // Spawn little dudes in a circle depending on the amount of dudes
            {
                float x = Mathf.Cos(i * 2 * Mathf.PI / DudeCount);
                float y = Mathf.Sin(i * 2 * Mathf.PI / DudeCount);
                Instantiate(BlueDudePrefab, transform.position + new Vector3(0.1f * x, 0.1f * y, 0), transform.rotation);
            }
            DoorOpen = true;
            GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
        }
    }
}
