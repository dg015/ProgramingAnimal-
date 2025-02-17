using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {
		public BBParameter<float> sleepValue;
		public BBParameter<bool> IsSleeping;
		public BBParameter<float> SleepMax;

        public GameObject playIcon;
        public BBParameter<Transform> spawnPoint;

		public GameObject effect;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
             effect = Object.Instantiate(playIcon, spawnPoint.value);
            //
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //IsSleeping = true;
            sleeping();
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		private void sleeping()
		{
			if (sleepValue.value > SleepMax.value)
			{
                UnityEngine.Object.Destroy(effect);
                IsSleeping.value = false;
				Debug.Log("finishd sleeping");
				EndAction(true);
			}
			else if(sleepValue.value < SleepMax.value) 
			{
				Debug.Log("Im here");
               // effect = GameObject.Find("SleepEffect(Clone)").GetComponent<GameObject>();
                IsSleeping.value = true;
                sleepValue.value += Time.deltaTime * 5;
			}


		}
	}
}