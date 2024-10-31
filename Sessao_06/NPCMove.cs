//
// Copyright (c) 2022 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMove : MonoBehaviour
{
    public enum NPCEstados { Idle = 0, Patrula = 1, Atacar = 2, Morto = 3 }
    public Transform[] Pontos;
    [SerializeField] int ProximoPonto = 0;
    [SerializeField] int Velocidade = 3;
    [SerializeField] float DistanciaMinima = 1;
    [SerializeField] public NPCEstados Estado = NPCEstados.Patrula;
    [SerializeField] bool Inimigo = true;
    [SerializeField] Transform Olhos;
    [SerializeField] float AnguloVisao = 90;
    [SerializeField] float DistanciaVisao = 10;
    [SerializeField] float DistanciaAtacar = 2;
    [SerializeField] float IntervaloAtacar = 3;
    [SerializeField] int ValorTiraVida = 10;
    float IntervaloAtual = 0;
    NavMeshAgent _agente;
    GameObject _player;
    Saude _saude;

    // Start is called before the first frame update
    void Start()
    {
        _agente = GetComponent<NavMeshAgent>();
        _saude= GetComponent<Saude>();
        _player = GameObject.FindGameObjectWithTag("Player");
        //_player = GameObject.FindObjectOfType<PlayerMove>().gameObject;
        _agente.speed = Velocidade;
    }

    void Estado_Idle()
    {
        //TODO: anima��o
        _agente.isStopped = true;
        _agente.velocity = Vector3.zero;
    }
    void Estado_Patrulha()
    {
        //TODO: anima��o
        _agente.isStopped = false;
        if(Pontos.Length==0)
        {
            Estado = NPCEstados.Idle;
            return;
        }
        if (Vector3.Distance(transform.position, Pontos[ProximoPonto].position) < DistanciaMinima)
        {
            ProximoPonto++;
            if (ProximoPonto > Pontos.Length - 1)
                ProximoPonto = 0;
        }
        _agente.SetDestination(Pontos[ProximoPonto].position);
        
    }

    void Estado_Atacar()
    {
        //pode atacar
        if(Vector3.Distance(transform.position,_player.transform.position)<DistanciaAtacar)
        {
            _agente.isStopped = true;
            _agente.velocity=Vector3.zero;
            if(Time.time>IntervaloAtual)
            {
                //TODO: anima��o
                IntervaloAtual = Time.time + IntervaloAtacar;
                _player.GetComponent<Saude>().PerdeVida(ValorTiraVida);
            }
        }
        else
        {
            _agente.isStopped = false;
            Vector3 OlharPara = new Vector3(_player.transform.position.x,
                                            transform.position.y, _player.transform.position.z);
            transform.LookAt(OlharPara);
            _agente.SetDestination(_player.transform.position);
        }
    }
    void Estado_Morto()
    {
        //TODO: anima��o morrer
        Estado = NPCEstados.Morto;
    }
    bool VePlayer()
    {
        if(Vector3.Distance(transform.position,_player.transform.position)<=DistanciaVisao)
        {
            if(Utils.CanYouSeeThis(Olhos,_player.transform,null,AnguloVisao))
                return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Estado == NPCEstados.Morto) return;
        if(_saude!=null && _saude.Morreu())
        {
            Estado_Morto();
            return;
        }
        switch(Estado)
        {
            case NPCEstados.Idle:
                Estado_Idle();
                if (Inimigo && VePlayer())
                    Estado = NPCEstados.Atacar;
                break;
            case NPCEstados.Patrula:
                Estado_Patrulha();
                if (Inimigo && VePlayer())
                    Estado = NPCEstados.Atacar;
                break;
            case NPCEstados.Atacar:
                if (Inimigo == false || VePlayer() == false)
                    Estado = NPCEstados.Patrula;
                Estado_Atacar();
                break;
        }
    }
}
