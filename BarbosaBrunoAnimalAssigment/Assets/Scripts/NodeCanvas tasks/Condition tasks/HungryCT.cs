using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class HungryCT : ConditionTask {

        public BBParameter<float> hunger;
        public BBParameter<float> MinimalHunger;
        public BBParameter<bool> isEating;
        
		

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            //check if the cat is hungry by checkign if the hunger variable is below minimum
            if (hunger.value < MinimalHunger.value && !isEating.value)
            {
				Debug.Log("too hungry");
                return true;
            }
			else
			{
                return false;
			}
            
		}
	}
}