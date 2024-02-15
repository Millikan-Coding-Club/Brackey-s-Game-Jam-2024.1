using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public GameObject RedDudePrefab;
    public Sprite OpenDoorSprite;

    [SerializeField] private float DudeCount;
    private bool DoorOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnDudes()
    {
            for (int i = 0; i < DudeCount; i++)
            {
                float x = Mathf.Cos(i * 2 * Mathf.PI / DudeCount);
                float y = Mathf.Sin(i * 2 * Mathf.PI / DudeCount);
                Instantiate(RedDudePrefab, transform.position + new Vector3(0.1f * x, 0.1f * y, 0), transform.rotation);
            }
            DoorOpen = true;
            GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
    }
}
