using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class RestedCT : ConditionTask {

		public BBParameter<float> sleep;
		public float maxSleep;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if(sleep.value >= maxSleep)
			{
				//if the cat sleep variable is over the max then the cat is rested
                return true;
            }
			else
			{
				return false; 
			}
			
		}
	}
}