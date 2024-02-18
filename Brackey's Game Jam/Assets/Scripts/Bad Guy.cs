using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BadGuy : MonoBehaviour
{
    public GameObject[] Allies;
    public GameObject Pivot;
    [SerializeField] private float DudeSpeed;
    [SerializeField] private float SocialDistance;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float health;
    float timeUntilAttack;


    // Update is called once per frame
    void Update()
    {
        // Find nearest ally
        Allies = GameObject.FindGameObjectsWithTag("ally");
        if (Allies.Length != 0)
        {
            GameObject NearestAlly = Allies[0];
            float distanceToNearest = Vector3.Distance(transform.position, NearestAlly.transform.position);

            foreach (GameObject a in Allies)
            {
                float distanceToCurrent = Vector3.Distance(transform.position, a.transform.position);
                if (distanceToCurrent < distanceToNearest)
                {
                    NearestAlly = a;
                    distanceToNearest = distanceToCurrent;
                }
            }
            // Make the bad guy chase the closest ally but not closer than SocialDistance
            transform.rotation = Quaternion.Euler(0, 0, -120f + Mathf.Rad2Deg * Mathf.Atan2(NearestAlly.transform.position.y - transform.position.y, NearestAlly.transform.position.x - transform.position.x));
            if (distanceToNearest > SocialDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, NearestAlly.transform.position, DudeSpeed * Time.deltaTime);
            }
            else if (timeUntilAttack <= 0f)
            {
                animator.SetTrigger("Attack");
                timeUntilAttack = attackSpeed;
            }
            else
            {
                timeUntilAttack -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ally")
        {
            collision.GetComponent<GoodGuy>().Damage(damage);
        }
    }

    public void Damage(float AllyDamage)
    {
        health -= AllyDamage;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
