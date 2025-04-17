using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolsAndPacementTraps : ActionTask {
        public GameObject obstaclePrefab;
        public float moveSpeed = 2f;
        public float interval = 3f;
        private float timer = 0f;

		protected override void OnUpdate() {
            Vector3 dir = new Vector3(Mathf.PerlinNoise(Time.time, 0f) - 0.5f, 0, Mathf.PerlinNoise(0f, Time.time) - 0.5f);
            agent.transform.position += dir.normalized * moveSpeed * Time.deltaTime;

            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;
                GameObject.Instantiate(obstaclePrefab, agent.transform.position + Vector3.forward * 1.5f, Quaternion.identity);
            }
            EndAction(true);
        }
	}
}