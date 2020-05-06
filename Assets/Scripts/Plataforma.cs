using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inf, sup;
    public float veloci;
    int i = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (i == -1) transform.position = (Vector3.MoveTowards(transform.position, inf.transform.position, veloci * Time.fixedDeltaTime));
        if (i == 1) transform.position = (Vector3.MoveTowards(transform.position, sup.transform.position, veloci * Time.fixedDeltaTime));

        if(transform.position == sup.transform.position)
        {
            i = -1;
        }else if(transform.position == inf.transform.position){ i = 1; }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

}
