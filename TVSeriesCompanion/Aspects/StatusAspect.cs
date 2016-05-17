using System;
using PostSharp.Aspects;
using TVSeriesCompanion.Views;

namespace TVSeriesCompanion.Aspects
{
    [Serializable]
    public sealed class StatusAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ((MainForm) args.Instance).SetStatus(true);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((MainForm) args.Instance).SetStatus(false);
        }
    }
}