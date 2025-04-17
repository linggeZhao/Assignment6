using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RunAway : ConditionTask {
        public BBParameter<Transform> player;
        public float triggerDistance = 6f;
		protected override bool OnCheck() {
            return Vector3.Distance(agent.transform.position, player.value.position) <= triggerDistance;
        }
	}
}