using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intelligent_robot_patrol
{
    class BoundAsyncROS
    {
        //We expect an exception here, so tell VS to ignore
        //[DebuggerHidden]
        public void Error()
        {
            throw new Exception("This is an exception coming from C#");
        }
        public string getros()
        {
            return Robot.ip;
        }

        public void say(string message)
        {
            MessageBox.Show(message);
        }
    }
}
