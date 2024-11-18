//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuDefinicoes : MonoBehaviour
{
    public TMP_Dropdown ddQualidade;
    public TMP_Dropdown ddResolucao;
    public Toggle tgFullScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        /*TODO: atualizar a UI*/
    }
    public void AlterouQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
        /*TODO: guardar*/
    }
    public void AlterouResolucao(int i)
    {
        string resolucao = ddResolucao.options[i].text;
        string[] elementos = resolucao.Split('X');
        int largura = int.Parse(elementos[0]);
        int altura = int.Parse(elementos[1]);
        Screen.SetResolution(largura, altura, Screen.fullScreen);
        /*TODO: guardar*/
    }
    public void AlterouFullScreen()
    {
        Screen.fullScreen = tgFullScreen.isOn;
        /*TODO: guardar*/
    }
    public static void CarregarSettings()
    {
        //TODO: ler as settings e aplicar ao jogo
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
  
}
