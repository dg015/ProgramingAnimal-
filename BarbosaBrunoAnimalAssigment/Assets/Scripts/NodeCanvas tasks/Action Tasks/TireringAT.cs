using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class TireringAT : ActionTask {
        public BBParameter<float> sleep;
        public BBParameter<bool> isSleeping;
        public BBParameter<float> minimalSleep;


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
            if (sleep.value > minimalSleep.value && !isSleeping.value)
            {
                sleep.value -= Time.deltaTime;
            }
            else if (isSleeping.value)
            {
                Debug.Log("Sleeping");
            }

        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}