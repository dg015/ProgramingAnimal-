using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class PetAT : ActionTask {


        public Transform PlayerTransform;
        public Vector3 PlayerPosition;

        //audio
        public BBParameter<AudioSource> source;
        public AudioClip Clip;

		//petting mechanic
		public float petValue;
		public float petValueMax;

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

            
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			ChasePlayer();
			if(Vector3.Distance(agent.transform.position,PlayerPosition) <2f)
			{
				complain();
				if(petValue > petValueMax)
				{
                    EndAction(true);
                }
			}
		}
		
		private void ChasePlayer()
		{
            PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
            PlayerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        }

		private void complain()
		{
            source.value.PlayOneShot(Clip);

        }

	}
}