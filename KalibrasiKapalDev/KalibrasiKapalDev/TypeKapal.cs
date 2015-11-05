using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapalDev
{
    class TypeKapal
    {
        private double cso;
        private string type;

        public TypeKapal(string type, double cso)
        {
            this.cso = cso;
            this.type = type;
        }

        public double Cso
        {
            get
            {
                return cso;
            }

            set
            {
                cso = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
