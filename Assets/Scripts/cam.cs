using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject refere;
    private Vector3 dis;
    private Vector3 ori_can;
    
    void Start()
    {

        ori_can = transform.position;
        dis = transform.position - player.transform.position;
        Debug.Log("WIII");

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.res_can) 
        {

            Debug.Log("XD");
            dis = ori_can;

        }

        dis = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -2, Vector3.right) * dis;
        transform.position = player.transform.position + dis;
        transform.LookAt(player.transform.position);


        Vector3 rota = new Vector3(0, transform.eulerAngles.y, 0);
        refere.transform.eulerAngles = rota;


    }

    




}
