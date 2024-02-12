using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour
{
    public GameObject[] Enemies;
    [SerializeField] private float DudeSpeed;
    [SerializeField] private float SocialDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject NearestEnemy = Enemies[0];
        float distanceToNearest = Vector3.Distance(transform.position, NearestEnemy.transform.position);

        foreach (GameObject e in Enemies)
        {
            float distanceToCurrent = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToCurrent < distanceToNearest)
            {
                NearestEnemy = e;
                distanceToNearest = distanceToCurrent;
            }
        }
        if (distanceToNearest > SocialDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, NearestEnemy.transform.position, DudeSpeed * Time.deltaTime);
        }
            
    }
}
