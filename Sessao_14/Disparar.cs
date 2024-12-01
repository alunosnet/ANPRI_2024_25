using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
public class Disparar : MonoBehaviour
{
    Camera MainCamera;
    public float Distancia = 50;
    public int DanoTirar = 10;
    public float ForcaTiro = 50;
    public LayerMask Layers;
    Animator animator;
    AudioSource som;
    public AudioClip SomTiro;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera=FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        if (som == null)
        {
            som = transform.AddComponent<AudioSource>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SimulaTiro();
        }
    }
    void SimulaTiro()
    {
        animator.SetTrigger("disparar");
        if(som!=null && SomTiro!=null )
        {
            som.PlayOneShot(SomTiro);
        }
        //simular o tiro
        Vector3 origem = MainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        if (Physics.Raycast(origem,MainCamera.transform.forward,out hit,Distancia,Layers))
        {
            var saude = hit.transform.GetComponent<Saude>();
            if (saude != null)
                saude.PerdeVida(DanoTirar);

            var rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direcao = hit.transform.position - transform.position;
                rb.AddForceAtPosition(direcao.normalized * ForcaTiro, hit.point);
            }

            var explode=hit.transform.GetComponent<Explode>();
            if (explode != null)
                explode.Explosao();
        }
    }
}
