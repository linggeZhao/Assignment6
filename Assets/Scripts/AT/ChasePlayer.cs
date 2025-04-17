using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChasePlayer : ActionTask {
        public BBParameter<Transform> player;
        public float speed = 3f;

		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (player == null) EndAction(false);

            Vector3 direction = (player.value.position - agent.transform.position).normalized;
            agent.transform.position += direction * speed * Time.deltaTime;
            EndAction(true);
        }
	}
}