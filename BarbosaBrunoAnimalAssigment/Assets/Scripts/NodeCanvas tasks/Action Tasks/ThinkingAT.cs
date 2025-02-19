using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThinkingAT : ActionTask {
		//state
		public BBParameter<int> StateID;
		
		//thinking
		public float waitTimeLimit;
		public float WaitTime;

		//particle effect
        public GameObject Effect;
        public BBParameter<Transform> spawnPoint;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            GameObject Particle = Object.Instantiate(Effect, spawnPoint.value);
            WaitTime = 0;
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            generateNewEvent();
            
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void generateNewEvent()
		{
			
			WaitTime += Time.deltaTime;
			if(WaitTime> waitTimeLimit)
			{
                StateID.value = Random.Range(2, 5);
                EndAction(true);
                Debug.Log(StateID.value.ToString());
            }

		}
	}
}