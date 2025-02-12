using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	

	public class ColourChangeAT : ConditionTask {


        public float ColourChng;
		public float modifier;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            ColourChng = 147;
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			// original colour 
			
			
				ColourChng -= Time.deltaTime * modifier ;
                agent.GetComponentInChildren<Renderer>().material.color = new Color(255 / 255, ColourChng / 255, 28 / 255);
            
            if (ColourChng < 27)
            {
                return true;
            }
			else { return false; }

			
			
		}
	}
}