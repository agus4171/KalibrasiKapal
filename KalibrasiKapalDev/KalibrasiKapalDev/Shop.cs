using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalibrasiKapalDev
{
    class Shop
    {
        //mesin
        private double kecMesin;
        private double legLength;
        private double panjangLas;
        private double elektroda;
        private double jamMesin;
        private double beratbaja;
        private double waktuPenyelesaianAss;
        private double waktuMesin;
        private double kapaMesin;
        private double panjangPelat;
        private double beratPelat;
        private double bebanMesin;
        private double beratBajaLbr;


        //pekerja
        private double waktuKerja;
        private double operasiMesin;
        private double jamOrang;
        private double jamOrangMnt;
        private double kapaBengkel;
        private double jumPekerja;
        private double totalPekerja;

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

        public double LegLength
        {
            get
            {
                return legLength;
            }

            set
            {
                legLength = value;
            }
        }

        public double PanjangLas
        {
            get
            {
                return panjangLas;
            }

            set
            {
                panjangLas = value;
            }
        }

        public double Elektroda
        {
            get
            {
                return elektroda;
            }

            set
            {
                elektroda = value;
            }
        }

        public double JamMesin
        {
            get
            {
                return jamMesin*60;
            }

            set
            {
                jamMesin = value;
            }
        }

        public double WaktuKerja
        {
            get
            {
                return waktuKerja;
            }

            set
            {
                waktuKerja = value;
            }
        }

        public double OperasiMesin
        {
            get
            {
                return operasiMesin;
            }

            set
            {
                operasiMesin = value;
            }
        }

        public double JamOrang
        {
            get
            {
                return jamOrang;
            }

            set
            {
                jamOrang = value;
            }
        }

        public double KapaBengkel
        {
            get
            {
                return kapaBengkel;
            }

            set
            {
                kapaBengkel = value;
            }
        }

        public double JumPekerja
        {
            get
            {
                return jumPekerja;
            }

            set
            {
                jumPekerja = value;
            }
        }

        public double TotalPekerja
        {
            get
            {
                return totalPekerja;
            }

            set
            {
                totalPekerja = value;
            }
        }

        public double Beratbaja
        {
            get
            {
                return beratbaja;
            }

            set
            {
                beratbaja = value;
            }
        }

        public double WaktuPenyelesaianAss
        {
            get
            {
                return waktuPenyelesaianAss;
            }

            set
            {
                waktuPenyelesaianAss = value;
            }
        }

        public double WaktuMesin
        {
            get
            {
                return waktuMesin;
            }

            set
            {
                waktuMesin = value;
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

        public double PanjangPelat
        {
            get
            {
                return panjangPelat;
            }

            set
            {
                panjangPelat = value;
            }
        }

        public double BeratPelat
        {
            get
            {
                return beratPelat;
            }

            set
            {
                beratPelat = value;
            }
        }

        public double BebanMesin
        {
            get
            {
                return bebanMesin*60;
            }

            set
            {
                bebanMesin = value;
            }
        }

        public double JamOrangMnt
        {
            get
            {
                return jamOrangMnt*60;
            }

            set
            {
                jamOrangMnt = value;
            }
        }

        public double BeratBajaLbr
        {
            get
            {
                return beratBajaLbr;
            }

            set
            {
                beratBajaLbr = value;
            }
        }

        //assembly shop
        public decimal FCAW(){
            if( ((Beratbaja*(LegLength * PanjangLas * Elektroda)) /(WaktuKerja*JamMesin*KecMesin*0.8)) < 1.4){
                return 1;
            }
            else{
                return Math.Round(Convert.ToDecimal(((Beratbaja * (LegLength * PanjangLas * Elektroda)) / (WaktuKerja * JamMesin * KecMesin * 0.8))));
            }
        }
        public decimal PekerjaFCAW(){
            return Math.Ceiling(Convert.ToDecimal((Beratbaja * 1000 / WaktuKerja) / (OperasiMesin * JamOrang * KapaBengkel * WaktuKerja)));
        }
        public decimal TotalPekerjaFCAW(){
            return FCAW() * PekerjaFCAW();
        }

        public decimal Crane(){
            if ((Beratbaja / (WaktuKerja * 60 * 0.8 * KapaMesin)) < 1.4){
                return 1;
            }
            else{
                return Math.Round(Convert.ToDecimal(Beratbaja / (WaktuKerja * 60 * 0.8 * KapaMesin)));
            }
        }
        public decimal PekerjaCrane(){
            return Math.Ceiling(Convert.ToDecimal((Beratbaja * 1000 / WaktuKerja) / (OperasiMesin * JamOrang * KapaBengkel * WaktuKerja)));
        }
        public decimal TotalPekerjaCrane()
        {
            return Crane() * PekerjaCrane();
        }

        //preparation shop
        //4 mesin atas
        public double LbrPlate(){
            return KecMesin * BebanMesin / 9;
        }

        public double KgPlate(){
            return BeratPelat * LbrPlate() * 1000;
        }

        public decimal Plate()
        {
            if ((KgPlate()/(BebanMesin*BebanMesin*WaktuKerja*0.8)) < 1.4){
                return 1;
            }
            else{
                return Math.Round(Convert.ToDecimal((KgPlate() / (BebanMesin * BebanMesin* WaktuKerja * 0.8))));
            }
        }
        public decimal PekerjaPlate()
        {
            return Math.Ceiling(Convert.ToDecimal(KgPlate()/(WaktuKerja*KapaBengkel*JamOrang*60)));
        }
        //2 mesin selanjutnya
        public decimal Gantry(){
            if (((Beratbaja / WaktuKerja) / (WaktuMesin * JamOrang * WaktuKerja * 0.8)) < 1.4){
                return 1;
            }
            else{
                return Math.Round(Convert.ToDecimal(((Beratbaja / WaktuKerja) / (WaktuMesin * JamOrang * WaktuKerja * 0.8))));
            }
        }
        public decimal PekerjaGantry(){
            return Math.Ceiling(Convert.ToDecimal((Beratbaja / WaktuKerja) * 1000 / (JamOrang * WaktuKerja * 60 * KapaBengkel)));
        }
        //fabrication shop
        public Double LbrBaja(){
            return Beratbaja / BeratBajaLbr;
        }
        public decimal NC(){
            if (((Beratbaja/BeratBajaLbr)/(WaktuKerja*JamOrang*(JamMesin/KapaMesin)*BeratBajaLbr*0.8)) < 1.4){
                return 1;
            }
            else{
                return Math.Round(Convert.ToDecimal(((Beratbaja / BeratBajaLbr) / (WaktuKerja * JamOrang * (JamMesin / KapaMesin) * BeratBajaLbr * 0.8))));
            }
        }
        public decimal PekerjaNC(){
            return Math.Ceiling(Convert.ToDecimal((Beratbaja*1000/WaktuKerja)/(WaktuKerja*OperasiMesin*JamOrang*KapaBengkel)));
        }
        public decimal TotalPekerjaNC(){
            return NC() * PekerjaNC()
;        }

        //pipe shop
        public double MRoller(){
            return KecMesin * BebanMesin;
        }
        /*public decimal Roller(){
            if (()< 1.4)
            {
                return 1;
            }
            else
            {
                return Math.Round(Convert.ToDecimal());
            }
        }*/

    }
}
