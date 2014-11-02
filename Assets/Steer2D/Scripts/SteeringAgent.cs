using UnityEngine;
using System.Collections.Generic;

namespace Steer2D
{
    public class SteeringAgent : MonoBehaviour
    {
        public float MaxVelocity = 1;
        public float Mass = 10;
        public float Friction = .05f;
        public bool RotateSprite = true;

		public float maxDistToGround = 2.0f;
		public float minDistToGround = 0.5f;
		public LayerMask mask;

		float distanceToGround = 0;

        [HideInInspector]
        public Vector2 CurrentVelocity;

        public static List<SteeringAgent> AgentList = new List<SteeringAgent>();

        List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

        public void RegisterSteeringBehaviour(SteeringBehaviour behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void DeregisterSteeringBehaviour(SteeringBehaviour behaviour)
        {
            behaviours.Remove(behaviour);
        }

        void Start()
        {
            AgentList.Add(this);
        }

        void Update()
        {
            Vector2 acceleration = Vector2.zero;

            foreach (SteeringBehaviour behaviour in behaviours)
            {
                if (behaviour.enabled)
                    acceleration += behaviour.GetVelocity() * behaviour.Weight;
            }

            CurrentVelocity += acceleration / Mass;

            CurrentVelocity -= CurrentVelocity * Friction;

            if (CurrentVelocity.magnitude > MaxVelocity)
                CurrentVelocity = CurrentVelocity.normalized * MaxVelocity;

			Vector2 possiblePosition = transform.position + (Vector3)CurrentVelocity * Time.deltaTime;

			RaycastHit2D hit = Physics2D.Raycast(possiblePosition, -Vector2.up,  Mathf.Infinity, mask);
			if (hit.collider != null) 
			{
				distanceToGround = hit.fraction;
				Debug.Log ("distance: " + distanceToGround);
				if (distanceToGround > maxDistToGround)
					possiblePosition.y = hit.transform.position.y + maxDistToFleeTarget;
				if (distanceToGround < minDistToGround)
					possiblePosition.y = hit.transform.position.y + minDistToFleeTarget;
			}

			transform.position = possiblePosition;
        
            if (RotateSprite && CurrentVelocity.magnitude > 0.0001f)
            {
                float angle = Mathf.Atan2(CurrentVelocity.y, CurrentVelocity.x) * Mathf.Rad2Deg;

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
            }
        }

        void OnDestroy()
        {
            AgentList.Remove(this);
        }
    }
}