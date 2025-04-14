using System;
using System.Collections.Generic;
using System.Text;

namespace MicUtils
{
    internal class EnableDisable
    {
        public static void Dis()
        {
            GorillaTagger.Instance.myRecorder.StopRecording();
        }

        public static void Ena()
        {
            GorillaTagger.Instance.myRecorder.StartRecording();
        }
    }
}
