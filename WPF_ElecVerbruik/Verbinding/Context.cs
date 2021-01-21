using System;
using System.Collections.Generic;
using System.Text;

using BusinessLayer.Manager;

namespace WPF_ElecVerbruik.Verbinding
{
    public class Context
    {
        public static LeverancierManager LeverancierManager { get; } = new LeverancierManager();
    }
}
