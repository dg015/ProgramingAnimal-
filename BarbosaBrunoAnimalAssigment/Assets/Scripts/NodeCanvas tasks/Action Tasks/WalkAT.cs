using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {

        public BBParameter <Transform> targetTransform;
        public BBParameter<Vector3> targetPosition;
        public BBParameter <NavMeshAgent> navAgent;
		public BBParameter<float> hunger;
		public BBParameter<float> sleep;

		//audio
		public BBParameter<AudioSource> source;
        public BBParameter<AudioClip> clip;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if(sleep.value <1)
			{
                targetTransform = GameObject.Find("Bed").GetComponent<Transform>();
                targetPosition = GameObject.Find("Bed").GetComponent<Transform>().position;
            }
			else  if (hunger.value < 1)
            {
				source.value.PlayOneShot(clip.value);
                targetTransform = GameObject.Find("Eat platform").GetComponent<Transform>();
                targetPosition = GameObject.Find("Eat platform").GetComponent<Transform>().position;
            }
            if ( walking() == true )
			{
                EndAction(true);
            }
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		public bool walking()
		{
            Vector3 directionToTarget = targetTransform.value.position - agent.transform.position;

            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
            targetPosition.value = target;
            navAgent.value.SetDestination(target);
			if(Vector3.Distance(agent.transform.position, targetPosition.value)< 2)
			{
				return true;
			}
			else
			{
				return false;
			}
        }

	}
}