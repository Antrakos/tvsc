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
            SeriesManager.transaction = SeriesManager.conn.BeginTransaction();
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            SeriesManager.transaction.Commit();
        }
        public override void OnException(MethodExecutionArgs args)
        {
            SeriesManager.transaction.Rollback();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            SeriesManager.conn.Close();
        }
    }
}