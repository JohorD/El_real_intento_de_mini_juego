using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugad, ball, canon;
    public float velo_bala;
    public float lim;
    Vector3 direci;

    void Start()
    {
        InvokeRepeating("Hola", 2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        direci = (jugad.transform.position - transform.position);

        if(direci.magnitude <= lim) 
        {
            transform.forward = direci.normalized;
        }

    }



    void Hola() 
    {
        
        if(direci.magnitude <= lim) 
        {

            GameObject ball_u = Instantiate(ball, canon.transform.position, Quaternion.identity);

            ball_u.transform.up = direci.normalized;
            ball_u.GetComponent<Rigidbody>().velocity = direci.normalized * velo_bala;

          
            Destroy(ball_u, 0.5f);
        
        }
        
    }

    
}
