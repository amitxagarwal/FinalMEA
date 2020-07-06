using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Momentum.Mea.Funcapp.Tests
{
    public class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope() { }

        public void Dispose() { }
    }
}
