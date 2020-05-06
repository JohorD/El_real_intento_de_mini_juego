using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rbd;
    Transform tran;
    public float velo, jump;
    private float x, z;
    private Vector3 Inpu;
    private Vector3 impul;
    int i;
    Vector3 ngra = Physics.gravity;
    public float esca;

    public int points = 0;
    public GameObject refere;
    public static bool res_can;
    public float salud = 100f;

    public int mecura = 2;
    public int meduele = 2;
    public bool ace_p = false;
    private Vector3 dir_ace;
    public bool desaparece = false;
    public Text puntaje;
    public Text salud_text;
    public int salud_valor;
    public Text meta_var;
    public bool meta_bool = false;
    public int intentos_valor = 1;
    public Text intentos_var;
    public Text ga_var;


    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tran = GetComponent<Transform>();

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Inpu = new Vector3(x, 0, z);
        Inpu = Vector3.ClampMagnitude(Inpu, 1);
        //ori = new Vector3(Inpu.z, 0, -Inpu.x);

        //rbd.velocity = new Vector3(Inpu.x * velo, rbd.velocity.y, Inpu.z * velo);
        rbd.velocity = Inpu.x * refere.transform.right * velo + Inpu.z * refere.transform.forward * velo + refere.transform.up*rbd.velocity.y;
        //rbd.velocity = (Inpu.x + rbd.velocity.x / velo) * refere.transform.right * velo + (Inpu.z +rbd.velocity.y / velo) * refere.transform.forward * velo + refere.transform.up * rbd.velocity.y;


        if (rbd.velocity.magnitude <= 0.001)
        {
            rbd.velocity = new Vector3();
        }

        //tran.LookAt(new Vector3(tran.position.x + Inpu.z,tran.position.y + 0, tran.position.z -Inpu.x));
        tran.LookAt(new Vector3(tran.position.x + rbd.velocity.z, tran.position.y + 0, tran.position.z - rbd.velocity.x));


        //Debug.Log(rbd.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(rbd.velocity.y == 0)
            {
                i = 0;
            }
            i++;
            if(i <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * jump / Time.fixedDeltaTime);
            }

        }


        //Debug.Log(1000*Time.deltaTime);

        if(mecura == 1) 
        {
            if(salud <= 100) 
            {
                salud += 2*Time.deltaTime;
            }
        }

        if (meduele == 1)
        {
            salud -= 2*Time.deltaTime;
        }


        if (salud <= 0) 
        {

            salud = 100f;
            tran.position = new Vector3(1, 1.6f, 1);
            rbd.velocity = new Vector3();
            tran.right = new Vector3(0, 0, -1);
            res_can = true;
            intentos_valor += 1;

        }

        if(salud >= 100) 
        {
            salud = 100f;
        }


        if (ace_p) 
        {

            rbd.AddForce(dir_ace * 8 / Time.fixedDeltaTime);

        }

        if (desaparece) 
        {

            salud = salud - 1;
            desaparece = false;
        
        }

        puntaje.text = points.ToString() + "/100";

        salud_valor = (int)salud;
        salud_text.text = salud_valor.ToString();

        if (meta_bool) 
        {
            meta_var.text = "Victory";

            if(points == 100) 
            {
                ga_var.text = "GAAAA!!!";
            }

            StartCoroutine(cerra());

        }

        intentos_var.text = intentos_valor.ToString();

        if (Input.GetKeyDown(KeyCode.R)) 
        {

            SceneManager.LoadScene("Nivel");

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();
            Debug.Log("F");
        
        }
        


    }


    IEnumerator cerra() 
    {

        yield return new WaitForSeconds(1);
        Application.Quit();

    }


    IEnumerator retraso() 
    {
        yield return new WaitForSeconds(0.1f);
        res_can = false;

    }


    private void FixedUpdate()
    {
        Physics.gravity = ngra * esca;

    }

   


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Salud")) 
        {
            mecura = 1;
        }

        if (collision.gameObject.CompareTag("Daño"))
        {
            meduele = 1;
        }

        if (collision.gameObject.CompareTag("Ace"))
        {
            dir_ace = collision.gameObject.transform.forward;
            ace_p = true;
        }

        if (collision.gameObject.CompareTag("Balita")) 
        {

            //salud -= salud;
            desaparece = true;
            collision.transform.position = new Vector3(0, -5, 0);
                    
        }

        
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Salud"))
        {
            mecura = 0;
        }

        if (collision.gameObject.CompareTag("Daño"))
        {
            meduele = 0;
        }

        if (collision.gameObject.CompareTag("Ace"))
        {
            ace_p = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coins")
        {
            points = points + 1;
        }

        if (other.tag == "Respawn")
        {
            salud = 100f;
            tran.position = new Vector3(1, 1.6f, 1);
            rbd.velocity = new Vector3();
            tran.right = new Vector3(0, 0, -1);
            res_can = true;
            intentos_valor += 1;
        }

        if (other.tag == "Meta")
        {

            meta_bool = true;

        }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            res_can = false;
            //Debug.Log("XD");
        }
    }

}
