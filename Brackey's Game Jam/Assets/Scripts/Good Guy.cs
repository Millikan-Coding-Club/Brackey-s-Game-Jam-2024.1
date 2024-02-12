using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float dudeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, dudeSpeed * Time.deltaTime);
    }
}
