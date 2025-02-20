using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class PetAT : ActionTask {


        public Transform PlayerTransform;
        public Vector3 PlayerPosition;
        public BBParameter<NavMeshAgent> navAgent;

        //audio
        public BBParameter<AudioSource> source;
        public AudioClip Clip;
        public bool alreadyPlayed;

        //petting mechanic
        public float petValue;
		public float petValueMax;

		public PlayerPetting pettingScript;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            //reset the variables back to 0 on execute
			petValue = 0;
            alreadyPlayed = false;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //get the location and if the cat is being pet
            getPosition();
			beingPetted();
            if (Vector3.Distance(agent.transform.position,PlayerPosition) <2f)
			{
                //if the cat is close the cat will complain
				complain();
				if(petValue > petValueMax)
				{
                   // if the pet value (amount the cat is being pet) then stop since the cat is satified
					source.value.Stop();
                    EndAction(true);
                }
			}
			else
			{
                //otherwise just keep chasing the player
				chase();

            }
		}
		
		private void getPosition()
		{
            //get the location and posiiton of the player to chase them
            PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
            PlayerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        }

		private void complain()
		{
            //the cat will complaing by meowing a lot
			if(!alreadyPlayed)
			{
                // check if the audio already has played to make sure it wont play every frmae
                source.value.PlayOneShot(Clip);
				alreadyPlayed = true;
            }
            

        }

		private void beingPetted()
		{
            //cehck the player pet script to see if the variable for petting is true to increase the pet value
			if(pettingScript.IsPetting &&petValue < petValueMax)
			{
				petValue += Time.deltaTime;
			}
		}
        public void chase()
        {
            //get the direction by subtracting the player transform with the cat
            Vector3 directionToTarget = PlayerTransform.position - agent.transform.position;

            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;

            //get the position of the cat and set it to a variable target to make the cat chase them
            PlayerPosition = target;
            navAgent.value.SetDestination(target);
        }
        protected override void OnStop()
        {
            //stop the sound in case the action is interrupted 
            source.value.Stop();
        }
    }

}