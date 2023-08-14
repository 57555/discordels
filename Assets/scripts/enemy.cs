using UnityEngine;

public class enemy : MonoBehaviour
{


    public float health = 100f;
    public float damageAmount = 40f;
    public float speed = 5f;

    public GameObject theManager;

    public Transform spawnPoint;
    public Transform targetPoint;

    public Transform gfx;
    


    public void Update()
    {
        if(theManager.GetComponent<gameManager>().gameIsRunning)
        {
            gfx.localPosition = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
            {
                theManager.GetComponent<gameManager>().reduceHealth();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void takeHit()
    {
        health = health - damageAmount;
        if(health < 0f )
        {
            Destroy(gameObject);
        }
    }


}
