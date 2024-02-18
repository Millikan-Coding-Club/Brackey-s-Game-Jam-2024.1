using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject[] UnclaimedDoors;
    [SerializeField] private Sprite OpenDoorSprite;
    [SerializeField] private Sprite CloseRedDoorSprite;
    [SerializeField] private Sprite ClosedBlueDoorSprite;
    [SerializeField] private GameObject StartButtonCanvas;
    [SerializeField] private TextMeshProUGUI StartButtonText;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private Stats Stats;
    [SerializeField] private GameObject GoodGuy;
    [SerializeField] private GameObject BadGuy;
    private GoodGuy GoodGuyScript;
    private BadGuy BadGuyScript;

    private bool EndWaves = true;
    public bool LetPlayerSelectDoor = false;
    public bool LetPlayerChangeStats = false;
    private int wave = 2;
    public int points = 0;
    private int allyPopulation;
    private int enemyPopulation;

    private void Start()
    {
        GoodGuyScript = GoodGuy.GetComponent<GoodGuy>();
        BadGuyScript = BadGuy.GetComponent<BadGuy>();
    }

    // Update is called once per frame
    void Update()
    {
        allyPopulation = GameObject.FindGameObjectsWithTag("ally").Length;
        enemyPopulation = GameObject.FindGameObjectsWithTag("enemy").Length;

        if (EndWaves && (enemyPopulation == 0 || allyPopulation == 0))
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        points += 1 + enemyPopulation;

        foreach (GameObject d in GameObject.FindGameObjectsWithTag("Red Door"))
        {
            d.GetComponent<SpriteRenderer>().sprite = CloseRedDoorSprite;
        }
        foreach (GameObject d in GameObject.FindGameObjectsWithTag("Blue Door"))
        {
            d.GetComponent<SpriteRenderer>().sprite = ClosedBlueDoorSprite;
        }
        EndWaves = false;
        if (wave < 8)
        {
            StartButtonText.text = "Start Wave " + wave;
            StartButtonCanvas.SetActive(true);
            UnclaimedDoors = GameObject.FindGameObjectsWithTag("Unclaimed Door");
            UnclaimedDoors[Random.Range(0, UnclaimedDoors.Length)].GetComponent<GreyDoor>().SpawnRedDoor();
            LetPlayerSelectDoor = true;
            wave++;
        } else
        {
            if (enemyPopulation == 0)
            {
                GameOverText.text = "You won!\nCongratulations! :)";
            } else
            {
                GameOverText.text = "Game over!\nYou lost :(";
            }
            GameOverCanvas.SetActive(true);
        }
        
    }

    public void StartWave()
    {
        if (!LetPlayerSelectDoor)
        {
            StartButtonCanvas.SetActive(false);

            GoodGuyScript.health = 100 + Stats.health * 10;
            GoodGuyScript.defense = Stats.defense;
            GoodGuyScript.damage = 50 + Stats.attack * 10;
            GoodGuyScript.attackSpeed = 1 - Stats.hitSpeed / 10;
            /* 
             * Spawn dudes in every claimed door
            foreach (GameObject d in GameObject.FindGameObjectsWithTag("Red Door"))
            {
                d.GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
                d.GetComponent<RedDoor>().SpawnDudes();
            }
            foreach (GameObject d in GameObject.FindGameObjectsWithTag("Blue Door"))
            {
                d.GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
                d.GetComponent<BlueDoor>().SpawnDudes();
            }
            */
            // Spawn dudes in the last selected door
            GameObject.FindGameObjectsWithTag("Red Door")[GameObject.FindGameObjectsWithTag("Red Door").Length -1].GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
            GameObject.FindGameObjectsWithTag("Red Door")[GameObject.FindGameObjectsWithTag("Red Door").Length -1].GetComponent<RedDoor>().SpawnDudes();
            GameObject.FindGameObjectsWithTag("Blue Door")[GameObject.FindGameObjectsWithTag("Blue Door").Length -1].GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
            GameObject.FindGameObjectsWithTag("Blue Door")[GameObject.FindGameObjectsWithTag("Blue Door").Length -1].GetComponent<BlueDoor>().SpawnDudes();
            EndWaves = true;
        }
    }
}
