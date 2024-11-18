//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*Libertar o cursor do rato*/
        Cursor.lockState = CursorLockMode.None;
        /*Definir o tempo em 1*/
        Time.timeScale = 1.0f;
        /*TODO: aplicar as definições*/
    }

    public void Comecar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Continuar()
    {
        //TODO: ler o último nível jogado

    }
    public void Definicoes()
    {
        SceneManager.LoadScene("MenuDefinicoes");
    }
    public void Terminar()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
