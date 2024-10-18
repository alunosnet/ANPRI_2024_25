//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roda : MonoBehaviour
{
    public float VelocidadeRotacao = 10;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Não existe nenhum player!");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(transform.up * VelocidadeRotacao * Time.deltaTime);
        transform.LookAt(player.transform.position, Vector3.up);
    }
}
