using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour {
    public float jumpForce;
    public float speed;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
        rb.velocity = new Vector3(speed*Time.deltaTime,rb.velocity.y,rb.velocity.z);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleScript>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
