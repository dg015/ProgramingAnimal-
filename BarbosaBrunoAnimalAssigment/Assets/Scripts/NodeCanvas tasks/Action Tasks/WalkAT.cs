using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {

		// target moving
        public BBParameter <Transform> targetTransform;
        public BBParameter<Vector3> targetPosition;
        public BBParameter <NavMeshAgent> navAgent;
		// eat and hunger
		public BBParameter<float> hunger;
		public BBParameter<float> sleep;
		// state walking


		//audio
		public BBParameter<AudioSource> source;
        public BBParameter<AudioClip> clip;

		//playing
		public BBParameter<float> state;


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
                targetTransform.value = GameObject.Find("Bed").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Bed").GetComponent<Transform>().position;
            }
			else  if (hunger.value < 1)
            {
				source.value.PlayOneShot(clip.value);
                targetTransform.value = GameObject.Find("Eat platform").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Eat platform").GetComponent<Transform>().position;
            }
			else if (hunger.value > 1 && sleep.value > 1)// doest check for 4 because it resets back to state 0 when change states to not create infinite loops
			{
				Debug.Log("play time");
				targetTransform.value = GameObject.Find("Play platform").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Play platform").GetComponent<Transform>().position;
            }

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			walking();
            if (walking() == true)
            {
                Debug.Log("arrived");
                EndAction(true);
            }
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
				Debug.Log("not there yet");
				return false;
			}
        }


		private void check()
		{

		}
	}
}