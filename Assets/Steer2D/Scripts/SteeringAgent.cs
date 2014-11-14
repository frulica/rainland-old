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
		public LayerMask mask;
		public float minDistToGround = 0.5f;
		public PlatformerCharacter2D player;

        [HideInInspector]
        public Vector2 CurrentVelocity;

		float PlayerMinY;
		float GroundMinY;

		float minY;
		float maxY;

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

		void setMinMaxY(RaycastHit2D hit) {
			PlayerMinY = player.transform.position.y - player.renderer.bounds.size.y; 

			GroundMinY = hit.point.y + minDistToGround;

			if (!player.falling) {
				minY = GroundMinY; //(PlayerMinY > GroundMinY) ? PlayerMinY : GroundMinY;
				maxY = player.transform.position.y + 1; // TODO: get top of sprite y coordinate, instead of pivot
			}
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

			// check with min/may Y position
			RaycastHit2D hit = Physics2D.Raycast(possiblePosition, -Vector2.up,  5.0f, mask);
			if (hit.collider != null) 
			{
				setMinMaxY(hit);
				
				//Debug.Log ("distance: " + distanceToGround);
				if (possiblePosition.y > maxY )  // check with max y height relative to player
				{
					possiblePosition.y = maxY;
				}
				if (possiblePosition.y < minY)
				{
					possiblePosition.y = minY;
				}
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