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
        public Kalibrasi(){
            InitializeComponent();
            TypeKapal();
        }
        
        Fasilitas Fasil = new Fasilitas();
        Kapal KapalBaru = new Kapal();
        KapasitasBengkel KapaBengkel = new KapasitasBengkel();
        Shop AssShop = new Shop();
        Shop PreShop = new Shop();
        Shop SubAssShop = new Shop();
        Shop FabShop = new Shop();
        Shop PipeShop = new Shop();

        private List<TypeKapal> List = new List<TypeKapal>();
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
        private string text = "1";

        private void TypeKapal(){
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
            foreach (var list in List){
                Jenis.Items.Add(list.Type);
            }
        }

        /*private void HitungKapal(){
            BeratBaja.Items.Add("1. Nama Kapal: " + KapalBaru.Nama);
            BeratBaja.Items.Add("2. Froude Number: " + KapalBaru.Fn().ToString("0.###") +"");
            BeratBaja.Items.Add("3. Panjang Garis Air: " + KapalBaru.Lwl().ToString("0.###") +" m");
            BeratBaja.Items.Add("4. Volume Displasemen: " + KapalBaru.V().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("5. Displasemen: " + KapalBaru.D().ToString("0.###") +" ton");
            BeratBaja.Items.Add("6. Coeffisien Block: " + KapalBaru.Cb().ToString("0.###") +"");
            BeratBaja.Items.Add("7. Volume Forecastle: " + KapalBaru.VForcastle().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("8. Volume Poop: " + KapalBaru.VPoop().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("9. Volume Total(Va): " + KapalBaru.VTotal().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("10. Volume Layer II: " + KapalBaru.VDH_ll().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("11. Volume Layer III: " + KapalBaru.VDH_lll().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("12. Volume Layer IV: " + KapalBaru.VDH_lV().ToString("0.###") +" m^3");
            BeratBaja.Items.Add("13. Volume Wheel House: " + KapalBaru.VWH().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("14. Volume Total(Vdh): " + KapalBaru.VDH().ToString("0.###") + " m^3");
            BeratBaja.Items.Add("15. Tinggi Kapal(Da): " + KapalBaru.D().ToString("0.###") + " m");
            BeratBaja.Items.Add("16. U: " + KapalBaru.U().ToString("0.###") + "");
            BeratBaja.Items.Add("17. Cs: " + KapalBaru.Cs().ToString("0.###") + "");
            BeratBaja.Items.Add("18. Berat Baja Total: " + KapalBaru.Wst().ToString("0.###") + " ton");
            BeratBaja.Items.Add("");
        }

        private void HitungFasilitas(){
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

        private void HitungPekerja(){
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
        }*/

        private void Hitung_Click_1(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(Nama.Text)){
                KapalBaru.Nama = Nama.Text;
            }

            if (!string.IsNullOrWhiteSpace(Loa.Text)){
                if (double.Parse(Loa.Text) < 100.0 || double.Parse(Loa.Text) > 200.0){
                    MessageBox.Show("LOA tidak sesuai, Tidak dapat dihitung");
                    return;
                }
                else{
                    KapalBaru.Loa = double.Parse(Loa.Text);
                }
            }

            if (!string.IsNullOrWhiteSpace(Lpp.Text)){
                if (double.Parse(Lpp.Text) < 100.0 || double.Parse(Lpp.Text) > 200.0){
                    MessageBox.Show("LPP tidak sesuai, Tidak dapat dihitung");
                    return;
                }
                else{
                    KapalBaru.Lpp = double.Parse(Lpp.Text);
                }
            }

            if (!string.IsNullOrWhiteSpace(Breadth.Text)){
                KapalBaru.Breadth = double.Parse(Breadth.Text);
            }

            if (!string.IsNullOrWhiteSpace(Depth.Text)){
                KapalBaru.Depth = double.Parse(Depth.Text);
            }

            if (!string.IsNullOrWhiteSpace(Draught.Text)){
                KapalBaru.Draught = double.Parse(Draught.Text);
            }

            if (!string.IsNullOrWhiteSpace(Speed.Text)){
                KapalBaru.Speed = double.Parse(Speed.Text);
            }

            if (!string.IsNullOrWhiteSpace(Dwt.Text)){
                if (Int32.Parse(Dwt.Text) < 10000 || Int32.Parse(Dwt.Text) > 30000){
                    MessageBox.Show("DWT tidak sesuai, Tidak dapat dihitung");
                    return;
                }
                else{
                    KapalBaru.Dwt = int.Parse(Dwt.Text);
                }
            }

            if (!string.IsNullOrWhiteSpace(Jumlah.Text)){
                if(Jumlah.Text == ""){
                    KapalBaru.Jumlah = 1;
                }
                else{
                    KapalBaru.Jumlah = int.Parse(Jumlah.Text);
                }
            }

            if (!string.IsNullOrWhiteSpace(Muatan.Text)){
                KapalBaru.Muatan = Muatan.Text;
            }

            if (!string.IsNullOrWhiteSpace(Jenis.Text)){
                KapalBaru.Jenis = Cso;
            }

            if (Jenis.SelectedItem == null){
                MessageBox.Show("Jenis Kapal Belum dipilih, Tidak dapat dihitung");
                return;
            }

            //Jenis_SelectedIndexChanged(object sender, EventArgs e);

            fn.Text = KapalBaru.Fn().ToString("0.###");
            lwl.Text = KapalBaru.Lwl().ToString("0.###");
            v.Text = KapalBaru.V().ToString("0.###");
            d.Text = KapalBaru.D().ToString("0.###");
            cb.Text = KapalBaru.Cb().ToString("0.###");

            vf.Text = KapalBaru.VForcastle().ToString("0.###");
            vp.Text = KapalBaru.VPoop().ToString("0.###");
            va.Text = KapalBaru.VTotal().ToString("0.###");
            vdhb.Text = KapalBaru.VDH_ll().ToString("0.###");
            vdhc.Text = KapalBaru.VDH_lll().ToString("0.###");
            vdhd.Text = KapalBaru.VDH_lV().ToString("0.###");
            vdhw.Text = KapalBaru.VWH().ToString("0.###");
            vdh.Text = KapalBaru.VDH().ToString("0.###");

            csobaja.Text = KapalBaru.Cso().ToString("0.####");
            u.Text = KapalBaru.U().ToString("0.###");
            cs.Text = KapalBaru.Cs().ToString("0.###");
            kapalbaja.Text = KapalBaru.D().ToString("0.###");
            wstbaja.Text = KapalBaru.Wst().ToString("0.###");
            totalBaja.Text = KapalBaru.Wst().ToString("0.###");

            //d.Text = KapalBaru.D().ToString("0.###");
            Wst = KapalBaru.Wst();
            //beratBaja
            //HitungKapal();
            //fasilitas utama
            /*PlateStraightening();
            RollerConveyor();
            ShotBlasting();
            PrimeringMachine();
            CuttingMachine();
            BendingMachine10();
            FrameBender();
            CNCCutting();
            CuttingMachineAuto();
            //BendRollMachine();
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
            //HitungFasilitas();
            //HitungPekerja();*/
        }

        private void Jenis_SelectedIndexChanged(object sender, EventArgs e){
            string type = Jenis.SelectedItem.ToString();
            TypeKapal Kapal = List.Find(k => k.Type == type);
            Cso = Kapal.Cso;
        }

        private void hitungFCAW_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinFCAW.Text)){
                AssShop.KecMesin = double.Parse(kecMesinFCAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(legFCAW.Text)){
                AssShop.LegLength = double.Parse(legFCAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(lasFCAW.Text)){
                AssShop.PanjangLas = double.Parse(lasFCAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(electrodaFCAW.Text)){
                AssShop.Elektroda = double.Parse(electrodaFCAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamKerjaFCAW.Text)){
                AssShop.JamMesin = double.Parse(jamKerjaFCAW.Text);
                AssShop.OperasiMesin = double.Parse(jamKerjaFCAW.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.AssShop * KapaBengkel.Bulan;
            jumMesinFCAW.Text = AssShop.FCAW().ToString();
            jumPekerjaFCAW.Text = AssShop.PekerjaFCAW().ToString();
            totalPekerjaFCAW.Text = AssShop.TotalPekerjaFCAW().ToString();
        }

        private void hitungWaktuPengerjaan_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(preShop.Text)){
                KapaBengkel.PrepShop = int.Parse(preShop.Text);
            }
            if (!string.IsNullOrWhiteSpace(fabShop.Text)){
                KapaBengkel.FabShop = int.Parse(fabShop.Text);
            }
            if (!string.IsNullOrWhiteSpace(subassShop.Text)){
                KapaBengkel.SubAssShop = int.Parse(subassShop.Text);
            }
            if (!string.IsNullOrWhiteSpace(assemblyShop.Text)){
                KapaBengkel.AssShop = int.Parse(assemblyShop.Text);
            }
            if (!string.IsNullOrWhiteSpace(pipeShop.Text)){
                KapaBengkel.PipeShop = int.Parse(pipeShop.Text);
            }
            if (!string.IsNullOrWhiteSpace(bulanOrg.Text)){
                KapaBengkel.Bulan = int.Parse(bulanOrg.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamOrg.Text)){
                KapaBengkel.JamOrg = int.Parse(jamOrg.Text);
            }

            if (!string.IsNullOrWhiteSpace(preShopB.Text)){
                KapaBengkel.PrepShopB = int.Parse(preShopB.Text);
            }
            if (!string.IsNullOrWhiteSpace(fabShopB.Text)){
                KapaBengkel.FabShopB = int.Parse(fabShopB.Text);
            }
            if (!string.IsNullOrWhiteSpace(subAssShopB.Text)){
                KapaBengkel.SubAssShopB = int.Parse(subAssShopB.Text);
            }
            if (!string.IsNullOrWhiteSpace(assShopB.Text)){
                KapaBengkel.AssShopB = int.Parse(assShopB.Text);
            }
            if (!string.IsNullOrWhiteSpace(pipeShopB.Text)){
                KapaBengkel.PipeShopB = int.Parse(pipeShopB.Text);
            }
            totalPengerjaan.Text = KapaBengkel.TotalPengerjaan().ToString();
            totalHari.Text = KapaBengkel.TotalPengerjaanHari().ToString();
            totalJam.Text = KapaBengkel.TotalPengerjaanJam().ToString();
            //Assembly Shop
            AssShop.KapaBengkel = KapaBengkel.AssShopB;
            AssShop.Beratbaja = Wst;
            AssShop.JamOrang = KapaBengkel.JamOrg;
            AssShop.WaktuPenyelesaianAss = KapaBengkel.TotalBulan;
            //Preparation Shop
            PreShop.Beratbaja = Wst;
            PreShop.KapaBengkel = KapaBengkel.PrepShopB;
            PreShop.JamOrang = KapaBengkel.JamOrg;
            PreShop.JamOrangMnt = KapaBengkel.JamOrg;
            PreShop.WaktuKerja = KapaBengkel.PrepShop * KapaBengkel.Bulan;
            waktuKerjaPlate.Text = PreShop.WaktuKerja.ToString();
            jamOrangPlate.Text = PreShop.JamOrangMnt.ToString();
            waktuKerjaShot.Text = PreShop.WaktuKerja.ToString();
            jamOrangShot.Text = PreShop.JamOrangMnt.ToString();
            waktuKerjaPrime.Text = PreShop.WaktuKerja.ToString();
            jamOrangPrime.Text = PreShop.JamOrangMnt.ToString();
            waktuKerjaRoller.Text = PreShop.WaktuKerja.ToString();
            jamOrangRoller.Text = PreShop.JamOrangMnt.ToString();
            //Fabrication Shop
            FabShop.Beratbaja = Wst;
            FabShop.WaktuKerja = KapaBengkel.FabShop * KapaBengkel.Bulan;
            FabShop.JamOrang = KapaBengkel.JamOrg;
            FabShop.KapaBengkel = KapaBengkel.FabShopB;

            beratBajaNC.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaNC.Text = FabShop.WaktuKerja.ToString();
            jamOrangNCM.Text = FabShop.JamOrang.ToString();

            beratBajaCNC.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaCNC.Text = FabShop.WaktuKerja.ToString();
            jamOrangCNC.Text = FabShop.JamOrang.ToString();

            beratBajaCNCG.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaCNCG.Text = FabShop.WaktuKerja.ToString();
            jamOrangCNCG.Text = FabShop.JamOrang.ToString();

            beratBajaCutting.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaCutting.Text = FabShop.WaktuKerja.ToString();
            jamOrangCutting.Text = FabShop.JamOrang.ToString();

            beratBajaFlame.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaFlame.Text = FabShop.WaktuKerja.ToString();
            jamOrangFlame.Text = FabShop.JamOrang.ToString();

            beratBajaBendingA.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaBendingA.Text = FabShop.WaktuKerja.ToString();
            jamOrangBendingA.Text = FabShop.JamOrang.ToString();

            beratBajaBendingB.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaBendingB.Text = FabShop.WaktuKerja.ToString();
            jamOrangBendingB.Text = FabShop.JamOrang.ToString();

            beratBajaFrame.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaFrame.Text = FabShop.WaktuKerja.ToString();
            jamOrangFrame.Text = FabShop.JamOrang.ToString();

            beratBajaLine.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaLine.Text = FabShop.WaktuKerja.ToString();
            jamOrangLine.Text = FabShop.JamOrang.ToString();

            /*beratBajaFlame.Text = FabShop.Beratbaja.ToString("0.###");
            waktuKerjaFlame.Text = FabShop.WaktuKerja.ToString();
            jamOrangFlame.Text = FabShop.JamOrang.ToString();*/
        }

        private void hitungSMAW_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinSMAW.Text)){
                AssShop.KecMesin = double.Parse(kecMesinSMAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(legSMAW.Text)){
                AssShop.LegLength = double.Parse(legSMAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(lasSMAW.Text)){
                AssShop.PanjangLas = double.Parse(lasSMAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(elektrodaSMAW.Text)){
                AssShop.Elektroda = double.Parse(elektrodaSMAW.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamKerjaFCAW.Text)){
                AssShop.JamMesin = double.Parse(jamKerjaSMAW.Text);
                AssShop.OperasiMesin = double.Parse(jamKerjaSMAW.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.AssShop * KapaBengkel.Bulan;
            jumMesinSMAW.Text = AssShop.FCAW().ToString();
            jumPekerjaSMAW.Text = (AssShop.PekerjaFCAW()).ToString();
            totalPekerjaSMAW.Text = AssShop.TotalPekerjaFCAW().ToString();
        }

        private void hitungCraneA_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(waktuMesinCraneA.Text)){
                AssShop.WaktuMesin = double.Parse(waktuMesinCraneA.Text);
            }
            if (!string.IsNullOrWhiteSpace(kapaMesinCraneA.Text)){
                AssShop.KapaMesin = double.Parse(kapaMesinCraneA.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.TotalBulan * KapaBengkel.Bulan;            
            jumMesinCraneA.Text = AssShop.Crane().ToString();
            jumPekerjaCraneA.Text = AssShop.PekerjaCrane().ToString();
            totalPekerjaCraneA.Text = AssShop.TotalPekerjaCrane().ToString();
        }

        private void hitungGantry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(waktuMesinGantry.Text)){
                AssShop.WaktuMesin = double.Parse(waktuMesinGantry.Text);
            }
            if (!string.IsNullOrWhiteSpace(kapaMesinGantry.Text)){
                AssShop.KapaMesin = double.Parse(kapaMesinGantry.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.TotalBulan * KapaBengkel.Bulan;
            jumMesinGantry.Text = AssShop.Crane().ToString();
            jumPekerjaGantry.Text = AssShop.PekerjaCrane().ToString();
            totalPekerjaGantry.Text = AssShop.TotalPekerjaCrane().ToString();
        }

        private void hitungTransporter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(waktuMesinTransporter.Text)){
                AssShop.WaktuMesin = double.Parse(waktuMesinTransporter.Text);
            }
            if (!string.IsNullOrWhiteSpace(kapaMesinTransporter.Text)){
                AssShop.KapaMesin = double.Parse(kapaMesinTransporter.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.TotalBulan * KapaBengkel.Bulan;
            jumMesinTransporter.Text = AssShop.Crane().ToString();
            jumPekerjaTransporter.Text = AssShop.PekerjaCrane().ToString();
            totalPekerjaTransporter.Text = AssShop.TotalPekerjaCrane().ToString();
        }

        private void hitungCraneB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(waktuMesinCraneB.Text)){
                AssShop.WaktuMesin = double.Parse(waktuMesinCraneB.Text);
            }
            if (!string.IsNullOrWhiteSpace(kapaMesinCraneB.Text)){
                AssShop.KapaMesin = double.Parse(kapaMesinCraneB.Text);
            }
            AssShop.WaktuKerja = KapaBengkel.TotalBulan * KapaBengkel.Bulan;
            jumMesinCraneB.Text = AssShop.Crane().ToString();
            jumPekerjaCraneB.Text = AssShop.PekerjaCrane().ToString();
            totalPekerjaCraneB.Text = AssShop.TotalPekerjaCrane().ToString();
        }

        private void hitungPlate_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinPlate.Text)){
                PreShop.KecMesin = double.Parse(kecMesinPlate.Text);
            }
            if (!string.IsNullOrWhiteSpace(panjPelatPlate.Text)){
                PreShop.PanjangPelat = double.Parse(panjPelatPlate.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratPelatPlate.Text)){
                PreShop.BeratPelat = double.Parse(beratPelatPlate.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinPlate.Text)){
                PreShop.BebanMesin = double.Parse(bebanMesinPlate.Text);
            }
            lbrPlate.Text = PreShop.LbrPlate().ToString();
            kgPlate.Text = PreShop.KgPlate().ToString();
            mesinPlate.Text = PreShop.Plate().ToString();
            pekerjaPlate.Text = PreShop.PekerjaPlate().ToString();
        }

        private void hitungShot_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinShot.Text)){
                PreShop.KecMesin = double.Parse(kecMesinShot.Text);
            }
            if (!string.IsNullOrWhiteSpace(panjPelatShot.Text)){
                PreShop.PanjangPelat = double.Parse(panjPelatShot.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratPelatShot.Text)){
                PreShop.BeratPelat = double.Parse(beratPelatShot.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinShot.Text)){
                PreShop.BebanMesin = double.Parse(bebanMesinShot.Text);
            }
            lbrShot.Text = PreShop.LbrPlate().ToString();
            kgShot.Text = PreShop.KgPlate().ToString();
            mesinShot.Text = PreShop.Plate().ToString();
            pekerjaShot.Text = PreShop.PekerjaPlate().ToString();
        }

        private void hitungPrime_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinPrime.Text)){
                PreShop.KecMesin = double.Parse(kecMesinPrime.Text);
            }
            if (!string.IsNullOrWhiteSpace(panjPelatPrime.Text)){
                PreShop.PanjangPelat = double.Parse(panjPelatPrime.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratPelatPrime.Text)){
                PreShop.BeratPelat = double.Parse(beratPelatPrime.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinPrime.Text)){
                PreShop.BebanMesin = double.Parse(bebanMesinPrime.Text);
            }
            lbrPrime.Text = PreShop.LbrPlate().ToString();
            kgPrime.Text = PreShop.KgPlate().ToString();
            mesinPrime.Text = PreShop.Plate().ToString();
            pekerjaPrime.Text = PreShop.PekerjaPlate().ToString();
        }

        private void hitungRoller_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kecMesinRoller.Text)){
                PreShop.KecMesin = double.Parse(kecMesinRoller.Text);
            }
            if (!string.IsNullOrWhiteSpace(panjPelatRoller.Text)){
                PreShop.PanjangPelat = double.Parse(panjPelatRoller.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratPelatRoller.Text)){
                PreShop.BeratPelat = double.Parse(beratPelatRoller.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinRoller.Text)){
                PreShop.BebanMesin = double.Parse(bebanMesinRoller.Text);
            }
            lbrRoller.Text = PreShop.LbrPlate().ToString();
            kgRoller.Text = PreShop.KgPlate().ToString();
            mesinRoller.Text = PreShop.Plate().ToString();
            pekerjaRoller.Text = PreShop.PekerjaPlate().ToString();
        }

        private void hitungGantryPre_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(jamMesinGantry.Text)){
                PreShop.WaktuMesin = double.Parse(jamMesinGantry.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinGantry.Text)){
                PreShop.KapaMesin = double.Parse(bebanMesinGantry.Text);
            }
            mesinGantry.Text = PreShop.Gantry().ToString();
            pekerjaGantry.Text = PreShop.PekerjaGantry().ToString();
        }

        private void hitungMagnetic_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(jamMesinMagnetic.Text)){
                PreShop.WaktuMesin = double.Parse(jamMesinMagnetic.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinMagnetic.Text)){
                PreShop.KapaMesin = double.Parse(bebanMesinMagnetic.Text);
            }
            mesinMagnetic.Text = PreShop.Gantry().ToString();
            pekerjaMagnetic.Text = PreShop.PekerjaGantry().ToString();
        }

        private void hitungCraneAPre_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(jamMesinCraneA.Text)){
                PreShop.WaktuMesin = double.Parse(jamMesinCraneA.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinCraneA.Text)){
                PreShop.KapaMesin = double.Parse(bebanMesinCraneA.Text);
            }
            mesinCraneA.Text = PreShop.Gantry().ToString();
            pekerjaCraneA.Text = PreShop.PekerjaGantry().ToString();
        }

        private void hitungCraneBPre_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(jamMesinCraneB.Text)){
                PreShop.WaktuMesin = double.Parse(jamMesinCraneB.Text);
            }
            if (!string.IsNullOrWhiteSpace(bebanMesinCraneB.Text)){
                PreShop.KapaMesin = double.Parse(bebanMesinCraneB.Text);
            }
            mesinCraneB.Text = PreShop.Gantry().ToString();
            pekerjaCraneB.Text = PreShop.PekerjaGantry().ToString();
        }

        private void hitungNC_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinNC.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinNC.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrNC.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrNC.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinNC.Text)){
                FabShop.JamMesin = double.Parse(jamMesinNC.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinNC.Text);
            }
            lbrBajaNC.Text = FabShop.LbrBaja().ToString("0.###");
            mesinNC.Text = FabShop.NC().ToString();
            pekerjaNC.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungCNC_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinCNC.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinCNC.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrCNC.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrCNC.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinCNC.Text)){
                FabShop.JamMesin = double.Parse(jamMesinCNC.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinCNC.Text);
            }
            lbrBajaCNC.Text = FabShop.LbrBaja().ToString("0.###");
            mesinCNC.Text = FabShop.NC().ToString();
            MessageBox.Show("ini CNC"+FabShop.PekerjaNC().ToString());
            pekerjaCNC.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungCutting_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinCutting.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinCutting.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrCutting.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrCutting.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinCutting.Text)){
                FabShop.JamMesin = double.Parse(jamMesinCutting.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinCutting.Text);
            }
            lbrCutting.Text = FabShop.LbrBaja().ToString("0.###");
            mesinCutting.Text = FabShop.NC().ToString();
            pekerjaCutting.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungCNCG_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinCNCG.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinCNCG.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrCNCG.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrCNCG.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinCNCG.Text)){
                FabShop.JamMesin = double.Parse(jamMesinCNCG.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinCNCG.Text);
            }
            lbrCNCG.Text = FabShop.LbrBaja().ToString("0.###");
            mesinCNCG.Text = FabShop.NC().ToString();
            pekerjaCNCG.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungFlame_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinFlame.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinFlame.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrFlame.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrFlame.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinFlame.Text)){
                FabShop.JamMesin = double.Parse(jamMesinFlame.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinFlame.Text);
            }
            lbrFlame.Text = FabShop.LbrBaja().ToString("0.###");
            mesinFame.Text = FabShop.NC().ToString();
            pekerjaFlame.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungBendingA_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinBendingA.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinBendingB.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrBendingA.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrBendingA.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinBendingA.Text)){
                FabShop.JamMesin = double.Parse(jamMesinBendingA.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinBendingA.Text);
            }
            lbrBendingA.Text = FabShop.LbrBaja().ToString("0.###");
            mesinBendingA.Text = FabShop.NC().ToString();
            pekerjaBendingA.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungBendingB_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinBendingB.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinBendingB.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrBendingB.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrBendingB.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinBendingB.Text)){
                FabShop.JamMesin = double.Parse(jamMesinBendingB.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinBendingB.Text);
            }
            lbrBendingB.Text = FabShop.LbrBaja().ToString("0.###");
            mesinBendingB.Text = FabShop.NC().ToString();
            pekerjaBendingB.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungFrame_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinFrameB.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinFrameB.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrFrame.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrFrame.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinFrame.Text)){
                FabShop.JamMesin = double.Parse(jamMesinFrame.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinFrame.Text);
            }
            lbrFrame.Text = FabShop.LbrBaja().ToString("0.###");
            mesinFrame.Text = FabShop.NC().ToString();
            pekerjaFrame.Text = FabShop.TotalPekerjaNC().ToString();
        }

        private void hitungLine_Click(object sender, EventArgs e){
            if (!string.IsNullOrWhiteSpace(kapaMesinLine.Text)){
                FabShop.KapaMesin = double.Parse(kapaMesinLine.Text);
            }
            if (!string.IsNullOrWhiteSpace(beratBajaLbrLine.Text)){
                FabShop.BeratBajaLbr = double.Parse(beratBajaLbrLine.Text);
            }
            if (!string.IsNullOrWhiteSpace(jamMesinLine.Text)){
                FabShop.JamMesin = double.Parse(jamMesinLine.Text);
                FabShop.OperasiMesin = double.Parse(jamMesinLine.Text);
            }
            lbrLine.Text = FabShop.LbrBaja().ToString("0.###");
            mesinLine.Text = FabShop.NC().ToString();
            pekerjaLine.Text = FabShop.TotalPekerjaNC().ToString();
        }
    }
}
