using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class ClimbAT : ActionTask {

		//walk to target

        public Transform targetTransform;
        public BBParameter<Vector3> targetPosition;
		private NavMeshAgent navAgent;

		//UFO signifier
		public GameObject UFOObject;
		public bool isClimbing;
        public GameObject CreatedObject;

        //reycast
        public float raycastDistance;
		public LayerMask UFOlayerMask;
		public bool hasSpawned;

        protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			//get the navmesh object
			navAgent = agent.GetComponent<NavMeshAgent>();
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//get the direction to the target 
            Vector3 directionToTarget = targetTransform.position - agent.transform.position;
            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
			//set the target position as the target to move towards
            targetPosition.value = target;
			navAgent.SetDestination(target);
			//call UFO function 
			UFO();
			checkIfClimbing();
			if( Vector3.Distance(agent.transform.position, targetPosition.value)< 2)
			{
				//if they're close enough finish taks
				Debug.Log("arrived");
				EndAction(true);
			}
        }
		private void checkIfClimbing()
		{
			//make raycast to see if its touching the invisible wall with the layer UFO to spawn teh ufo
            RaycastHit hit;
			if( Physics.Raycast(agent.transform.position,agent.transform.up * -1, out hit,raycastDistance,UFOlayerMask) )
			{
                isClimbing=true;
                Debug.Log("ufo time");
			}
			else
			{
				//if not set climinb to false
				isClimbing = false;
				hasSpawned = false;
			}
			if(isClimbing == false)
			{
				//and if false destroy the UFO
                UnityEngine.Object.Destroy(CreatedObject);
            }
			//debug options to make sure its working correclty
			Debug.DrawRay(agent.transform.position, agent.transform.up * -1, Color.blue);
			Debug.Log(UFOObject);
		}

		private void UFO()
		{
			//if its climbing and has not yet spawned spawn ufo 
			if(isClimbing && !hasSpawned)
			{
				hasSpawned = true;
				Vector3 SpawnLocation = new Vector3(agent.transform.position.x,
					agent.transform.position.y, agent.transform.position.z);

                CreatedObject = Object.Instantiate(UFOObject, agent.transform);
                
            }

		}
	}
}