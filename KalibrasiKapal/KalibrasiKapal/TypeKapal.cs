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
        private string typeKapal;

        public TypeKapal(string type, double cso)
        {
            this.typeKapal = type;
            this.cso = cso;
        }

        public double CSO
        {
            get { return cso; }
            set { cso = value; }
        }

        public string Kapal
        {
            get { return typeKapal; }
            set { typeKapal = value; }
        }
        
        /*public TypeKapal(string type)
        {
            if(type.Equals("Bulk carriers"))
            {
                cso = 0.07;
            }
            else if (type.Equals("Cargo ship (1 decks)"))
            {
                cso = 0.07;
            }
            else if (type.Equals("Cargo ship (2 decks)"))
            {
                cso = 0.076;
            }
            else if (type.Equals("Cargo ship (3 decks)"))
            {
                cso = 0.082;
            }
            else if (type.Equals("Passenger ship"))
            {
                cso = 0.058;
            }
            else if (type.Equals("Product carriers"))
            {
                cso = 0.0664;
            }
            else if (type.Equals("Reefers"))
            {
                cso = 0.0609;
            }
            else if (type.Equals("Rescue vessel"))
            {
                cso = 0.0232;
            }
            else if (type.Equals("Support vessels"))
            {
                cso = 0.0974;
            }
            else if (type.Equals("Tanker"))
            {
                cso = 0.0752;
            }
            else if (type.Equals("Train ferries"))
            {
                cso = 0.065;
            }
            else if (type.Equals("Tugs"))
            {
                cso = 0.0892;
            }
            else if(type.Equals("VLCC"))
            {
                cso = 0.0645;
            }
            return cso;
        }*/        
    }

}
