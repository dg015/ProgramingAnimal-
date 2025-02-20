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

		public bool alreadyPlayedAudio;
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

		protected override void OnExecute() {
			// for this one I tried to use this state for multiple actions to be more effectie with code
			//first check if the cat is tired then send it go to sleep
            if (sleep.value <1)
			{
				//find the bed location
                targetTransform.value = GameObject.Find("Bed").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Bed").GetComponent<Transform>().position;
            }
			else  if (hunger.value < 1)
            {
				//if the cat didnt already play the stomach rumble sound play it 
				if(!alreadyPlayedAudio && !source.value.isPlaying)
				{
					//use the alreadyPlayedAudio variable to make sure the audio doesnt play multiple times
					alreadyPlayedAudio = true;
                    source.value.PlayOneShot(clip.value);
                }
				//set the target as the eating platform for the cat to eat
                targetTransform.value = GameObject.Find("Eat platform").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Eat platform").GetComponent<Transform>().position;
            }
			else if (hunger.value > 1 && sleep.value > 1)// doest check for 4 because it resets back to state 0 when change states to not create infinite loops
			{
				//if the cat is not hungry or tired then they play
				//it checks for hunger or sleep because if theyre not either then the cat can only walk to play locaiton instead 
				//since this script only leads to bed,food and play
				Debug.Log("play time");
				targetTransform.value = GameObject.Find("Play platform").GetComponent<Transform>();
                targetPosition.value = GameObject.Find("Play platform").GetComponent<Transform>().position;
            }

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//make them walk and if they arrive end the state
			walking();
            if (walking() == true)
            {
                Debug.Log("arrived");
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			//reset played audio variable for it to play again
            alreadyPlayedAudio = false;
        }
		public bool walking()
		{
			//set the location to the current target
            Vector3 directionToTarget = targetTransform.value.position - agent.transform.position;

            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
            targetPosition.value = target;
            navAgent.value.SetDestination(target);
			if(Vector3.Distance(agent.transform.position, targetPosition.value)< 2)
			{
				//if theyre close enough set to true otherwise set it to galse
				return true;
			}
			else
			{
				Debug.Log("not there yet");
				return false;
			}
        }
	}
}