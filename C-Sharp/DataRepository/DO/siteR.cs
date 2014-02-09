using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.IO;
using PetaPoco;

namespace DataRepository.DO
{
  public  class siteR:site,ISite
    {

        public site getsiteByid(int id)
        {
            return site.FirstOrDefault("where siteid=@0", id);
        }
    }
}
