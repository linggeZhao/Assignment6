using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsGuard1Reachable : ConditionTask {
        public BBParameter<Transform> guard1;
        public float maxReachDistance = 3f;
		protected override bool OnCheck() {
            if (guard1 == null) return false;

            return Vector3.Distance(agent.transform.position, guard1.value.position) <= maxReachDistance;
        }
	}
}