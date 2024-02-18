using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public int health = 0;
    public int defense = 0;
    public int attack = 0;
    public int hitSpeed = 0;

    public TextMeshProUGUI healthCount;
    public TextMeshProUGUI defenseCount;
    public TextMeshProUGUI attackCount;
    public TextMeshProUGUI hitSpeedCount;
    [SerializeField] private GameController GameController;

    public void AddHealth()
    {
        if (GameController.points > 0)
        {
            health++;
            GameController.points--;
            healthCount.text = health.ToString();
        }
    }
    public void AddDefense()
    {
        if (GameController.points > 0)
        {
            defense++;
            GameController.points--;
            defenseCount.text = defense.ToString();
        }
    }
    public void AddAttack()
    {
        if (GameController.points > 0)
        {
            attack++;
            GameController.points--;
            attackCount.text = attack.ToString();
        }
    }
    public void AddHitSpeed()
    {
        if (GameController.points > 0)
        {
            hitSpeed++;
            GameController.points--;
            hitSpeedCount.text = hitSpeed.ToString();
        }
    }
}
