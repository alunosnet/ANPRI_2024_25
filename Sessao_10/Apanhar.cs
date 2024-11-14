//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apanhar : MonoBehaviour
{
    public Image imgChave;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            imgChave.enabled = true;
            SistemaMensagens.instance.MostrarMensagem("Apanhou uma chave");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
