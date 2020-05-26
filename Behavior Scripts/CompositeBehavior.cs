using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Handle data mismatch
        if (weights.Length != behaviors.Length) {
            Debug.LogError("Data mismatch" + name, this);
            return Vector2.zero;
        }

        //set up move
        Vector2 move = Vector2.zero;

        //iterate through behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].calculateMove(agent, context, flock) * weights[i];

            if (partialMove.sqrMagnitude > weights[i] * weights[i])
            {
                partialMove.Normalize();
                partialMove *= weights[i];
            }
            move += partialMove;
        }
        return move;
    }

}
