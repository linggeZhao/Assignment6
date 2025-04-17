using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsPlayerInAttackRange : ConditionTask {
        public BBParameter<Transform> player;
        public float attackRange = 2f;

		protected override bool OnCheck() {
            return Vector3.Distance(agent.transform.position, player.value.position) <= attackRange;
        }
	}
}