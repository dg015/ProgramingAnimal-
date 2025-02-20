using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class ColourChangeAT : ConditionTask {

		//UNUSED SCRIPT

        public float ColourChng;
		public float modifier;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			//set the colour to the original colour
            ColourChng = 147;
        }

		protected override bool OnCheck() {
			//change the colour overtime by changing the variable over time
				ColourChng -= Time.deltaTime * modifier ;
			//set the new colour and devide them all by 255 since while colours in the edito go to 255 in script they stop at 1
                agent.GetComponentInChildren<Renderer>().material.color = new Color(255 / 255, ColourChng / 255, 28 / 255);
            
            if (ColourChng < 27)
            {
				//if its higher then return true

                return true;
            }
			else 
			{ 

				return false;
			}

			
			
		}
	}
}