//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject PedraPrefab;
    public Transform PontoAtirar;
    public float ForcaAtirar = 5;
    public float TempoDeVida = 5;
    Animator _animator;
    AudioSource _audioSource;
    public AudioClip SomAtacar;
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            _audioSource = transform.AddComponent<AudioSource>();
        _audioSource.spatialBlend = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (SomAtacar != null)
                _audioSource.PlayOneShot(SomAtacar);
            AtirarPedra();
            _animator.SetTrigger("atirar");
        }
    }

    void AtirarPedra()
    {
        var objeto=Instantiate(PedraPrefab,PontoAtirar.position,Quaternion.identity);
        objeto.GetComponent<Rigidbody>().AddForce(transform.forward * ForcaAtirar);
        Destroy(objeto,TempoDeVida);
    }
}
