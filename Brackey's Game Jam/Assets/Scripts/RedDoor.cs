using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public GameObject RedDudePrefab;

    [SerializeField] private float DudeCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        for (int i = 0; i < DudeCount; i++)
        {
            Instantiate(RedDudePrefab, transform.position, transform.rotation);
        }
    }
}
