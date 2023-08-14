using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 50f;
    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if( other.GetComponent<enemy>() != null )
        {
            other.GetComponent<enemy>().takeHit();
        }
        Destroy(gameObject);
    }


}
