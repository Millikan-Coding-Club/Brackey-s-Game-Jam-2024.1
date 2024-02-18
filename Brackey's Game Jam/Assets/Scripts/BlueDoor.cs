using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public GameObject BlueDudePrefab;
    public Sprite OpenDoorSprite;

    [SerializeField] private float DudeCount;

    public void SpawnDudes()
    {
        for (int i = 0; i < DudeCount; i++) // Spawn little dudes in a circle depending on the amount of dudes
        {
            float x = Mathf.Cos(i * 2 * Mathf.PI / DudeCount);
            float y = Mathf.Sin(i * 2 * Mathf.PI / DudeCount);
            Instantiate(BlueDudePrefab, transform.position + new Vector3(0.1f * x, 0.1f * y, 0), transform.rotation);
        }
        GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
    }
}
