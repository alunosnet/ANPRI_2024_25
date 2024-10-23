//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RecuperaVida : MonoBehaviour
{
    public int ValorGanhaVida = 10;
    public float IntervaloGanharVida = 3;
    float ProximoIntervalo = 0;
    public bool SoUmaVez = true;

    void ProcessaColisao(GameObject gameobject)
    {
        if (Time.time < ProximoIntervalo) return;
        var saude = gameobject.transform.GetComponent<Saude>();
        if (saude != null)
        {
            saude.GanhaVida(ValorGanhaVida);
            if (SoUmaVez)
                Destroy(this.gameObject);
            ProximoIntervalo = Time.time + IntervaloGanharVida;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ProcessaColisao(other.gameObject);
    }
}
