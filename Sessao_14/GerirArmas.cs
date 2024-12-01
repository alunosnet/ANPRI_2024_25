using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
public class GerirArmas : MonoBehaviour
{
    CinemachineVirtualCamera cinemachine;
    CinemachineTransposer transposer;
    public float MinY = 0.25f;
    public float MaxY = 4;
    public float VelocidadeY = 1;

    public Sprite Rocha;
    public Sprite Arma;
    public Image ImagemArmaEscolhida;

    public Atirar PrimeiraArma;
    public Disparar SegundaArma;


    // Start is called before the first frame update
    void Start()
    {
        cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        transposer = cinemachine.GetCinemachineComponent<CinemachineTransposer>();
        SelecionaRocha();
    }

    void SelecionaRocha()
    {
        ImagemArmaEscolhida.sprite = Rocha;
        PrimeiraArma.enabled= true;
        SegundaArma.enabled = false;
    }
    void SelecionaArma()
    {
        ImagemArmaEscolhida.sprite = Arma;
        PrimeiraArma.enabled = false;
        SegundaArma.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        //atualizar a posição da camera
        float y = Input.GetAxis("Mouse Y");
        transposer.m_FollowOffset.y += y * Time.deltaTime * VelocidadeY;
        transposer.m_FollowOffset.y = Mathf.Clamp(transposer.m_FollowOffset.y, MinY, MaxY);

        //selecionar a arma
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelecionaRocha();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelecionaArma();
    }
}
