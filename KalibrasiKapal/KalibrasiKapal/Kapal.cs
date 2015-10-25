using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapal
{
    class Kapal
    {
        private double kapal = 9602.7891;
        private double loa;
        private double lpp;
        private double breadth;
        private double depth;
        private double draught;
        private double speed;
        private int jml_kapal;
        private double typeKapal;
        private double dwt;
        private string jns_muatan;

        private decimal d;

        //set nilai inputan
        public void setLoa(double loaInp)
        {
            loa = loaInp;
        }
        public void setLpp(double lppInp)
        {
            lpp = lppInp;
        }
        public void setBreadth(double breadthInp)
        {
            breadth = breadthInp;
        }
        public void setDepth(double depthInp)
        {
            depth = depthInp;
        }
        public void setDraught(double draughtInp)
        {
            draught = draughtInp;
        }
        public void setSpeed(double speedInp)
        {
            speed = speedInp;
        }
        public void setDwt(double dwtInp)
        {
            dwt = dwtInp / 1000;
        }
        public void setTypeKapal(double typeKapalInp)
        {
            typeKapal = typeKapalInp;
        }

        //pengolahan dari inputan
        public double getFn()
        {
            return speed / Math.Sqrt(9.81 * lpp);
        }
        public double getLwl()
        {
            return 1.04 * lpp;
        }
        public double getCb()
        {
            return (-4.22) + (27.8 * (Math.Sqrt(getFn()))) - (39.1 * getFn()) + (46.4 * Math.Pow(getFn(), 3));
        }
        public double getV()
        {
            return lpp * breadth * draught * getCb();
        }
        public double getD()
        {
            return getV() * 1.025;
        }

        //perhitungan volume superstructure
        public double getVForcastle()
        {
            return 0.5 * (0.1 * lpp) * dwt * 2.4;
        }
        public double getVPoop()
        {
            return (0.2 * lpp) * dwt * 2.4;
        }
        public double getVTotal()
        {
            return getVForcastle() + getVPoop();
        }

        //perhitungan volume deckhouse
        public double getVDH_ll()
        {
            return (0.15 * lpp) * 13.00 * 2.4;
        }
        public double getVDH_lll()
        {
            return (0.1 * lpp) * 11.00 * 2.4;
        }
        public double getVDH_lV()
        {
            return (0.075 * lpp) * 9.00 * 2.4;
        }
        public double getVWH()
        {
            return (0.05 * lpp) * 6.00 * 2.4;
        }
        public double getVDH()
        {
            return getVDH_ll() + getVDH_lll() + getVDH_lV() + getVWH();
        }

        //perhitungan berat baja
        public double getDa()
        {
            return depth + (getVTotal() + getVDH()) / (lpp * breadth);
        }
        public double getCso( )
        {
            return 0.0752;
        }
        public double getU()
        {
            return Math.Log10(kapal / 100);
        }
        public double getCs()
        {
            return getCso() + (0.06 * Math.Exp(-(0.5 * getU()) + (0.1 * Math.Pow(getU(), 2.45))));
        }
        public double getWst()
        {
            return lpp * breadth * getDa() * getCs();
        }
    }
}
