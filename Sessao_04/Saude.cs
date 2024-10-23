//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saude : MonoBehaviour
{
    public int MaxVida = 100;
    public int Vida;

    // Start is called before the first frame update
    void Start()
    {
        Vida = MaxVida;
    }
    //Perde vida
    public void PerdeVida(int valor)
    {
        Vida -= valor;
        if (Vida < 0)
            Vida = 0;

    }
    //Ganha vida
    public void GanhaVida(int valor)
    {
        Vida += valor;
        if (Vida > MaxVida)
            Vida = MaxVida;
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
