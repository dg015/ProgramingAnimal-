using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {
		//varaibles 
		public BBParameter<float> sleepValue;
		public BBParameter<bool> IsSleeping;
		public BBParameter<float> SleepMax;
		//partivcle effect variables 
        public GameObject SleepIcon;
        public BBParameter<Transform> spawnPoint;
		public GameObject effect;

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
            effect = Object.Instantiate(SleepIcon, spawnPoint.value);
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
            sleeping();
        }
		private void sleeping()
		{
			if (sleepValue.value > SleepMax.value)
			{
                //call unity engine library because nodecanvas is stuborn with destroying stuff 
                //destroy the effect since the cat left the state so no need for the signifier
                UnityEngine.Object.Destroy(effect);
                IsSleeping.value = false;
				Debug.Log("finishd sleeping");
				EndAction(true);
			}
			else if(sleepValue.value < SleepMax.value) 
			{
				//if cat is sleeping set bool accordingly and increase the sleep( which is actually for how rested)
                IsSleeping.value = true;
                sleepValue.value += Time.deltaTime * 5;
			}
		}
	}
}