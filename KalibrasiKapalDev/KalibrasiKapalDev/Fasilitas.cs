using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapalDev
{
    class Fasilitas
    {
        private double kecMesin;
        private double waktuKerja;
        private double bebanKerja;
        private double kapaMesin;
        private double kapaBebanMesin;
        private double bajaHariD;
        private double bajaHariLbr;
        private double kapaMesinD;
        private double beratBaja;
        private double beratBajaLbr;

        public double KecMesin
        {
            get
            {
                return kecMesin;
            }

            set
            {
                kecMesin = value;
            }
        }

        public double WaktuKerja
        {
            get
            {
                return waktuKerja * 20;
            }

            set
            {
                waktuKerja = value;
            }
        }

        public double BebanKerja
        {
            get
            {
                return bebanKerja * 60;
            }

            set
            {
                bebanKerja = value;
            }
        }

        public double KapaMesin
        {
            get
            {
                return kapaMesin;
            }

            set
            {
                kapaMesin = value;
            }
        }

        public double KapaBebanMesin
        {
            get
            {
                return kapaBebanMesin;
            }

            set
            {
                kapaBebanMesin = value;
            }
        }

        public double BajaHariD
        {
            get
            {
                return BeratBaja / WaktuKerja;
            }

            set
            {
                bajaHariD = value;
            }
        }

        public double BajaHariLbr
        {
            get
            {
                return KapaMesin * BeratBajaLbr;
            }

            set
            {
                bajaHariLbr = value;
            }
        }

        public double KapaMesinD
        {
            get
            {
                return BajaHariD / WaktuKerja;
            }

            set
            {
                kapaMesinD = value;
            }
        }

        public double BeratBaja
        {
            get
            {
                return beratBaja;
            }

            set
            {
                beratBaja = value;
            }
        }

        public double BeratBajaLbr
        {
            get
            {
                return 2.8;
            }

            set
            {
                beratBajaLbr = value;
            }
        }

        public double setPlateStr()
        {
            return (KecMesin * BebanKerja) / (WaktuKerja * 60 * 0.8);
        }

        public double setCuttMachine()
        {
            return (BajaHariD * KapaMesinD) / (WaktuKerja * 60 * 0.8);
        }

        public double setBendingMachine()
        {
            return BeratBaja / (BajaHariLbr * (BebanKerja / 60) * 0.8) / WaktuKerja;
        }

        public double setCNCMachine()
        {
            return BeratBaja / WaktuKerja * 0.8 / BajaHariLbr;
        }

        public double setCuttMachineAuto()
        {
            return (BajaHariD / BajaHariLbr) * 0.8;
        }

        public double setBendRollMachine()
        {
            return (BeratBaja / WaktuKerja * 0.8) / (KapaMesin * BeratBajaLbr);
        }
        public double setWeldingMachine()
        {
            return WaktuKerja * BebanKerja * 0.8 / (BajaHariD * KecMesin * 60);
        }
        public double setMobileWeb()
        {
            return BajaHariD * BajaHariD / BebanKerja / (WaktuKerja * 60 * 0.8 * KapaBebanMesin);
        }
    }
}
