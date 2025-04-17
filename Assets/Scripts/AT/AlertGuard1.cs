using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AlertGuard1 : ActionTask {
        public BBParameter<Transform> guard1;

		protected override void OnUpdate() {
            if (guard1 != null)
            {
                Renderer r = guard1.value.GetComponent<Renderer>();
                if (r != null)
                    r.material.color = Color.cyan;
            }

            EndAction(true);
        }
	}
}