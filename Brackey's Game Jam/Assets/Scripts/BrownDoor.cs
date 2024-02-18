using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownDoor : MonoBehaviour
{
    [SerializeField] private GameObject GoodGuyPrefab;
    [SerializeField] private GameObject BadGuyPrefab;
    [SerializeField] private Sprite OpenDoorSprite;
    [SerializeField] private float DudeCount;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        if (transform.position.x < 0)
        {
            for (int i = 0; i < DudeCount; i++) // Spawn little dudes in a circle depending on the amount of dudes
            {
                float x = Mathf.Cos(i * 2 * Mathf.PI / DudeCount);
                float y = Mathf.Sin(i * 2 * Mathf.PI / DudeCount);
                Instantiate(GoodGuyPrefab, transform.position + new Vector3(0.1f * x, 0.1f * y, 0), transform.rotation);
            }
            GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
        }
        else
        {
            for (int i = 0; i < DudeCount; i++) // Spawn little dudes in a circle depending on the amount of dudes
            {
                float x = Mathf.Cos(i * 2 * Mathf.PI / DudeCount);
                float y = Mathf.Sin(i * 2 * Mathf.PI / DudeCount);
                Instantiate(BadGuyPrefab, transform.position + new Vector3(0.1f * x, 0.1f * y, 0), transform.rotation);
            }
            GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
        }
    }
}
