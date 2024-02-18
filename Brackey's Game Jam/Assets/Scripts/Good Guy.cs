using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GoodGuy : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject Pivot;
    [SerializeField] private float DudeSpeed;
    [SerializeField] private float SocialDistance;
    [SerializeField] private Animator animator;
    public float damage;
    public float attackSpeed;
    public float health;
    public float defense;
    float timeUntilAttack;


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
            transform.rotation = Quaternion.Euler(0, 0, -120f + Mathf.Rad2Deg * Mathf.Atan2(NearestEnemy.transform.position.y - transform.position.y, NearestEnemy.transform.position.x - transform.position.x));
            if (distanceToNearest > SocialDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, NearestEnemy.transform.position, DudeSpeed * Time.deltaTime);
            } else if (timeUntilAttack <= 0f) 
            {
                animator.SetTrigger("Attack");
                timeUntilAttack = attackSpeed;
            } else
            {
                timeUntilAttack -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<BadGuy>().Damage(damage);
        }
    }

    public void Damage(float EnemyDamage)
    {
        health -= EnemyDamage - defense;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
