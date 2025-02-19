using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class PlayAT : ActionTask {

		public BBParameter<float> playtTimer;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<NavMeshAgent> navAgent;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			spin();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		public void spin()
		{
			Vector2 direction = new Vector2(agent.transform.position.x - targetPosition.value.x, agent.transform.position.y - targetPosition.value.y);
			float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
			angle += 1 ; 
		}
	}
}