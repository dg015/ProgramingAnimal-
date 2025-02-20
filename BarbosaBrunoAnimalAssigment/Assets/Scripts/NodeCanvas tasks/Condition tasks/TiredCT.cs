using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class Tired : ConditionTask {

		public BBParameter<float> Sleep;
        public BBParameter<float> minimalSleep;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {
			if(Sleep.value < minimalSleep.value)
			{
				//checks if sleep drops bellow minimal value toe send cat to sleep
				Debug.Log("sleepyTime");
                return true;
            }
			else
			{
                return false;
			}
		}
	}
}