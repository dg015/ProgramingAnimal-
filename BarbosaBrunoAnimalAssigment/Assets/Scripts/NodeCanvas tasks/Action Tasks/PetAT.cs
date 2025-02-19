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
			petValue = 0;
            alreadyPlayed = false;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            getPosition();
			beingPetted();
            if (Vector3.Distance(agent.transform.position,PlayerPosition) <2f)
			{
				complain();
				if(petValue > petValueMax)
				{
					source.value.Stop();
                    EndAction(true);
                }
			}
			else
			{
				chase();

            }
		}
		
		private void getPosition()
		{
            PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
            PlayerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        }

		private void complain()
		{
			if(!alreadyPlayed)
			{
                source.value.PlayOneShot(Clip);
				alreadyPlayed = true;
            }
            

        }

		private void beingPetted()
		{
			if(pettingScript.IsPetting &&petValue < petValueMax)
			{
				petValue += Time.deltaTime;
			}
		}
        public void chase()
        {
            Vector3 directionToTarget = PlayerTransform.position - agent.transform.position;

            Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
            PlayerPosition = target;
            navAgent.value.SetDestination(target);
        }
        protected override void OnStop()
        {
            source.value.Stop();
        }
    }

}