using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public GameObject BlueDudePrefab;

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
            Instantiate(BlueDudePrefab, transform.position, transform.rotation);
        }
    }
}
