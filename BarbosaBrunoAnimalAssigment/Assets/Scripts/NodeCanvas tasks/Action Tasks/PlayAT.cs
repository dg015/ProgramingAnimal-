using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions {

	public class PlayAT : ActionTask {

		public BBParameter<float> playtTimer;
        public BBParameter<float> playtTimerMax;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<float> spinRadius;
		float angle;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			playtTimer.value = 0;


		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			spin();
            playtTimer.value += Time.deltaTime;
            if (playtTimer.value > playtTimerMax.value)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		public void spin()
		{
			
			Vector3 direction = targetPosition.value - agent.transform.position;
			direction.y = 0f;
			direction.Normalize();
			angle += 2 * Time.deltaTime; 
			Vector3 moveDireciton = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spinRadius.value;


			navAgent.value.SetDestination(agent.transform.position + moveDireciton);
        }
	}
}