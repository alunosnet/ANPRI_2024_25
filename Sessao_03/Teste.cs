using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public string nome = "Maria";
    public GameObject OutroGameObject;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(nome);
        //Debug.Log(transform.position);
        rb=GetComponent<Rigidbody>();
        if(rb!=null)
        {
            rb.useGravity=false;
            Debug.Log("Desativei a gravidade", this.gameObject);
        }
        else
        {
            Debug.Log("Não tem rigidbody", this.gameObject);
        }
        if (OutroGameObject != null)
        {
            OutroGameObject.GetComponent<Renderer>().enabled=false;
            Debug.Log("Desativei o outro game object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Olá mundo");
    }
}
