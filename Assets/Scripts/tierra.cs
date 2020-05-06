using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tierra : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rbd;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator retu() 
    {

        yield return new WaitForSeconds(1f);
        rbd.isKinematic = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {

            StartCoroutine(retu());

        }
    }



}
