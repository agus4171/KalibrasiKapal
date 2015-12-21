using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapalDev
{
    class KapasitasBengkel
    {
        //waktu pengerjaan kapal
        private int prepShop;
        private int fabShop;
        private int subAssShop;
        private int assShop;
        private int pipeShop;
        private int jamOrg;
        private int bulan;
        private int totalBulan;
        private int totalHari;
        private int totalJam;
        //kapasitas bengkel produksi
        private int prepShopB;
        private int fabShopB;
        private int subAssShopB;
        private int assShopB;
        private int pipeShopB;

        public int PrepShop
        {
            get
            {
                return prepShop;
            }

            set
            {
                prepShop = value;
            }
        }

        public int FabShop
        {
            get
            {
                return fabShop;
            }

            set
            {
                fabShop = value;
            }
        }

        public int SubAssShop
        {
            get
            {
                return subAssShop;
            }

            set
            {
                subAssShop = value;
            }
        }

        public int AssShop
        {
            get
            {
                return assShop;
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
                return pipeShop;
            }

            set
            {
                pipeShop = value;
            }
        }

        public int JamOrg
        {
            get
            {
                return jamOrg;
            }

            set
            {
                jamOrg = value;
            }
        }

        public int Bulan
        {
            get
            {
                return bulan;
            }

            set
            {
                bulan = value;
            }
        }

        public int TotalBulan
        {
            get
            {
                return prepShop + fabShop + subAssShop + assShop + pipeShop;
            }

            set
            {
                totalBulan = value;
            }
        }

        public int TotalHari
        {
            get
            {
                return TotalBulan * Bulan;
            }

            set
            {
                totalHari = value;
            }
        }

        public int TotalJam
        {
            get
            {
                return TotalHari * JamOrg;
            }

            set
            {
                totalJam = value;
            }
        }

        public int PrepShopB
        {
            get
            {
                return prepShopB;
            }

            set
            {
                prepShopB = value;
            }
        }

        public int FabShopB
        {
            get
            {
                return fabShopB;
            }

            set
            {
                fabShopB = value;
            }
        }

        public int SubAssShopB
        {
            get
            {
                return subAssShopB;
            }

            set
            {
                subAssShopB = value;
            }
        }

        public int AssShopB
        {
            get
            {
                return assShopB;
            }

            set
            {
                assShopB = value;
            }
        }

        public int PipeShopB
        {
            get
            {
                return pipeShopB;
            }

            set
            {
                pipeShopB = value;
            }
        }

        public double TotalPengerjaan()
        {
            return TotalBulan;
        }
        public double TotalPengerjaanJam()
        {
            return TotalJam;
        }
        public double TotalPengerjaanHari()
        {
            return TotalHari;
        }
    }
}
