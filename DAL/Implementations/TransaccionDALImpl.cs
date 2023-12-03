using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TransaccionDALImpl : DALGenericoImpl<Transaccione>, ITransaccionDAL
    {
        public TransaccionDALImpl(RENTCARContext context) : base(context)
        {

        }
    }
}
