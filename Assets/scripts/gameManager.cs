using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject gameOverPnl;
    public GameObject gameWonPnl;
    public GameObject startPnl;
    public int health = 10;
    public int winTime = 30;
    public Transform targetPoint;
    public GameObject thePlayer;
    public Text timeTxt;
    public Text healthTxt;


    private float spawnMin = -8f;
    private float spawnMax = -4f;
    private float targetMin = 26f;
    private float targetMax = 3f;


    public bool gameIsRunning = false;
    public bool startMode = true;

    private int spentTime = 0;




    private void Start()
    {
        startPnl.SetActive(true);
    }

    public void startBtn()
    {
        startMode = false;
        startPnl.SetActive(false);
        gameIsRunning = true;
        StartCoroutine(run());
    }

    private void Update()
    {
        if( !gameIsRunning && Input.GetKeyDown(KeyCode.Space))
        {
            if( startMode)
            {
                startBtn();
            }
            else
            {
                restart();
                health = 10;
            }
        }
    }

    IEnumerator run()
    {
        while(true)
        {
            if (gameIsRunning)
            {
                timeTxt.text = (winTime - spentTime).ToString();
                healthTxt.text = health.ToString();
                spawnEnemy();
                spentTime++;
                if (spentTime > winTime)
                {
                    gameIsRunning = false;
                    gameWonPnl.SetActive(true);
                }
            }
            else
            {
                spentTime = 0;
            }
            yield return new WaitForSeconds(1);
        }
    }


    private void spawnEnemy()
    {
        Vector3 pos = new Vector3 ( Random.Range(spawnMin, spawnMax), 0f, targetMin);
        if( Random.Range(0f, 1f) < 0.5f )
        {
            GameObject go = Instantiate(enemyPrefab, pos, transform.rotation);
            go.GetComponent<enemy>().theManager = gameObject;
            go.GetComponent<enemy>().targetPoint = targetPoint;
        }
        else
        {
            GameObject go = Instantiate(enemyPrefab2, pos, transform.rotation);
            go.GetComponent<enemy>().theManager = gameObject;
            go.GetComponent<enemy>().targetPoint = targetPoint;
        }
        
    }


    public void reduceHealth()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            gameIsRunning = false;
            gameOverPnl.SetActive(true);
        }
    }



    public void restart()
    {
        gameIsRunning = true;
        gameOverPnl.SetActive(false);
        gameWonPnl.SetActive(false);
    }


}
