using System;
using System.Data.SQLite;
using PostSharp.Aspects;
using TVSeriesCompanion.Controllers;

namespace TVSeriesCompanion.Aspects
{
    [Serializable]
    public sealed class SqlConnectionAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private SQLiteTransaction _transaction;
        public override void OnEntry(MethodExecutionArgs args)
        {
            SeriesManager.conn.Open();
            _transaction = SeriesManager.conn.BeginTransaction();
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _transaction.Commit();
        }
        public override void OnException(MethodExecutionArgs args)
        {
            _transaction.Rollback();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            SeriesManager.conn.Close();
        }
    }
}