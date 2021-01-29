using ClashEntities;
using System;

namespace ClashStats.LetsPlay
{
    public class ClashEventArgs : EventArgs
    {
        public Clan SelectedClan { get; private set; }
        public string Message { get; private set; }
        public Type EventUserControlType { get; private set; }

        public ClashEventArgs(string message, Type eventUserControlType, Clan selectedClan)
        {
            if (typeof(IClashEventControl).IsAssignableFrom(eventUserControlType))
            {
                Message = message;
                EventUserControlType = eventUserControlType;
                SelectedClan = selectedClan;
            }
            else
            {
                throw new Exception("You did shit");
            }
        }
    }
}
