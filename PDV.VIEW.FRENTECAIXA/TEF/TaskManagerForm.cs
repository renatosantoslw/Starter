using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA
{
	public class TaskManagerForm
	{
		//public static void Start(Action action) => Task.Factory.StartNew(action);

		public static void InvokeControlAction<T>(T control, Action<T> action) where T : Control
		{
			if (control.InvokeRequired == false) { action(control); return; }

			control.Invoke(new Action<T, Action<T>>(InvokeControlAction), new object[] { control, action });
		}
	}
}
