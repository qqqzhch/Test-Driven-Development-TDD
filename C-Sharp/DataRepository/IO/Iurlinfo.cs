using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
namespace DataRepository.IO
{
   public interface Iurlinfo
    {
       urlinfo GeturlinfoByCode(long code);
    }
}
