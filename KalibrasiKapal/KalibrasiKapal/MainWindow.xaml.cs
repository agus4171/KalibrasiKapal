using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KalibrasiKapal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TypeKapal> TypeList = new List<TypeKapal>();
        Fasilitas FasilUtama = new Fasilitas();
            
        double Lwl;
        double Fn;
        double Cb;
        double v;
        double d;
        double Vforcastle;
        double Vpoop;
        double Vtotal;
        double Vdh_ll;
        double Vdh_lll;
        double Vdh_lV;
        double Vwh;
        double Vdh;
        double Cs;
        double U;
        private double Wst;
        private double csoType;

        public MainWindow()
        {            
            InitializeComponent();
            TypeKapal();        
        }

        private void TypeKapal()
        {
            typeKapalInp.Items.Clear();
            TypeList.Add(new TypeKapal("Bulk carriers", 0.07));
            TypeList.Add(new TypeKapal("Cargo ship (1 decks)", 0.07));
            TypeList.Add(new TypeKapal("Cargo ship (2 decks)", 0.076));
            TypeList.Add(new TypeKapal("Cargo ship (3 decks)", 0.082));
            TypeList.Add(new TypeKapal("Passenger ship", 0.058));
            TypeList.Add(new TypeKapal("Product carriers", 0.0664));
            TypeList.Add(new TypeKapal("Reefers", 0.0609));
            TypeList.Add(new TypeKapal("Rescue vessel", 0.0232));
            TypeList.Add(new TypeKapal("Support vessels", 0.0974));
            TypeList.Add(new TypeKapal("Tanker", 0.0752));
            TypeList.Add(new TypeKapal("Train ferries", 0.065));
            TypeList.Add(new TypeKapal("Tugs", 0.0892));
            TypeList.Add(new TypeKapal("VLCC", 0.0645));
            foreach(var list in TypeList)
            {
                typeKapalInp.Items.Add(list.JnsKapal);
            }         
        }     

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Kapal newKapal = new Kapal();
            Fasilitas fasil = new Fasilitas();
            if(!string.IsNullOrWhiteSpace(loaInp.Text))
            {
                newKapal.Loa = double.Parse(loaInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(lppInp.Text))
            {
                newKapal.Lpp = double.Parse(lppInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(breadthInp.Text))
            {
                newKapal.Breadth = double.Parse(breadthInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(depthInp.Text))
            {
                newKapal.Depth = double.Parse(depthInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(draughtInp.Text))
            {
                newKapal.Draught = double.Parse(draughtInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(speedInp.Text))
            {
                newKapal.Speed = double.Parse(speedInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(dwtInp.Text))
            {
                newKapal.Dwt = double.Parse(dwtInp.Text);
            }
            if (!string.IsNullOrWhiteSpace(typeKapalInp.Text))
            {
                newKapal.JnsKapal = csoType;
            }

            Lwl = newKapal.setLwl();
            Fn = newKapal.setFn();
            Cb = newKapal.setCb();
            v = newKapal.setV();
            d = newKapal.setD();
            Vforcastle = newKapal.setVForcastle();
            Vpoop = newKapal.setVPoop();
            Vtotal = newKapal.setVTotal();
            Vdh_ll = newKapal.setVDH_ll();
            Vdh_lll = newKapal.setVDH_lll();
            Vdh_lV = newKapal.setVDH_lV();
            Vwh = newKapal.setVWH();
            Vdh = newKapal.setVDH();
            Cs = newKapal.setCs();
            Wst = newKapal.setWst();
            U = newKapal.setU();
            
            PlateStraightening();
            RollerConveyor();
            ShotBlasting();
            PrimeringMachine();
            CuttingMachine();
                        
            FrameBender();
            CNC_Cutting();
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
            AutoGasCutting();
            
            listBox.Items.Clear();
            listBox.Items.Add("Panjang Garis Air : " + Lwl.ToString("0.###")+" m");
            listBox.Items.Add("Froude Number : " + Fn.ToString("0.###") + " ");
            listBox.Items.Add("Coeffisien Block : " + Cb.ToString("0.###") + " ");
            listBox.Items.Add("Volume Displasemen : " + v.ToString("0.###") + " m^3");
            listBox.Items.Add("Displasemen : " + d.ToString("0.###") + " ton");
            listBox.Items.Add("Volume Forecastle : " + Vforcastle.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Poop : " + Vpoop.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Total : " + Vtotal.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer II : " + Vdh_ll.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer III : " + Vdh_lll.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer IV : " + Vdh_lV.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Wheel House : " + Vwh.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Total : " + Vdh.ToString("0.###") + " m^3");
            listBox.Items.Add("Cs : " + Cs.ToString("0.###") + " ");
            listBox.Items.Add("Berat Baja Total : " + Wst.ToString("0.###") + " ton");
            listBox.Items.Add("U : " + U.ToString("0.###") + " ");
            //Console.WriteLine(fn);
            //double lwl = newKapal.setLwl();
            //MessageBox.Show("lwl: "+lwl.ToString() +"fn: "+fn.ToString()+"cb: "+cb.ToString() +"v: "+v.ToString() +"d: "+d.ToString());
            //MessageBox.Show("lwl: " + string.Format("{0:0.##}", lwl) + "fn: " + string.Format("{0:0.##}", fn) + "cb: " + cb.ToString("0.##") + "v: " + v.ToString("0.##") + "d: " + d.ToString("0.##"));
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void typeKapalInp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            string type = typeKapalInp.SelectedValue.ToString();
            TypeKapal kapal = TypeList.Find(k => k.JnsKapal == type);
            csoType = kapal.Cso;
        }

        private void PlateStraightening()
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
        /*private void rollerConveyor()
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
        }*/
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
        private void CNC_Cutting()
        {
            FasilUtama.KapaMesin = 10;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.WstKapal = Wst;
            if (FasilUtama.setCNC_Machine() < 0.9)
            {
                CncCutt.Text = "1";
            }
            else
            {
                CncCutt.Text = Math.Round(FasilUtama.setCNC_Machine()).ToString();
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
            if (FasilUtama.setCNC_Machine() < 0.9)
            {
                BendRoll.Text = "1";
            }
            else
            {
                BendRoll.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCNC_Machine())).ToString();
            }
        }
        /*private void BendingMachine()
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
        }*/
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
        }
    }
}
