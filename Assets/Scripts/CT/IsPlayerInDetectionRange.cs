using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsPlayerInDetectionRange : ConditionTask {
        public BBParameter<Transform> player;
        public float detectionRange = 5f;

		protected override bool OnCheck() {
            if (player == null) return false;
            return Vector3.Distance(agent.transform.position, player.value.position) <= detectionRange;
        }
	}
}