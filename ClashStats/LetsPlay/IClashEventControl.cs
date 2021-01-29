using System;

namespace ClashStats.LetsPlay
{
    public interface IClashEventControl
    {
        event EventHandler<ClashEventArgs> GoToNextScreen;
    }
}