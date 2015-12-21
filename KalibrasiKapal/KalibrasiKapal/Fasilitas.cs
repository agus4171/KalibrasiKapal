using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapal
{
    class Fasilitas
    {
        //satuan dalam bulan
        private int preShop;
        private int fabShop;
        private int suaShop;
        private int assShop;
        private int pipeShop;

        //1 bulan = 20 hari
        private int bulan;
        private int hari;
        private int jam;

        //nilai dari user
        private double kecMesin;
        private double waktuKerja;
        private double bebanKerja;
        private double kapaMesin;
        private double kapaBebanMesin;
        private double kebMesin;
        private double waktuPenyelesaian;
        private double bajaHari_D;
        private double bajaHari_lbr;
        private double kapaMesin_D;
        private double wstKapal;

        private double beratBajaLbr = 4.2;

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
                return waktuKerja * Bulan;
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

        public double KebMesin
        {
            get
            {
                return kebMesin;
            }

            set
            {
                kebMesin = value;
            }
        }

        public double WaktuPenyelesaian
        {
            get
            {
                return waktuPenyelesaian;
            }

            set
            {
                waktuPenyelesaian = value;
            }
        }

        public int PreShop
        {
            get
            {
                return 2;
            }

            set
            {
                preShop = value;
            }
        }

        public int FabShop
        {
            get
            {
                return 3;
            }

            set
            {
                fabShop = value;
            }
        }

        public int SuaShop
        {
            get
            {
                return 3;
            }

            set
            {
                suaShop = value;
            }
        }

        public int AssShop
        {
            get
            {
                return 3;
            }

            set
            {
                assShop = value;
            }
        }

        public int PipeShop
        {
            get
            {
                return 2;
            }

            set
            {
                pipeShop = value;
            }
        }

        public int Bulan
        {
            get
            {
                return 20;
            }

            set
            {
                bulan = value;
            }
        }

        public int Hari
        {
            get
            {
                return hari;
            }

            set
            {
                hari = value;
            }
        }

        public int Jam
        {
            get
            {
                return jam;
            }

            set
            {
                jam = value;
            }
        }

        public double BajaHari_D
        {
            get
            {
                return WstKapal / WaktuKerja;
            }

            set
            {
                bajaHari_D = value;
            }
        }

        public double KapaMesin_D
        {
            get
            {
                return bajaHari_D / WaktuKerja;
            }

            set
            {
                kapaMesin_D = value;
            }
        }

        public double WstKapal
        {
            get
            {
                return wstKapal;
            }

            set
            {
                wstKapal = value;
            }
        }

        public double BajaHari_lbr
        {
            get
            {
                return KapaMesin * beratBajaLbr;
            }

            set
            {
                bajaHari_lbr = value;
            }
        }

        public double setPlateStr()
        {
            return (KecMesin * BebanKerja) / (WaktuKerja * 60 * 0.8);
        }

        public double setCuttMachine()
        {
            return (BajaHari_D * KapaMesin_D) / (WaktuKerja * 60 * 0.8);
        }

        public double setCNC_Machine()
        {
            return WstKapal / WaktuKerja * 0.8 / BajaHari_lbr;
        }

        public double setCuttMachineAuto()
        {
            return BajaHari_D / BajaHari_lbr;
        }

        public double setBendRollMachine()
        {
            return (WstKapal / WaktuKerja * 0.8) / (KapaMesin * beratBajaLbr);
        }
        public double setWeldingMachine()
        {
            return WaktuKerja * BebanKerja * 0.8 / (BajaHari_D * KecMesin * 60);
        }
        public double setMobileWeb()
        {
            return BajaHari_D * BajaHari_D / BebanKerja / (WaktuKerja * 60 * 0.8 * KapaBebanMesin);
        }
    }
}
