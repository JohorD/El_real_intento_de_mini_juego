using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arriba : MonoBehaviour
{
    // Start is called before the first frame update
    public bool stay;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (stay)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f * Time.deltaTime, transform.position.z);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.rigidbody.isKinematic = false;
            collision.transform.parent = transform;
            stay = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
            stay = false;
            
        }
    }


}