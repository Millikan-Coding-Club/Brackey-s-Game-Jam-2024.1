using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public int hp = 0;
    public int defense = 0;
    public int attack = 0;
    public int hitSpeed = 0;

    public TextMeshProUGUI healthCount;
    public TextMeshProUGUI defenseCount;
    public TextMeshProUGUI attackCount;
    public TextMeshProUGUI hitSpeedCount;

    // Update is called once per frame
    void Update() { }
    public void AddHealth()
    {
        hp++;
        healthCount.text = hp.ToString();
    }
    public void AddDefense()
    {
        defense++;
        defenseCount.text = defense.ToString();
    }
    public void AddAttack()
    {
        attack++;
        attackCount.text = attack.ToString();
    }
    public void AddHitSpeed()
    {
        hitSpeed++;
        hitSpeedCount.text = hitSpeed.ToString();
    }
}
