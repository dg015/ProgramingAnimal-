using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class TireringAT : ActionTask {
        public BBParameter<float> sleep;
        public BBParameter<bool> isSleeping;
        public BBParameter<float> minimalSleep;
        public BBParameter<bool> isEating;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}


		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //if the cat is not already sleeping (kinda hard to get more tired when already sleeping) or eating then decrease
            // the sleep variable, it doesnt go down while eating so the action is not interrupted
            if (sleep.value >= minimalSleep.value && !isSleeping.value && !isEating.value)
            {
                sleep.value -= Time.deltaTime;
            }
        }
	}
}