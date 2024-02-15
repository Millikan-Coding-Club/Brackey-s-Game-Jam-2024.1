using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    public GameObject[] Allies;
    [SerializeField] private float DudeSpeed = 1f;
    [SerializeField] private float SocialDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Allies = GameObject.FindGameObjectsWithTag("ally");
        if (Allies.Length != 0)
        {
            GameObject NearestAlly = Allies[0];
            float distanceToNearest = Vector3.Distance(transform.position, NearestAlly.transform.position);

            foreach (GameObject e in Allies)
            {
                float distanceToCurrent = Vector3.Distance(transform.position, e.transform.position);
                if (distanceToCurrent < distanceToNearest)
                {
                    NearestAlly = e;
                    distanceToNearest = distanceToCurrent;
                }
            }
            if (distanceToNearest > SocialDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, NearestAlly.transform.position, DudeSpeed * Time.deltaTime);
            }
        }
    }
}
