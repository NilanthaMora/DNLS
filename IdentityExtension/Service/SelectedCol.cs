using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Service
{
    public class SelectedCol
    {
        List<string> colSet = new List<string>() { };

        public SelectedCol() { }

        public List<string> getCol()
        {
            return colSet;
        }

        public void setCol(string equipment)
        {
            colSet.Add(equipment);
        }

    }
}
