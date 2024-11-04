//
// Copyright (c) 2022 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject PedraPrefab;
    public Transform PontoAtirar;
    public float ForcaAtirar = 5;
    public float TempoDeVida = 5;
    //TODO: Animação

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            AtirarPedra();
        }
    }

    void AtirarPedra()
    {
        var objeto=Instantiate(PedraPrefab,PontoAtirar.position,Quaternion.identity);
        objeto.GetComponent<Rigidbody>().AddForce(transform.forward * ForcaAtirar);
        Destroy(objeto,TempoDeVida);
    }
}
