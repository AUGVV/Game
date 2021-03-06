using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class StepGenerator
    {
        public int StepResult { get; set; } = 0;
        public int GivePcStep(int StepsCount)
        {
            byte[] PcStep = new byte[4];
            RandomNumberGenerator RandomStep = RandomNumberGenerator.Create();
            RandomStep.GetBytes(PcStep);
            StepResult = (int)(BitConverter.ToUInt32(PcStep, 0)%StepsCount);
            return StepResult;
        }
    }
}
