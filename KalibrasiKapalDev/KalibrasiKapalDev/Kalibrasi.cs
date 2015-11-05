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
        Fasilitas FasilUtama = new Fasilitas();
        Kapal KapalBaru = new Kapal();
        private double Lwl;
        private double Fn;
        private double Cb;
        private double V;
        private double D;
        private double Vforcastle;
        private double Vpoop;
        private double Vtotal;
        private double Vdh_ll;
        private double Vdh_lll;
        private double Vdh_lV;
        private double Vwh;
        private double Vdh;
        private double Cs;
        private double U;
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

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (!string.IsNullOrWhiteSpace(Jenis.Text))
            {
                KapalBaru.Jenis = Cso;
            }

            Lwl = KapalBaru.setLwl();
            Fn = KapalBaru.setFn();
            Cb = KapalBaru.setCb();
            V = KapalBaru.setV();
            D = KapalBaru.setD();
            Vforcastle = KapalBaru.setVForcastle();
            Vpoop = KapalBaru.setVPoop();
            Vtotal = KapalBaru.setVTotal();
            Vdh_ll = KapalBaru.setVDH_ll();
            Vdh_lll = KapalBaru.setVDH_lll();
            Vdh_lV = KapalBaru.setVDH_lV();
            Vwh = KapalBaru.setVWH();
            Vdh = KapalBaru.setVDH();
            Cs = KapalBaru.setCs();
            Wst = KapalBaru.setWst();
            U = KapalBaru.setU();

            /*PlateStraightening();
            RollerConveyor();
            ShotBlasting();
            PrimeringMachine();
            CuttingMachine();

            FrameBender();
            CNCCutting();
            CuttingMachineAuto();
            BendRollMachine();

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
            AutoGasCutting();*/
        }

        private void Jenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = Jenis.SelectedItem.ToString();
            TypeKapal Kapal = List.Find(k => k.Type == type);
            Cso = Kapal.Cso;
        }

        /*private void PlateStraightening()
        {
            FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 7;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                PlateStr.Text = "1";
            }
            else
            {
                PlateStr.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void RollerConveyor()
        {
            FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                RollerCon.Text = "1";
            }
            else
            {
                RollerCon.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void ShotBlasting()
        {
            FasilUtama.KecMesin = 1.25;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                ShotBlas.Text = "1";
            }
            else
            {
                ShotBlas.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void PrimeringMachine()
        {
            FasilUtama.KecMesin = 1.25;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                PrimeMachine.Text = "1";
            }
            else
            {
                PrimeMachine.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void CuttingMachine()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCuttMachine() < 0.9)
            {
                CuttMachine.Text = "1";
            }
            else
            {
                CuttMachine.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCuttMachine())).ToString();
            }
        }
        private void rollerConveyor()
        {
            Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (Convert.ToDecimal(FasilUtama.setPlateStr()) == 0)
            {
                plateStr.Text = "1";
            }
            else
            {
                plateStr.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void FrameBender()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 6;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCuttMachine() < 0.9)
            {
                FrameBend.Text = "1";
            }
            else
            {
                FrameBend.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCuttMachine())).ToString();
            }
        }
        private void CNCCutting()
        {
            FasilUtama.KapaMesin = 10;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCNCMachine() < 0.9)
            {
                CncCutt.Text = "1";
            }
            else
            {
                CncCutt.Text = Math.Round(FasilUtama.setCNCMachine()).ToString();
            }
        }
        private void CuttingMachineAuto()
        {
            FasilUtama.KapaMesin = 4;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCuttMachineAuto() < 0.9)
            {
                CuttMachineAuto.Text = "1";
            }
            else
            {
                CuttMachineAuto.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCuttMachineAuto())).ToString();
            }
        }
        private void BendRollMachine()
        {
            FasilUtama.KapaMesin = 15;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCNCMachine() < 0.9)
            {
                BendRoll.Text = "1";
            }
            else
            {
                BendRoll.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCNCMachine())).ToString();
            }
        }
        private void BendingMachine()
        {
            Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KapaMesin = 4;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (Convert.ToDecimal(FasilUtama.setPlateStr()) == 0)
            {
                BendMachine500.Text = "1";
            }
            else
            {
                BendMachine500.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void WeldingMachine()
        {
            FasilUtama.KecMesin = 0.38;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 6;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setWeldingMachine() < 0.9)
            {
                WeldMachine.Text = "1";
            }
            else
            {
                WeldMachine.Text = Math.Round(Convert.ToDecimal(FasilUtama.setWeldingMachine())).ToString();
            }
        }
        private void MobileWebGantry()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 7;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                MobileWeb.Text = "1";
            }
            else
            {
                MobileWeb.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void ServiceWelding()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 5;
            FasilUtama.WstKapal = Wst;
            FasilUtama.KapaBebanMesin = 0.5;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                ServiceWeld.Text = "1";
            }
            else
            {
                ServiceWeld.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void MobileStiffener()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 6;
            FasilUtama.WstKapal = Wst;
            FasilUtama.KapaBebanMesin = 0.38;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                MobileStiff.Text = "1";
            }
            else
            {
                MobileStiff.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void TransferTrolley()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 5;
            FasilUtama.KapaBebanMesin = 5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                TransferTroll.Text = "1";
            }
            else
            {
                TransferTroll.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void FilletWelding()
        {
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 5;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                FilletWeld.Text = "1";
            }
            else
            {
                FilletWeld.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void NCPipe()
        {
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 5;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                NcPipe.Text = "1";
            }
            else
            {
                NcPipe.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void SemiAutoGas()
        {
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 8;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                SemiAuto.Text = "1";
            }
            else
            {
                SemiAuto.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void PipeBender()
        {
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 7;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                PipeBend50.Text = "1";
            }
            else
            {
                PipeBend50.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void PipeBender65()
        {
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 5;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                PipeBend65.Text = "1";
            }
            else
            {
                PipeBend65.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }
        private void AutoGasCutting()
        {
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 8;
            FasilUtama.KapaBebanMesin = 0.5;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setMobileWeb() < 0.9)
            {
                AutoGas.Text = "1";
            }
            else
            {
                AutoGas.Text = Math.Round(Convert.ToDecimal(FasilUtama.setMobileWeb())).ToString();
            }
        }*/
    }
}
