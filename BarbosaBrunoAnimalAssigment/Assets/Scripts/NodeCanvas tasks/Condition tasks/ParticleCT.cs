using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class ParticleCT : ConditionTask {
		public GameObject playIcon;
		public BBParameter<Transform> spawnPoint;


		//this is one of the experiments signifiers
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			//jsut spawns the object at the cats head
			GameObject Particle = Object.Instantiate(playIcon, spawnPoint.value);

        }

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			return true;
		}
	}
}