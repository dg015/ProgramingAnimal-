using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class eatAT : ActionTask {

        public BBParameter<float> hungerValue;
        public BBParameter<bool> IsEating;
        public BBParameter<float> hungerMax;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}


		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            eating();
        }

        private void eating()
        {
            if (hungerValue.value > hungerMax.value)
            {
                Debug.LogWarning("FINISHED EATING");
                IsEating.value = false;
                
                EndAction(true);
            }
            else if (hungerValue.value < hungerMax.value) 
            {
                IsEating.value = true;
                hungerValue.value += Time.deltaTime * 25;
            }


        }
    }
}