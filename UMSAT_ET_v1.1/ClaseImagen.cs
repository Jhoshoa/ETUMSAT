using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
using System.Drawing.Imaging;

namespace UMSAT_ET_v1._1
{
    public partial class ClaseImagen : Form
    {
        public ClaseImagen()
        {
            InitializeComponent();
        }

        private void btnGuardarFoto_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Png Image (.png)|*.png|JPEG Image (.jpeg)|*.jpeg";
            //dlg.filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";       //Para exportar con .csv
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Jpeg);
            MessageBox.Show("La imagen fue almacenada");
        }
    }
}
