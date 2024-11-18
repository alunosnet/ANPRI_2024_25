//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbrirPorta : MonoBehaviour
{
    public bool PortaFechada=true;
    Animator _animator;
    public Image imgChave;

    private void OnTriggerEnter(Collider other)
    {
        if(PortaFechada && other.transform.CompareTag("Player"))
        {
            if (imgChave.enabled)
                _animator.SetTrigger("abrir");
            else
                SistemaMensagens.instance.MostrarMensagem("Precisa de uma chave");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
