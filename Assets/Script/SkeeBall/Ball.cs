using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public GameObject ballBoxDropper;

    private bool hasLanded;
    private float timer = 4f;

    private void Start()
    {
        ballBoxDropper = GameObject.FindGameObjectWithTag("BallBoxDropper").gameObject;
    }

    void Update()
    {
        //Distance return
        if (Vector3.Distance(transform.position, ballBoxDropper.transform.position) > 10)
        {
            ReturnToBoxDropper();
        }

        //Life After Landing
        if (hasLanded)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                ReturnToBoxDropper();
                hasLanded = false;
                timer = 4f;
            }
        }
    }

    public void ReturnToBoxDropper()
    {
        Debug.Log("Dropping ball!");
        rb.velocity = Vector3.zero;
        transform.position = ballBoxDropper.transform.position;
    }

    

}
