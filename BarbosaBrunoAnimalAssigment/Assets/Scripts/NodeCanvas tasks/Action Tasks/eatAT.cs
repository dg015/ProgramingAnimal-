using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class eatAT : ActionTask {
        
        //varaibles
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
            //if the hunger variable (its actually how full the cat is) then they finished eating
            if (hungerValue.value > hungerMax.value)
            {
                Debug.LogWarning("FINISHED EATING");
                //set is eating to false and finish
                IsEating.value = false;
                
                EndAction(true);
            }
            else if (hungerValue.value < hungerMax.value) 
            {
                //if its lower the the max then the cat is eating and increase their hunger value
                IsEating.value = true;
                hungerValue.value += Time.deltaTime * 25;
            }


        }
    }
}