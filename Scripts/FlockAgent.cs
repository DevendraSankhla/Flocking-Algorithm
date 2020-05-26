using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    void Start()
    {
        agentCollider = GetComponent<Collider2D>() ;
    }
    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 Velocity)
    {
        if (float.IsNaN(Velocity.x) || float.IsNaN(Velocity.y))
            Velocity = Vector2.zero;
        transform.up = Velocity;
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }
}
