//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJogo : MonoBehaviour
{
    public GameObject PanelMenuJogo;

    // Start is called before the first frame update
    void Start()
    {
        PanelMenuJogo.SetActive(false);
    }

    public void MostrarMenuJogo()
    {
        Time.timeScale = 0;
        PanelMenuJogo.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    public void EsconderMenuJogo()
    {
        Time.timeScale = 1;
        PanelMenuJogo.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Terminar()
    {
        Debug.Log("Voltar ao menu principal");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (PanelMenuJogo.activeSelf)
                EsconderMenuJogo();
            else
                MostrarMenuJogo();
        }
    }
}
