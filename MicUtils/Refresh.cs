using System;
using System.Collections.Generic;
using System.Text;

namespace MicUtils
{
    internal class Refresh
    {
       public static void Ref()
        {
            GorillaTagger.Instance.myRecorder.RestartRecording();
        }
    }
}
