//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Saude : MonoBehaviour
{
    public int MaxVida = 100;
    public int Vida;
    public AudioClip SomPerderVida;
    public AudioClip SomMorreu;
    public AudioClip SomGanharVida;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Vida = MaxVida;
        _audioSource=GetComponent<AudioSource>();
        if(_audioSource==null)
            _audioSource=transform.AddComponent<AudioSource>();
        _audioSource.spatialBlend = 1;

    }
    //Perde vida
    public void PerdeVida(int valor)
    {
        Vida -= valor;
        if (Vida < 0)
            Vida = 0;
        if (Vida > 0 && SomPerderVida != null)
            _audioSource.PlayOneShot(SomPerderVida);
        if (Vida == 0 && SomMorreu != null)
            _audioSource.PlayOneShot(SomMorreu);
    }
    //Ganha vida
    public void GanhaVida(int valor)
    {
        Vida += valor;
        if (Vida > MaxVida)
            Vida = MaxVida;
        if (SomGanharVida != null)
            _audioSource.PlayOneShot(SomGanharVida);
    }
    //Morreu?
    public bool Morreu()
    {
        if (Vida == 0)
            return true;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
