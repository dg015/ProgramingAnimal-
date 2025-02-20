using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class FullCT : ConditionTask {

        public BBParameter<float> hunger;
        public float maxHunger;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (hunger.value >= maxHunger)
			{
				//check if the cat is full 
                return true;
            }
			else
			{
				return false ;
            }
			
		}
	}
}