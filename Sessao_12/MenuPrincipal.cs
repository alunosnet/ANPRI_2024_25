//
// Copyright (c) 2024 IndieDevPt. All rights reserved.
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
        var indice = PlayerPrefs.GetInt("nivel", -1);
        if (indice == -1)
            Comecar();
        else
            SceneManager.LoadScene(indice);

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
