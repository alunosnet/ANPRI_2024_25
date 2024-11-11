//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Som : MonoBehaviour
{
    public AudioClip[] audioClipsPassos;
    public int ProximoSomPassos=-1;
    public bool SonsPassosSequencial = true;
    public AudioClip[] audioClipsSaltar;
    public int ProximoSomSaltar;
    public bool SonsSaltarSequencial = false;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            _audioSource = transform.AddComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.spatialBlend = 1;
        SelecionaProximoSomPassos();
        SelecionaProximoSomSaltar();
    }

    public void TocarSomPassos()
    {
        if (audioClipsPassos.Length == 0) return;
        _audioSource.PlayOneShot(audioClipsPassos[ProximoSomPassos]);
        SelecionaProximoSomPassos();
    }
    public void TocarSomSaltar()
    {
        if (audioClipsSaltar.Length == 0) return;
        _audioSource.PlayOneShot(audioClipsSaltar[ProximoSomSaltar]);
        SelecionaProximoSomSaltar();
    }
    private void SelecionaProximoSomPassos()
    {
        ProximoSomPassos = SelecionarProximo(ProximoSomPassos, audioClipsPassos.Length, SonsPassosSequencial);
    }
    private void SelecionaProximoSomSaltar()
    {
        ProximoSomSaltar = SelecionarProximo(ProximoSomSaltar, audioClipsSaltar.Length, SonsSaltarSequencial);
    }

    int SelecionarProximo(int _atual,int _max,bool _sequencial)
    {
        int temp = 0;
        if(_sequencial)
        {
            temp = _atual + 1;
            if (temp >= _max)
                temp = 0;
        }
        else
        {
            temp = Random.Range(0, _max);
        }
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
