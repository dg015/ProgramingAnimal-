using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class ClimbAT : ActionTask {
        public Transform targetTransform;
        public BBParameter<Vector3> targetPosition;
		private NavMeshAgent navAgent;

		//reycast
		public float raycastDistance;
		public LayerMask UFOlayerMask;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Vector3 directionToTarget = targetTransform.position - agent.transform.position;

            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
            targetPosition.value = target;
			navAgent.SetDestination(target);
			checkIfClimbing();
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void checkIfClimbing()
		{
			RaycastHit hit;
			if( Physics.Raycast(agent.transform.position,agent.transform.up * -1, out hit,raycastDistance,UFOlayerMask) )
			{
				Debug.Log("ufo time");
			}
			Debug.DrawRay(agent.transform.position, agent.transform.up * -1, Color.blue);
			
		}
	}
}