using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject
{
    public abstract Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock);
}
