using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public float attackRange = 2.0f;      
    public float attackCooldown = 1.5f;   
    public int attackDamage = 10;         

    private GameObject player;            
    private float lastAttackTime;
    [SerializeField] private float vidas;
    private NavMeshAgent agent;
    private FistPerson Player;
    private Animator animator;
    [SerializeField] private float velocidadPersecucion = 3.5f;
    [SerializeField] private float velocidadNormal = 1.5f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = FindAnyObjectByType<FistPerson>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

   
    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        
        if (distanceToPlayer < 10f)  
        {
            agent.speed = velocidadPersecucion; 
            animator.SetFloat("Speed", agent.velocity.magnitude); 
        }
        else
        {
            agent.speed = velocidadNormal; 
            animator.SetFloat("Speed", agent.velocity.magnitude); 
        }
        if (player != null && IsPlayerInRange())
        {
            AttackPlayer();
        }


        agent.SetDestination(player.transform.position);
    }
    private bool IsPlayerInRange()
    {
        // Verifica la distancia entre el enemigo y el jugador
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= attackRange;
    }
    private void AttackPlayer()
    {
        // Verifica si el enemigo puede atacar
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            // Intentar dañar al jugador si tiene un componente de salud
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }

            // Agrega animación o efecto aquí (opcional)
            Debug.Log("Enemigo ataca al jugador!");
        }

    }
    
      
}
