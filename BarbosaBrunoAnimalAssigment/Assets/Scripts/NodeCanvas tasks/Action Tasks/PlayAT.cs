using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions {

	public class PlayAT : ActionTask {

		//value variables
		public BBParameter<float> playtTimer;
        public BBParameter<float> playtTimerMax;

		//movement variables
        public BBParameter<Vector3> targetPosition;
        public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<float> spinRadius;
		float angle;

		//effects variables
        public GameObject effect;
        public BBParameter<Transform> spawnPoint;
        public GameObject playIcon;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//reset variables and assign the newly instantiated object as the effect variable to later delete it
			playtTimer.value = 0;
            effect = Object.Instantiate(playIcon, spawnPoint.value);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//set the alien cat to spin
			spin();
			//increase the cat player time
            playtTimer.value += Time.deltaTime;
            if (playtTimer.value > playtTimerMax.value)
            {
				//call unity engine library because nodecanvas is stuborn with destroying stuff 
				//destroy the effect since the cat left the state so no need for the signifier
                UnityEngine.Object.Destroy(effect);
                EndAction(true);
            }
        }
		public void spin()
		{
			//get the direction of next position
			Vector3 direction = targetPosition.value - agent.transform.position;
			//set Y 0 so theres no chance of the cat flying anywhere, even though its impossible
			direction.y = 0f;
			direction.Normalize();
			angle += 2 * Time.deltaTime; // increase the angle overtime to make it spin
			//use cos and sin to get the X and Y position of the circle the cat will spin around
			Vector3 moveDireciton = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spinRadius.value;

			//set the location as the destination
			navAgent.value.SetDestination(agent.transform.position + moveDireciton);
        }
	}
}