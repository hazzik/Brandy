using System;
using NHibernate;

namespace Brandy.NHibernate
{
    public interface ISessionProvider : IDisposable
	{
		ISession CurrentSession { get; }
		void PreventCommit();
	}
}
