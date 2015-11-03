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

            double lwl = newKapal.setLwl();
            double fn = newKapal.setFn();
            double cb = newKapal.setCb();
            double v = newKapal.setV();
            double d = newKapal.setD();
            double VForcastle = newKapal.setVForcastle();
            double VPoop = newKapal.setVPoop();
            double VTotal = newKapal.setVTotal();
            double VDH_ll = newKapal.setVDH_ll();
            double VDH_lll = newKapal.setVDH_lll();
            double VDH_lV = newKapal.setVDH_lV();
            double VHW = newKapal.setVWH();
            double VDH = newKapal.setVDH();
            double Cs = newKapal.setCs();
            double WST = newKapal.setWst();
            double U = newKapal.setU();
            fasil.WstKapal = WST;
            PlateStraightening();
            RollerConveyor();
            ShotBlasting();
            PrimeringMachine();
            CuttingMachine();
            CNC_Cutting();
            /*FrameBender();
            
            CuttingMachineAuto();
            BendRollMachine();
            */
            listBox.Items.Clear();
            listBox.Items.Add("Panjang Garis Air : " + lwl.ToString("0.###")+" m");
            listBox.Items.Add("Froude Number : " + fn.ToString("0.###") + " ");
            listBox.Items.Add("Coeffisien Block : " + cb.ToString("0.###") + " ");
            listBox.Items.Add("Volume Displasemen : " + v.ToString("0.###") + " m^3");
            listBox.Items.Add("Displasemen : " + d.ToString("0.###") + " ton");
            listBox.Items.Add("Volume Forecastle : " + VForcastle.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Poop : " + VPoop.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Total : " + VTotal.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer II : " + VDH_ll.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer III : " + VDH_lll.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Layer IV : " + VDH_lV.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Wheel House : " + VHW.ToString("0.###") + " m^3");
            listBox.Items.Add("Volume Total : " + VDH.ToString("0.###") + " m^3");
            listBox.Items.Add("Cs : " + Cs.ToString("0.###") + " ");
            listBox.Items.Add("Berat Baja Total : " + WST.ToString("0.###") + " ton");
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
                plateStr.Text = "1";
            }
            else
            {
                plateStr.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void RollerConveyor()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                rollerCon.Text = "1";
            }
            else
            {
                rollerCon.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void ShotBlasting()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KecMesin = 1.25;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                shotBlas.Text = "1";
            }
            else
            {
                shotBlas.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void PrimeringMachine()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KecMesin = 1.25;
            FasilUtama.WaktuKerja = 2;
            FasilUtama.BebanKerja = 6;
            if (FasilUtama.setPlateStr() < 0.9)
            {
                primeMachine.Text = "1";
            }
            else
            {
                primeMachine.Text = Math.Round(Convert.ToDecimal(FasilUtama.setPlateStr())).ToString();
            }
        }
        private void CuttingMachine()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            //FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 5;
            //FasilUtama.KapaMesin = 0.3;
            //MessageBox.Show(FasilUtama.setCuttMachine().ToString());
            /*if (FasilUtama.setCuttMachine() < 0.9)
            {
                cuttMachine.Text = "1";
            }
            else
            {
                cuttMachine.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCuttMachine())).ToString();
            }*/
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
        /*private void FrameBender()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            //FasilUtama.KecMesin = 2.10;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 6;
            MessageBox.Show(FasilUtama.setCuttMachine().ToString());
            /*if (FasilUtama.setCuttMachine() < 0.9)
            {
                frameBend.Text = "1";
            }
            else
            {
                frameBend.Text = Math.Round(Convert.ToDecimal(FasilUtama.setCuttMachine())).ToString();
            }
        }*/
        private void CNC_Cutting()
        {
            Fasilitas FasilUtama = new Fasilitas();
            //FasilUtama.KecMesin = 2.10;
            FasilUtama.KapaMesin = 10;
            FasilUtama.WaktuKerja = 3;
            //FasilUtama.BebanKerja = 6;
            //MessageBox.Show(FasilUtama.KapaMesin.ToString());
            MessageBox.Show(FasilUtama.setCNC_Machine().ToString());
            /*if (FasilUtama.setCNC_Machine() < 0.9)
            {
                cncCutt.Text = "1";
            }
            else
            {
                cncCutt.Text = Math.Round(FasilUtama.setCNC_Machine()).ToString();
            }*/
        }
        /*private void CuttingMachineAuto()
        {
            //Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KapaMesin = 4;
            FasilUtama.WaktuKerja = 2;
            //FasilUtama.BebanKerja = 6;
            //CuttMachineAuto.Text = FasilUtama.setCuttMachineAuto().ToString();
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
            //Fasilitas FasilUtama = new Fasilitas();
            FasilUtama.KapaMesin = 15;
            FasilUtama.WaktuKerja = 3;
            FasilUtama.BebanKerja = 6;
            bendRoll.Text = FasilUtama.setBendRollMachine().ToString();
            if (FasilUtama.setBendRollMachine() < 0.9)
            {
                bendRoll.Text = "1";
            }
            else
            {
                bendRoll.Text = Math.Round(Convert.ToDecimal(FasilUtama.setBendRollMachine())).ToString();
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
        }*/
    }
}
