using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapal
{
    class TypeKapal
    {
        private double cso;
        private string jnsKapal;

        public TypeKapal(string jnsKapal, double cso)
        {
            this.cso = cso;
            this.jnsKapal = jnsKapal;
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

        public string JnsKapal
        {
            get
            {
                return jnsKapal;
            }

            set
            {
                jnsKapal = value;
            }
        }
    }

}
