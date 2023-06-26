using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBanco.interfaces
{
    internal interface IdataBaseRecord
    {
        string TableName { get; }
        int Id { get; }

        void Delete();
    }
}
