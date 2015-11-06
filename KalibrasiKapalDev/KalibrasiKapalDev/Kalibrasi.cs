using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalibrasiKapalDev
{
    public partial class Kalibrasi : Form
    {
        public Kalibrasi()
        {
            InitializeComponent();
            TypeKapal();
        }

        private List<TypeKapal> List = new List<TypeKapal>();
        //private List<Kapal> Kapal = new List<Kapal>();
        Fasilitas Fasil = new Fasilitas();
        Kapal KapalBaru = new Kapal();
        private string Plate;
        private string Conveyor;
        private string Blasting;
        private string Primering;
        private string Cutting;
        private string Bending10;
        private string Bender;
        private string CNC;
        private string CuttingAuto;
        private string BendRoll;
        private string Bending5;
        private string Welding;
        private string Gantry;
        private string ServiceWeld;
        private string Stiffener;
        private string Trolley;
        private string FilletWeld;
        private string NCPip;
        private string SemiAuto;
        private string PipeBend;
        private string PipeBend65;
        private string AutoGasCutt;
        private string GCrane;
        private string OHC10;
        private string T30;
        private string T15;
        private string OHC5;

        private double Wst;
        private double Cso;

        private void TypeKapal()
        {
            Jenis.Items.Clear();
            List.Add(new TypeKapal("Bulk carriers", 0.07));
            List.Add(new TypeKapal("Cargo ship (1 decks)", 0.07));
            List.Add(new TypeKapal("Cargo ship (2 decks)", 0.076));
            List.Add(new TypeKapal("Cargo ship (3 decks)", 0.082));
            List.Add(new TypeKapal("Passenger ship", 0.058));
            List.Add(new TypeKapal("Product carriers", 0.0664));
            List.Add(new TypeKapal("Reefers", 0.0609));
            List.Add(new TypeKapal("Rescue vessel", 0.0232));
            List.Add(new TypeKapal("Support vessels", 0.0974));
            List.Add(new TypeKapal("Tanker", 0.0752));
            List.Add(new TypeKapal("Train ferries", 0.065));
            List.Add(new TypeKapal("Tugs", 0.0892));
            List.Add(new TypeKapal("VLCC", 0.0645));
            foreach (var list in List)
            {
                Jenis.Items.Add(list.Type);
            }
        }

        private void HitungKapal()
        {
            BeratBaja.Items.Add("1. Nama Kapal: " + KapalBaru.Nama);
            BeratBaja.Items.Add("2. Froude Number: " + KapalBaru.setFn().ToString("0.###") +"");
            BeratBaja.Items.Add("3. Panjang Garis Air: " + KapalBaru.setLwl().ToString("0.###") +" m");
            BeratBaja.Items.Add("4. Volume Displasemen: " + KapalBaru.setV().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("5. Displasemen: " + KapalBaru.setD().ToString("0.###") +" ton");
            BeratBaja.Items.Add("6. Coeffisien Block: " + KapalBaru.setCb().ToString("0.###") +"");
            BeratBaja.Items.Add("7. Volume Forecastle: " + KapalBaru.setVForcastle().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("8. Volume Poop: " + KapalBaru.setVPoop().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("9. Volume Total(Va): " + KapalBaru.setVTotal().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("10. Volume Layer II: " + KapalBaru.setVDH_ll().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("11. Volume Layer III: " + KapalBaru.setVDH_lll().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("12. Volume Layer IV: " + KapalBaru.setVDH_lV().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("13. Volume Wheel House: " + KapalBaru.setVWH().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("14. Volume Total(Vdh): " + KapalBaru.setVDH().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("15. Tinggi Kapal(Da): " + KapalBaru.setD().ToString("0.###") + " m");
            BeratBaja.Items.Add("16. U: " + KapalBaru.setU().ToString("0.###") + "");
            BeratBaja.Items.Add("17. Cs: " + KapalBaru.setCs().ToString("0.###") + "");
            BeratBaja.Items.Add("18. Berat Baja Total: " + KapalBaru.setWst().ToString("0.###") + " ton");
            BeratBaja.Items.Add("");
        }

        private void HitungFasilitas()
        {
            Fasilitas.Items.Add("Nama Kapal: " + KapalBaru.Nama);
            Fasilitas.Items.Add("Fasilitas Utama:");
            Fasilitas.Items.Add("1. Plate Straightening Roller: " + Plate + " mesin");
            Fasilitas.Items.Add("2. Roller Conveyor: " + Conveyor + " mesin");
            Fasilitas.Items.Add("3. Shot Blasting: " + Blasting + " mesin");
            Fasilitas.Items.Add("4. Primering Machine: " + Primering+ " mesin");
            Fasilitas.Items.Add("5. Cutting Machine (NC SAFRO): " + Cutting + " mesin");
            Fasilitas.Items.Add("6. Bending Machine 1000 Ton: " + Bending10 + " mesin");
            Fasilitas.Items.Add("7. Frame Bender: " + Bender + " mesin");
            Fasilitas.Items.Add("8. CNC Cutting (Plasma): " + CNC + " mesin");
            Fasilitas.Items.Add("9. Cutting Machine (Semi Automatic): " + CuttingAuto + " mesin");
            Fasilitas.Items.Add("10. Bending Roll Machine 1500 Ton: " + BendRoll + " mesin");
            Fasilitas.Items.Add("11. Bending Machine 500 Ton: " + Bending5 + " mesin");
            Fasilitas.Items.Add("12. Welding Machine FCAW (Semi Automatic): " + Welding + " mesin");
            Fasilitas.Items.Add("13. Mobile Web Gantry: " + Gantry + " mesin");
            Fasilitas.Items.Add("14. Service Welding Gantry: " + ServiceWeld + " mesin");
            Fasilitas.Items.Add("15. Mobile Stiffener Gantry: " + Stiffener + " mesin");
            Fasilitas.Items.Add("16. Transfer Trolley: " + Trolley + " mesin");
            Fasilitas.Items.Add("17. Fillet Welding Gantry: " + FilletWeld + " mesin");
            Fasilitas.Items.Add("18. NC Pipe Bender: " + NCPip + " mesin");
            Fasilitas.Items.Add("19. Semi Auto Gas Cutting: " + SemiAuto + " mesin");
            Fasilitas.Items.Add("20. Pipe Bender 50 A: " + PipeBend + " mesin");
            Fasilitas.Items.Add("21. Pipe Bender 65 A: " + PipeBend65 + " mesin");
            Fasilitas.Items.Add("22. Auto Gas Cutting Machine: " + AutoGasCutt + " mesin");
            Fasilitas.Items.Add("Fasilitas Pendukung:");
            Fasilitas.Items.Add("1. Gantry Crane: " + GCrane + " mesin");
            Fasilitas.Items.Add("2. Over Head Crane 10 Ton: " + OHC10 + " mesin");
            Fasilitas.Items.Add("3. Transporter 300 Ton: " + T30 + " mesin");
            Fasilitas.Items.Add("4. Transporter 150 TOn: " + T15 + " mesin");
            Fasilitas.Items.Add("5. Over Head Crane 5 Ton: " + OHC5 + " mesin");
            Fasilitas.Items.Add("");
        }

        private void HitungPekerja()
        {
            Pekerja.Items.Add("Nama Kapal: " + KapalBaru.Nama);
            Pekerja.Items.Add("Fasilitas Utama:");
            Pekerja.Items.Add("Plate Straightening Roller: " + 0 + " orang");
            Pekerja.Items.Add("Roller Conveyor: " + 0 + " orang");
            Pekerja.Items.Add("Shot Blasting: " + 0 + " orang");
            Pekerja.Items.Add("Primering Machine: " + 0+ " orang");
            Pekerja.Items.Add("Cutting Machine (NC SAFRO): " + 0 + " orang");
            Pekerja.Items.Add("Bending Machine 1000 Ton: " + 0 + " orang");
            Pekerja.Items.Add("Frame Bender: " + 0 + " orang");
            Pekerja.Items.Add("CNC Cutting (Plasma): " + 0 + " orang");
            Pekerja.Items.Add("Cutting Machine (Semi Automatic): " + 0 + " orang");
            Pekerja.Items.Add("Bending Roll Machine 1500 Ton: " + 0 + " orang");
            Pekerja.Items.Add("Bending Machine 500 Ton: " + 0 + " orang");
            Pekerja.Items.Add("Welding Machine FCAW (Semi Automatic): " + 0 + " orang");
            Pekerja.Items.Add("Mobile Web Gantry: " + 0 + " orang");
            Pekerja.Items.Add("Service Welding Gantry: " + 0 + " orang");
            Pekerja.Items.Add("Mobile Stiffener Gantry: " + 0 + " orang");
            Pekerja.Items.Add("Transfer Trolley: " + 0 + " orang");
            Pekerja.Items.Add("Fillet Welding Gantry: " + 0 + " orang");
            Pekerja.Items.Add("NC Pipe Bender: " + 0 + " orang");
            Pekerja.Items.Add("Semi Auto Gas Cutting: " + 0 + " orang");
            Pekerja.Items.Add("Pipe Bender 50 A: " + 0 + " orang");
            Pekerja.Items.Add("Pipe Bender 65 A: " + 0 + " orang");
            Pekerja.Items.Add("Auto Gas Cutting Machine: " + 0 + " orang");
            Pekerja.Items.Add("Fasilitas Pendukung:");
            Pekerja.Items.Add("Gantry Crane: " + 0 + " orang");
            Pekerja.Items.Add("Over Head Crane 10 Ton: " + 0 + " orang");
            Pekerja.Items.Add("Transporter 300 Ton: " + 0 + " orang");
            Pekerja.Items.Add("Transporter 150 TOn: " + 0 + " orang");
            Pekerja.Items.Add("Over Head Crane 5 Ton: " + 0 + " orang");
            Pekerja.Items.Add("");
        }

        private void Hitung_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Nama.Text))
            {
                KapalBaru.Nama = Nama.Text;
            }
            if (!string.IsNullOrWhiteSpace(Loa.Text))
            {
                KapalBaru.Loa = double.Parse(Loa.Text);
            }
            if (!string.IsNullOrWhiteSpace(Lpp.Text))
            {
                KapalBaru.Lpp = double.Parse(Lpp.Text);
            }
            if (!string.IsNullOrWhiteSpace(Breadth.Text))
            {
                KapalBaru.Breadth = double.Parse(Breadth.Text);
            }
            if (!string.IsNullOrWhiteSpace(Depth.Text))
            {
                KapalBaru.Depth = double.Parse(Depth.Text);
            }
            if (!string.IsNullOrWhiteSpace(Draught.Text))
            {
                KapalBaru.Draught = double.Parse(Draught.Text);
            }
            if (!string.IsNullOrWhiteSpace(Speed.Text))
            {
                KapalBaru.Speed = double.Parse(Speed.Text);
            }
            if (!string.IsNullOrWhiteSpace(Dwt.Text))
            {
                KapalBaru.Dwt = double.Parse(Dwt.Text);
            }
            if (!string.IsNullOrWhiteSpace(Jumlah.Text))
            {
                KapalBaru.Jumlah = int.Parse(Jumlah.Text);
            }
            if (!string.IsNullOrWhiteSpace(Muatan.Text))
            {
                KapalBaru.Muatan = Muatan.Text;
            }
            if (!string.IsNullOrWhiteSpace(Jenis.Text))
            {
                KapalBaru.Jenis = Cso;
            }
            Wst = KapalBaru.setWst();
            //beratBaja
            HitungKapal();
            //fasilitas utama
            PlateStraightening();
            RollerConveyor();
            ShotBlasting();
            PrimeringMachine();
            CuttingMachine();
            BendingMachine10();
            FrameBender();
            CNCCutting();
            CuttingMachineAuto();
            BendRollMachine();
            BendingMachine5();
            WeldingMachine();
            MobileWebGantry();
            ServiceWelding();
            MobileStiffener();
            TransferTrolley();
            FilletWelding();
            NCPipe();
            SemiAutoGas();
            PipeBender();
            PipeBender65();
            AutoGasCutting();
            //fasilitas tambahan
            GantryCrane();
            OverHeadCrane10();
            Transporter30();
            Transporter15();
            OverHeadCrane5();
            //fasilitas      
            HitungFasilitas();
            HitungPekerja();         
        }

        private void Jenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = Jenis.SelectedItem.ToString();
            TypeKapal Kapal = List.Find(k => k.Type == type);
            Cso = Kapal.Cso;
        }

        private void PlateStraightening()
        {
            Fasil.KecMesin = 2.10;
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 7;
            if (Fasil.setPlateStr() < 1.4)
            {
                Plate = "1";
            }
            else
            {
                Plate = Math.Round(Convert.ToDecimal(Fasil.setPlateStr())).ToString();
            }
        }
        private void RollerConveyor()
        {
            Fasil.KecMesin = 2.10;
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 6;
            if (Fasil.setPlateStr() < 1.4)
            {
                Conveyor = "1";
            }
            else
            {
                Conveyor = Math.Round(Convert.ToDecimal(Fasil.setPlateStr())).ToString();
            }
        }
        private void ShotBlasting()
        {
            Fasil.KecMesin = 1.25;
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 6;
            if (Fasil.setPlateStr() < 1.4)
            {
                Blasting = "1";
            }
            else
            {
                Blasting = Math.Round(Convert.ToDecimal(Fasil.setPlateStr())).ToString();
            }
        }
        private void PrimeringMachine()
        {
            Fasil.KecMesin = 1.25;
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 6;
            if (Fasil.setPlateStr() < 1.4)
            {
                Primering = "1";
            }
            else
            {
                Primering = Math.Round(Convert.ToDecimal(Fasil.setPlateStr())).ToString();
            }
        }
        private void CuttingMachine()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setCuttMachine() < 1.4)
            {
                Cutting = "1";
            }
            else
            {
                Cutting = Math.Round(Convert.ToDecimal(Fasil.setCuttMachine())).ToString();
            }
        }
        private void BendingMachine10()
        {
            Fasil.KapaMesin = 4;
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 6;
            Fasil.BeratBaja = Wst;
            if (Fasil.setBendingMachine() < 1.4)
            {
                Bending10 = "1";
            }
            else
            {
                Bending10 = Math.Round(Convert.ToDecimal(Fasil.setBendingMachine())).ToString();
            }
        }
        private void FrameBender()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 6;
            Fasil.BeratBaja = Wst;
            if (Fasil.setCuttMachine() < 1.4)
            {
                Bender = "1";
            }
            else
            {
                Bender = Math.Round(Convert.ToDecimal(Fasil.setCuttMachine())).ToString();
            }
        }
        private void CNCCutting()
        {
            Fasil.KapaMesin = 10;
            Fasil.WaktuKerja = 3;
            Fasil.BeratBaja = Wst;
            if (Fasil.setCNCMachine() < 1.4)
            {
                CNC = "1";
            }
            else
            {
                CNC = Math.Round(Convert.ToDecimal(Fasil.setCNCMachine())).ToString();
            }
        }
        private void CuttingMachineAuto()
        {
            Fasil.KapaMesin = 5;
            Fasil.WaktuKerja = 3;
            Fasil.BeratBaja = Wst;
            if (Fasil.setCuttMachineAuto() < 1.4)
            {
                CuttingAuto = "1";
            }
            else
            {
                CuttingAuto = Math.Round(Convert.ToDecimal(Fasil.setCuttMachineAuto())).ToString();
            }
        }
        private void BendRollMachine()
        {
            Fasil.KapaMesin = 15;
            Fasil.WaktuKerja = 3;
            Fasil.BeratBaja = Wst;
            if (Fasil.setBendRollMachine() < 1.4)
            {
                BendRoll = "1";
            }
            else
            {
                BendRoll = Math.Round(Convert.ToDecimal(Fasil.setBendRollMachine())).ToString();
            }
        }
        private void BendingMachine5()
        {
            Fasil.KapaMesin = 4;
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 6;
            if (Fasil.setPlateStr() < 1.4)
            {
                Bending5 = "1";
            }
            else
            {
                Bending5 = Math.Round(Convert.ToDecimal(Fasil.setBendingMachine())).ToString();
            }
        }
        private void WeldingMachine()
        {
            Fasil.KecMesin = 0.38;
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 6;
            Fasil.BeratBaja = Wst;
            if (Fasil.setWeldingMachine() < 1.4)
            {
                Welding = "1";
            }
            else
            {
                Welding = Math.Round(Convert.ToDecimal(Fasil.setWeldingMachine())).ToString();
            }
        }
        private void MobileWebGantry()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 7;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setPlateStr() < 1.4)
            {
                Gantry = "1";
            }
            else
            {
                Gantry = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void ServiceWelding()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 5;
            Fasil.BeratBaja = Wst;
            Fasil.KapaBebanMesin = 0.5;
            if (Fasil.setPlateStr() < 1.4)
            {
                ServiceWeld = "1";
            }
            else
            {
                ServiceWeld = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void MobileStiffener()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 6;
            Fasil.BeratBaja = Wst;
            Fasil.KapaBebanMesin = 0.38;
            if (Fasil.setMobileWeb() < 1.4)
            {
                Stiffener = "1";
            }
            else
            {
                Stiffener = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void TransferTrolley()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 5;
            Fasil.KapaBebanMesin = 5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                Trolley = "1";
            }
            else
            {
                Trolley = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void FilletWelding()
        {
            Fasil.WaktuKerja = 3;
            Fasil.BebanKerja = 5;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                FilletWeld = "1";
            }
            else
            {
                FilletWeld = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void NCPipe()
        {
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 5;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                NCPip = "1";
            }
            else
            {
                NCPip = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void SemiAutoGas()
        {
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 8;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                SemiAuto = "1";
            }
            else
            {
                SemiAuto = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void PipeBender()
        {
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 7;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                PipeBend = "1";
            }
            else
            {
                PipeBend = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void PipeBender65()
        {
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 5;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                PipeBend65 = "1";
            }
            else
            {
                PipeBend65 = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void AutoGasCutting()
        {
            Fasil.WaktuKerja = 2;
            Fasil.BebanKerja = 8;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                AutoGasCutt = "1";
            }
            else
            {
                AutoGasCutt = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        //Fasilitas Pendukung
        private void GantryCrane()
        {
            Fasil.WaktuKerja = 12;
            Fasil.BebanKerja = 7;
            Fasil.KapaBebanMesin = 10;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                GCrane = "1";
            }
            else
            {
                GCrane = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void OverHeadCrane10()
        {
            Fasil.WaktuKerja = 12;
            Fasil.BebanKerja = 7;
            Fasil.KapaBebanMesin = 10;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                OHC10 = "1";
            }
            else
            {
                OHC10 = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void Transporter30()
        {
            Fasil.WaktuKerja = 12;
            Fasil.BebanKerja = 6;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                T30 = "1";
            }
            else
            {
                T30 = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void Transporter15()
        {
            Fasil.WaktuKerja = 12;
            Fasil.BebanKerja = 7;
            Fasil.KapaBebanMesin = 0.5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                T15 = "1";
            }
            else
            {
                T15 = Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
        private void OverHeadCrane5()
        {
            Fasil.WaktuKerja = 12;
            Fasil.BebanKerja = 5;
            Fasil.KapaBebanMesin = 5;
            Fasil.BeratBaja = Wst;
            if (Fasil.setMobileWeb() < 1.4)
            {
                OHC5 = "1";
            }
            else
            {
                OHC5= Math.Round(Convert.ToDecimal(Fasil.setMobileWeb())).ToString();
            }
        }
    }
}
