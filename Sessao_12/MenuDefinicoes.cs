//
// Copyright (c) 2024 IndieDevPt. All rights reserved.
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
        //atualizar a interface de acordo com as settings
        tgFullScreen.isOn = PlayerPrefs.GetInt("fullscreen", 1) == 1 ? true : false;
        ddQualidade.value = PlayerPrefs.GetInt("qualidade", 3);

        string resolucao = PlayerPrefs.GetString("resolucao", "800X600");
        for(int i=0;i<ddResolucao.options.Count;i++)
        {
            if (ddResolucao.options[i].text == resolucao)
            {
                ddResolucao.value = i;
                break;
            }
        }
    }
    public void AlterouQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);

        PlayerPrefs.SetInt("qualidade", i);
        PlayerPrefs.Save();
    }
    public void AlterouResolucao(int i)
    {
        string resolucao = ddResolucao.options[i].text;
        AplicarResolucao(resolucao);

        PlayerPrefs.SetString("resolucao", resolucao);
        PlayerPrefs.Save();
    }

    private static void AplicarResolucao(string resolucao)
    {
        string[] elementos = resolucao.Split('X');
        int largura = int.Parse(elementos[0]);
        int altura = int.Parse(elementos[1]);
        Screen.SetResolution(largura, altura, Screen.fullScreen);
    }

    public void AlterouFullScreen()
    {
        Screen.fullScreen = tgFullScreen.isOn;

        PlayerPrefs.SetInt("fullscreen", Screen.fullScreen == true ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static void CarregarSettings()
    {
        //fullscreen
        Screen.fullScreen = PlayerPrefs.GetInt("fullscreen", 1) == 1 ? true : false;
        //resolução
        string resolucao = PlayerPrefs.GetString("resolucao", "800X600");
        AplicarResolucao(resolucao);

        //qualidade
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualidade", 3), true);
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
  
}
