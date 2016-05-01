using System;
using PostSharp.Aspects;
using TVSeriesCompanion.Controllers;

namespace TVSeriesCompanion.Aspects
{
    [Serializable]
    public sealed class SqlConnectionAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            SeriesManager.conn.Open();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            SeriesManager.conn.Close();
        }
    }
}