//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaMensagens : MonoBehaviour
{
    public TextMeshProUGUI txtMensagens;

    public static SistemaMensagens instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (txtMensagens == null)
            txtMensagens = GetComponent<TextMeshProUGUI>();
        EsconderMensagem();
    }

    public void MostrarMensagem(string texto,float duracao=4)
    {
        txtMensagens.enabled = true;
        txtMensagens.text = texto;
        Invoke(nameof(EsconderMensagem), duracao);
    }
    void EsconderMensagem()
    {
        txtMensagens.enabled = false;
        txtMensagens.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
