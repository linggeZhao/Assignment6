using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class ReturnTrue : ConditionTask {
		protected override bool OnCheck() {
			return true;
		}
	}
}