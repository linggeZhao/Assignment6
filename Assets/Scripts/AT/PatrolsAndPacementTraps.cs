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
            agent.GetComponent<Renderer>().material.color = Color.yellow;

            // random moving direction
            Vector3 dir = new Vector3(
                Mathf.PerlinNoise(Time.time, 0f) - 0.5f,
                0,
                Mathf.PerlinNoise(0f, Time.time) - 0.5f
            ).normalized;

            // using rigidbody
            if (agent.TryGetComponent<Rigidbody>(out var rb))
            {
                Vector3 nextPos = agent.transform.position + dir * moveSpeed * Time.deltaTime;
                rb.MovePosition(nextPos);
            }

            // obstacles perfabs...
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;

                Vector3 spawnPos = agent.transform.position + new Vector3(1.5f, 0f, 1.5f);

                // let the obstacle spawn on the ground,not in the sky...
                spawnPos.y = 0.5f;
                GameObject.Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}