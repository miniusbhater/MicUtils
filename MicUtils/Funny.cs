using Photon.Voice.PUN;
using POpusCodec.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicUtils
{
    internal class Funny
    {
        public static void Ena()
        {
            PhotonVoiceNetwork.Instance.PrimaryRecorder.SamplingRate = SamplingRate.Sampling08000;
            PhotonVoiceNetwork.Instance.PrimaryRecorder.RestartRecording();
        }

        public static void Dis() {
            PhotonVoiceNetwork.Instance.PrimaryRecorder.StopRecording();
            PhotonVoiceNetwork.Instance.PrimaryRecorder.SamplingRate = SamplingRate.Sampling16000;
            PhotonVoiceNetwork.Instance.PrimaryRecorder.StartRecording();
        }


    }
}
