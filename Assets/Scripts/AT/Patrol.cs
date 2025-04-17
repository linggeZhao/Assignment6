using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Patrol : ActionTask {
        public Vector3[] patrolPoints;
        private int current = 0;
		protected override void OnUpdate() {
            if (patrolPoints.Length == 0) return;

            Vector3 target = patrolPoints[current];
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, target, 2f * Time.deltaTime);

            if (Vector3.Distance(agent.transform.position, target) < 0.5f)
            {
                current = (current + 1) % patrolPoints.Length;
            }

            EndAction(true);
        }
	}
}