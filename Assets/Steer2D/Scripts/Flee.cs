using System;
using UnityEngine;

namespace Steer2D
{
    public class Flee : SteeringBehaviour
    {
        public Transform FleeFrom;
        public float FleeRadius = 1;
        public bool DrawGizmos = false;

        public override Vector2 GetVelocity()
        {
			float distance = Vector3.Distance(transform.position, FleeFrom.position);

            if (distance < FleeRadius) 
				return -((((Vector2)FleeFrom.position - (Vector2)transform.position).normalized * agent.MaxVelocity) - agent.CurrentVelocity);
            else
                return Vector2.zero;
        }

        void OnDrawGizmos()
        {
            if (DrawGizmos)
            {
                Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(FleeFrom.position, FleeRadius);
            }
        }
    }
}
