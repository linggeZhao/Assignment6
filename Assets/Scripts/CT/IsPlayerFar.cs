using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsPlayerFar : ConditionTask {
        public BBParameter<Transform> player;
        public float safeDistance = 6f;
		protected override bool OnCheck() {
            if (player == null) return false;

            return Vector3.Distance(agent.transform.position, player.value.position) > safeDistance;
        }
	}
}