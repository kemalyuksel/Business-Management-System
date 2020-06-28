using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Business.Abstract
{
    public interface ICustomLogger
    {
        public void LogError(string message);
    }
}
