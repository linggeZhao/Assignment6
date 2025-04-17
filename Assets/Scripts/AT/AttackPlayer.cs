using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AttackPlayer : ActionTask {
        public BBParameter<Transform> player;
        private Renderer rend;
        private float elapsed = 0f;
        private float flashInterval = 0.2f;
        private float duration = 3f;
        private bool red = true;

		protected override void OnExecute() {
            rend = agent.GetComponent<Renderer>();
            elapsed = 0f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (rend == null) return;

            elapsed += Time.deltaTime;
            if (elapsed >= duration)
            {
                //attacking player!!!!!!!!!!!!
                if (Vector3.Distance(agent.transform.position, player.value.position) <= 2f)
                {
                    player.value.gameObject.SetActive(false);
                    Debug.Log("Player Defeated");
                }
                EndAction(true);
            }
            else
            {
                if ((int)(elapsed / flashInterval) % 2 == 0)
                    rend.material.color = Color.red;
                else
                    rend.material.color = Color.white;
            }
        }
	}
}