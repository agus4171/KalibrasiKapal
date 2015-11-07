using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapalDev
{
    class Kapal
    {
        private string nama;
        private double loa;
        private double lpp;
        private double breadth;
        private double depth;
        private double draught;
        private double speed;
        private int jumlah;
        private double jenis;
        private double dwt;
        private string muatan;

        private string hitung;
        private string nilai;
        private string satuan;

        public Kapal()
        {

        }
        public Kapal(string nama, string hitung, string nilai, string satuan)
        {
            this.nama = nama;
            this.hitung = hitung;
            this.nilai = nilai;
            this.satuan = satuan;
        }

        public string Nama
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
            }
        }

        public double Loa
        {
            get
            {
                return loa;
            }

            set
            {
                loa = value;
            }
        }

        public double Lpp
        {
            get
            {
                return lpp;
            }

            set
            {
                lpp = value;
            }
        }

        public double Breadth
        {
            get
            {
                return breadth;
            }

            set
            {
                breadth = value;
            }
        }

        public double Depth
        {
            get
            {
                return depth;
            }

            set
            {
                depth = value;
            }
        }

        public double Draught
        {
            get
            {
                return draught;
            }

            set
            {
                draught = value;
            }
        }

        public double Speed
        {
            get
            {
                return speed * 0.5144;
            }

            set
            {
                speed = value;
            }
        }

        public int Jumlah
        {
            get
            {
                return jumlah;
            }

            set
            {
                jumlah = value;
            }
        }

        public double Jenis
        {
            get
            {
                return jenis;
            }

            set
            {
                jenis = value;
            }
        }

        public double Dwt
        {
            get
            {
                return dwt / 1000;
            }

            set
            {
                dwt = value;
            }
        }

        public string Muatan
        {
            get
            {
                return muatan;
            }

            set
            {
                muatan = value;
            }
        }

        //pengolahan dari inputan
        public double setFn()
        {
            return Speed / Math.Sqrt(9.81 * Lpp);
        }
        public double setLwl()
        {
            return 1.04 * Lpp;
        }
        public double setCb()
        {
            return (-4.22) + (27.8 * (Math.Sqrt(setFn()))) - (39.1 * setFn()) + (46.4 * Math.Pow(setFn(), 3));
        }
        public double setV()
        {
            return Lpp * Breadth * Draught * setCb();
        }
        public double setD()
        {
            return setV() * 1.025;
        }

        //perhitungan volume superstructure
        public double setVForcastle()
        {
            return 0.5 * (0.1 * Lpp) * Dwt * 2.4;
        }
        public double setVPoop()
        {
            return (0.2 * Lpp) * Dwt * 2.4;
        }
        public double setVTotal()
        {
            return setVForcastle() + setVPoop();
        }

        //perhitungan volume deckhouse
        public double setVDH_ll()
        {
            return (0.15 * Lpp) * 13.00 * 2.4;
        }
        public double setVDH_lll()
        {
            return (0.1 * Lpp) * 11.00 * 2.4;
        }
        public double setVDH_lV()
        {
            return (0.075 * Lpp) * 9.00 * 2.4;
        }
        public double setVWH()
        {
            return (0.05 * Lpp) * 6.00 * 2.4;
        }
        public double setVDH()
        {
            return setVDH_ll() + setVDH_lll() + setVDH_lV() + setVWH();
        }

        //perhitungan berat baja
        public double setDa()
        {
            return Depth + (setVTotal() + setVDH()) / (Lpp * Breadth);
        }
        public double setCso()
        {
            return Jenis;
        }
        public double setU()
        {
            return Math.Log10(setD() / 100);
        }
        public double setCs()
        {
            return setCso() + (0.06 * Math.Exp(-(0.5 * setU()) + (0.1 * Math.Pow(setU(), 2.45))));
        }
        public double setWst()
        {
            return Lpp * Breadth * setDa() * setCs() * Jumlah;
        }
    }
}
