using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class HungerAT : ActionTask {
		//variables
		public BBParameter<float> hunger;
        public BBParameter<float> MinimalHunger;
        public BBParameter<bool> isEating;
        public BBParameter<bool> isSleeping;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// if the value is higher the minimal hunger and the cat is not currently eating or sleeping then decrease hunger
			// checks if the cat is not sleeping or already eating otherwise it would interrupt these states
            if (hunger.value >= MinimalHunger.value && !isEating.value &&!isSleeping.value)
            {
                hunger.value -= Time.deltaTime;
            }
        }
	}
}