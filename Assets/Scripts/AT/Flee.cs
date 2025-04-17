using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Flee : ActionTask {
        public BBParameter<Transform> player;
        public float speed = 3f;

		protected override void OnUpdate() {
            Vector3 dir = (agent.transform.position - player.value.position).normalized;
            Vector3 offset = new Vector3(Mathf.Sin(Time.time * 3), 0, Mathf.Cos(Time.time * 3)) * 0.5f;
            agent.transform.position += (dir + offset).normalized * speed * Time.deltaTime;

            EndAction(true);
        }
	}
}