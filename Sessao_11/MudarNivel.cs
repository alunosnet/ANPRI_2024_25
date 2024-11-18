//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            NivelSeguinte();
    }

    private void NivelSeguinte()
    {
        if(SceneManager.GetActiveScene().buildIndex==SceneManager.sceneCountInBuildSettings-1)
        {
            SistemaMensagens.instance.MostrarMensagem("Parabéns terminaste o jogo!");

            Invoke(nameof(MudaParaCenaPrincipal), 4);
        }
        else
        {
            SistemaMensagens.instance.MostrarMensagem("Próximo nível!");
            Invoke(nameof(MudaParaProximaCena), 4);
        }
    }
    void MudaParaCenaPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    void MudaParaProximaCena()
    {
        //TODO: Guarda o indice da cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
