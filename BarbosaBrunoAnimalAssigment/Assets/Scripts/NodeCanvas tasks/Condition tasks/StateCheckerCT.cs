using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class StateCheckerCT : ConditionTask {

        public BBParameter<int> StateID;
		public int nextState;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {
			if(nextState == StateID.value)
			{
				//check if the generated state is the one this taks is checking for
                StateID.value = 0;
                return true;
				
            }
			else
			{
				return false;
			}
		}
	}
}