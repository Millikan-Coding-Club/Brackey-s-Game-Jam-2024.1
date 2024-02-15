using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject Pivot;
    [SerializeField] private float DudeSpeed;
    [SerializeField] private float SocialDistance;

    // Start is called before the first frame update
    private void Awake()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        // Find nearest enemy
        Enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (Enemies.Length != 0)
        {
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
            // Make the good guy chase the closest enemy but not closer than SocialDistance
            Pivot.transform.rotation = Quaternion.Euler(0, 0, -90 + Mathf.Rad2Deg * Mathf.Atan2(NearestEnemy.transform.position.y - Pivot.transform.position.y, NearestEnemy.transform.position.x - Pivot.transform.position.x));
            if (distanceToNearest > SocialDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, NearestEnemy.transform.position, DudeSpeed * Time.deltaTime);
                //transform.position = Vector2.up * DudeSpeed * Time.deltaTime;
            } else
            {
                AttackNearestEnemy();
            }
        }
    }

    private void AttackNearestEnemy()
    {
        
    }
}
