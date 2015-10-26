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

        //private List<string>[] list;
        private double csoType;
        public MainWindow()
        {            
            InitializeComponent();
            TypeKapal();
        }

        void TypeKapal()
        {
            typeKapalInp.Items.Clear();
            //TypeKapal type = new TypeKapal();
            List<TypeKapal> TypeList = new List<TypeKapal>();
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
                typeKapalInp.Items.Add(list.Kapal);
            }
         
        }     

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Kapal newKapal = new Kapal();
            if(!string.IsNullOrWhiteSpace(loaInp.Text))
            {
                newKapal.setLoa(double.Parse(loaInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(lppInp.Text))
            {
                newKapal.setLpp(double.Parse(lppInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(breadthInp.Text))
            {
                newKapal.setBreadth(double.Parse(breadthInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(depthInp.Text))
            {
                newKapal.setDepth(double.Parse(depthInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(draughtInp.Text))
            {
                newKapal.setDraught(double.Parse(draughtInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(speedInp.Text))
            {
                newKapal.setSpeed(double.Parse(speedInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(speedInp.Text))
            {
                newKapal.setDwt(double.Parse(dwtInp.Text));
            }
            if (!string.IsNullOrWhiteSpace(speedInp.Text))
            {
                newKapal.setJnsKapal(csoType);
            }

            double lwl = newKapal.getLwl();
            double fn = newKapal.getFn();
            double cb = newKapal.getCb();
            double v = newKapal.getV();
            double d = newKapal.getD();
            double VForcastle = newKapal.getVForcastle();
            double VPoop = newKapal.getVPoop();
            double VTotal = newKapal.getVTotal();
            double VDH_ll = newKapal.getVDH_ll();
            double VDH_lll = newKapal.getVDH_lll();
            double VDH_lV = newKapal.getVDH_lV();
            double VHW = newKapal.getVWH();
            double VDH = newKapal.getVDH();
            double Cs = newKapal.getCs();
            double WST = newKapal.getWst();
            double U = newKapal.getU();
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
            //double lwl = newKapal.getLwl();
            //MessageBox.Show("lwl: "+lwl.ToString() +"fn: "+fn.ToString()+"cb: "+cb.ToString() +"v: "+v.ToString() +"d: "+d.ToString());
            //MessageBox.Show("lwl: " + string.Format("{0:0.##}", lwl) + "fn: " + string.Format("{0:0.##}", fn) + "cb: " + cb.ToString("0.##") + "v: " + v.ToString("0.##") + "d: " + d.ToString("0.##"));
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void typeKapalInp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TypeKapal typeKapalCso = new TypeKapal();
            //ComboBox cmbx = (ComboBox)sender;
            //typeKapalInp type = ((typeKapalInp)cmbx.SelectedItem);
            
            string type = typeKapalInp.SelectedValue.ToString();
            if (type.Equals("Bulk carriers"))
            {
                //typeKapalCso.CSO = 0.07;
                csoType = 0.07;
            }
            else if (type.Equals("Cargo ship (1 decks)"))
            {
                csoType = 0.07;
            }
            else if (type.Equals("Cargo ship (2 decks)"))
            {
                csoType = 0.076;
            }
            else if (type.Equals("Cargo ship (3 decks)"))
            {
                csoType = 0.082;
            }
            else if (type.Equals("Passenger ship"))
            {
                csoType = 0.058;
            }
            else if (type.Equals("Product carriers"))
            {
                csoType = 0.0664;
            }
            else if (type.Equals("Reefers"))
            {
                csoType = 0.0609;
            }
            else if (type.Equals("Rescue vessel"))
            {
                csoType = 0.0232;
            }
            else if (type.Equals("Support vessels"))
            {
                csoType = 0.0974;
            }
            else if (type.Equals("Tanker"))
            {
                csoType = 0.0752;
            }
            else if (type.Equals("Train ferries"))
            {
                csoType = 0.065;
            }
            else if (type.Equals("Tugs"))
            {
                csoType = 0.0892;
            }
            else if (type.Equals("VLCC"))
            {
                csoType = 0.0645;
            }
            MessageBox.Show(csoType.ToString());
        }
    }
}
