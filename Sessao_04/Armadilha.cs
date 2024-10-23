//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Armadilha : MonoBehaviour
{
    public int ValorTiraVida = 10;
    public float IntervaloPerderVida = 3;
    float ProximoIntervalo = 0;

    void ProcessaColisao(GameObject gameobject)
    {
        if (Time.time < ProximoIntervalo) return;
        var saude = gameobject.transform.GetComponent<Saude>();
        if (saude != null)
        {
            saude.PerdeVida(ValorTiraVida);
            ProximoIntervalo = Time.time+IntervaloPerderVida;
        }
    }

    //Quando os objetos colidem
    private void OnCollisionEnter(Collision collision)
    {
        ProcessaColisao(collision.gameObject);
    }

    //Enquanto os objetos estão em contacto
    private void OnCollisionStay(Collision collision)
    {
        ProcessaColisao(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        ProcessaColisao(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        ProcessaColisao(other.gameObject);
    }
}
