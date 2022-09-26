using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public GameObject ballBoxDropper;
    public bool hasLanded;
    public bool hasScored;

    private float timer = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballBoxDropper = GameObject.FindGameObjectWithTag("BallBoxDropper").gameObject;
    }

    void Update()
    {
        //Distance return
        if (Vector3.Distance(transform.position, ballBoxDropper.transform.position) > 10)
        {
            ReturnToBoxDropper();
        }

        if (hasScored)
        {
            ReturnToBoxDropper();
            hasScored = false;
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
