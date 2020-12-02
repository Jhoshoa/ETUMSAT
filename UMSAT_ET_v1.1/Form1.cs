using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//NameSpace para la comunicacion UART
using System.IO.Ports;
using System.IO;

//Gmap
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace UMSAT_ET_v1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            submenuOcultosInicio();
        }

        double LatInicial = -16.527352;
        double LngInicial = -68.176698;

        ClaseTemperatura datosTemp = new ClaseTemperatura();
        ClasePresion datosPresion = new ClasePresion();
        ClaseAltura datosAltura = new ClaseAltura();
        
        ClaseAceleracion datosAcel = new ClaseAceleracion();
        ClaseGiroscopio datosGiro = new ClaseGiroscopio();
        ClaseMagnetometro datoMag = new ClaseMagnetometro();

        DataLatLong datosLatLong = new DataLatLong();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;

            toolStripStatusLblConectado.Text = "Desconectado";

            //Datos iniciales para GMAP
            gMapControl1.DragButton = MouseButtons.Left;
            //gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            //gMapControl1.MapProvider = BingMapProvider.Instance;
            //GMaps.Instance.Mode = AccessMode.ServerOnly;      //ESto es para descargar si o si los datos de internet

            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;
            gMapControl1.Visible = true;
            gMapControl1.ShowCenter = false;

            //for (int i = 0; i <= 50; i++)
            //{
            //    datosTemp.chtTemperatura.Series[0].Points.AddY(-2);
            //}
        }

        private void submenuOcultosInicio()
        {
            panelArchivoSubmenu.Visible = false;
            panelconfigSubMenu.Visible = false;
            panelPuertoComSubmenu.Visible = false;
            panelComandoSubmenu.Visible = false;
            panelSensoresSubmenu.Visible = false;
        }
        private void OcultarSubmenu()
        {
            if (panelArchivoSubmenu.Visible == true)
                panelArchivoSubmenu.Visible = false;
            if (panelconfigSubMenu.Visible == true)
                panelconfigSubMenu.Visible = false;
            if (panelPuertoComSubmenu.Visible == true)
                panelPuertoComSubmenu.Visible = false;
            if (panelComandoSubmenu.Visible == true)
                panelComandoSubmenu.Visible = false;
            if (panelSensoresSubmenu.Visible == true)
                panelSensoresSubmenu.Visible = false;
        }
        private void MostrarSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Archivos
        private void btnArchivo_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelArchivoSubmenu);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            //mi codigo
            ExportarDatos(datosLatLong.dataGridView2);
            OcultarSubmenu();
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            //mi codigo
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|CSV file (*.csv)|*.csv";
            string nombreArchivo;
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    nombreArchivo = dlg.FileName;
                    TextWriter guardarDatos = new StreamWriter(nombreArchivo);

                    for (int i = 0; i < datosLatLong.dataGridView2.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < datosLatLong.dataGridView2.Columns.Count; j++)
                        {
                            guardarDatos.Write("\t" + datosLatLong.dataGridView2.Rows[i].Cells[j].Value.ToString() + ",");
                        }
                        guardarDatos.WriteLine("");     //Es para el salto de linea
                    }
                    guardarDatos.Close();
                    MessageBox.Show("Se han exportado los datos exitosamente");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar");
            }

            OcultarSubmenu();
        }

        private void btnExportarDatosGps_Click(object sender, EventArgs e)
        {
            //mi codigo
            ExportarDatos(datosLatLong.dataGridView1);
            OcultarSubmenu();
        }
        private void btnExportarPng_Click(object sender, EventArgs e)
        {

        }

        public void ExportarDatos(DataGridView datalistado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in datalistado.Columns)
            {
                IndiceColumna++;
                exportarexcel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in datalistado.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in datalistado.Columns)
                {
                    IndiceColumna++;
                    exportarexcel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }
        #endregion

        #region Configuracion
        private void btnConfiguracionInicial_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelconfigSubMenu);
        }

        private void numUDymax_ValueChanged(object sender, EventArgs e)
        {
            switch(cboxSelectGrafica.Text)
            {
                case "Temperatura":
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
                case "Presión":
                    datosPresion.chtPresion.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
                case "Altura":
                    datosAltura.chtAltura.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
                case "Aceleración":
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
                case "Giroscopio":
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
                case "Magnetometro":
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(numUDymax.Value);
                    break;
            }
        }

        private void numUDymin_ValueChanged(object sender, EventArgs e)
        {
            switch (cboxSelectGrafica.Text)
            {
                case "Temperatura":
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
                case "Presión":
                    datosPresion.chtPresion.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
                case "Altura":
                    datosAltura.chtAltura.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
                case "Aceleración":
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
                case "Giroscopio":
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
                case "Magnetometro":
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
                    break;
            }
            //datosTemp.chtTemperatura.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(numUDymin.Value);
        }

        private void marcaMayorY_ValueChanged(object sender, EventArgs e)
        {
            switch (cboxSelectGrafica.Text)
            {
                case "Temperatura":
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
                case "Presión":
                    datosPresion.chtPresion.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosPresion.chtPresion.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosPresion.chtPresion.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
                case "Altura":
                    datosAltura.chtAltura.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosAltura.chtAltura.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosAltura.chtAltura.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
                case "Aceleración":
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
                case "Giroscopio":
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
                case "Magnetometro":
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.MajorGrid.Interval = Convert.ToDouble(marcaMayorY.Value);
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.Interval = Convert.ToDouble(marcaMayorY.Value);
                    break;
            }
            //datosTemp.chtTemperatura.ChartAreas[0].AxisY.MajorTickMark.Interval = Convert.ToDouble(marcaMayorY.Value);
        }

        private void marcaMenorY_ValueChanged(object sender, EventArgs e)
        {
            switch (cboxSelectGrafica.Text)
            {
                case "Temperatura":
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datosTemp.chtTemperatura.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
                case "Presión":
                    datosPresion.chtPresion.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datosPresion.chtPresion.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
                case "Altura":
                    datosAltura.chtAltura.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datosAltura.chtAltura.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
                case "Aceleración":
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datosAcel.chtAcelerometro.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
                case "Giroscopio":
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datosGiro.chtGiroscopio.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
                case "Magnetometro":
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
                    datoMag.chtMagnetometro.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
                    break;
            }
            //datosTemp.chtTemperatura.ChartAreas[0].AxisY.MinorTickMark.Interval = Convert.ToDouble(marcaMenorY.Value);
            //datosTemp.chtTemperatura.ChartAreas[0].AxisY.MinorGrid.Interval = Convert.ToDouble(marcaMenorY.Value);
        }

        private void btnUbicacionActual_Click(object sender, EventArgs e)
        {
            GMapOverlay markerOverlay = new GMapOverlay("Marcador");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);

            OcultarSubmenu();
        }
        #endregion

        #region Puerto COM
        private void btnPuertoCom_Click_1(object sender, EventArgs e)
        {
            MostrarSubmenu(panelPuertoComSubmenu);
            
            cBoxCOMPORT.Items.Clear();
            //Escanea los puertos COM
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;

                serialPort1.Open();

                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;

                toolStripStatusLblConectado.Text = "Reciviendo Datos";
                timer1.Enabled = true;
                //timer2.Enabled = true;
                serialPort1.DiscardInBuffer();  //Para Borrar los datos basura que hay en el Buffer de RX
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error al Conectarse con el Puerto Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;
            }
            OcultarSubmenu();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;

                toolStripStatusLblConectado.Text = "Desconectado";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }

            OcultarSubmenu();
        }

        byte[] trama = new byte[44];    //Para la Trama del UMSATv1, Es con 53, pero lo cambie a 50 para probar
        byte[] foto = new byte[15000];   //Estaba con 8678 mi prueba, con el codigo de alvaro
        int numByteBufferRX;
        int j;
        int dimensionPaquete;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i;

            numByteBufferRX = serialPort1.BytesToRead;
            if (serialPort1.BytesToRead > 0)
            {
                byte b = (byte)serialPort1.ReadByte();
                if (b == 0x0D)
                {
                    for (i = 1; i < 44; i++)        //cambiado 32 para pruebas, Es con 53, pero lo cambie a 50 para probar
                    {
                        b = (byte)serialPort1.ReadByte();
                        trama[i] = b;
                    }

                    //j = 0;
                    UpdateDatos();
                    this.Invoke(new EventHandler(ShowData));
                }else if (b == 0x0F)
                {
                    byte np = (byte)serialPort1.ReadByte();
                    byte tm = (byte)serialPort1.ReadByte();
                    dimensionPaquete = tm;
                    for (i = 0; i < dimensionPaquete; i++)        //estaba con hasta "tm", lo cambie para probar 8678
                    {
                        b = (byte)serialPort1.ReadByte();
                        foto[j] = b;    //Estaba en "foto[j]" pero lo cambia a foto[i] para probar
                        j++;
                    }
                    if (np == 0)
                        MessageBox.Show("Imagen completa recivida");
                }
            }
        }

        //Trama de datos UMSATv1
        double ID;
        double tiempoMin, tiempoSeg;
        double numPaquete;
        double presion, altura;
        double Temp;
        double voltajePS, corrientePS;
        double voltajeBat, corrienteBat;
        double latitud, longitud;
        double magX, magY, magZ;
        double acelX, acelY, acelZ;
        double girX, girY, girZ;
        private void UpdateDatos()
        {
            //long auxID;
            //char auxTiempoMin, auxTiempoSeg;
            short auxNumPaquete;
            int auxPresion;
            ushort auxAltura;
            short auxTemp;
            short auxVoltajePS, auxCorrientePS;
            short auxVoltajeBat, auxCorrienteBat;
            int auxLat, auxLon;
            short auxMagX, auxMagY, auxMagZ;
            short auxAcelX, auxAcelY, auxAcelZ;
            short auxGirX, auxGirY, auxGirZ;

            //auxID = trama[4] << 24 | trama[3] << 16 | trama[2] << 8 | trama[1];
            //ID = auxID * 1.0;

            //auxTiempoMin = (char)(trama[8]);
            //tiempoMin = auxTiempoMin * 1.0;

            //auxTiempoSeg = (char)(trama[9]);
            //tiempoSeg = auxTiempoSeg * 1.0;

            auxNumPaquete = (short)(trama[2] << 8 | trama[1]);
            numPaquete = auxNumPaquete * 1.0;

            auxPresion = trama[5] << 16 | trama[4] << 8 | trama[3];
            presion = auxPresion / 10000.0;

            auxAltura = (ushort)(trama[7] << 8 | trama[6]);
            //altura = auxAltura * 1.0;
            //double presioNivelMarHpa = 1013.25;
            //altura = Math.Round(44330.0 * (1.0 - Math.Pow((presion / presioNivelMarHpa), 0.1903)), 3);
            altura = auxAltura / 10.0;


            auxTemp = (short)(trama[9] << 8 | trama[8]);
            Temp = auxTemp / 10.0;

            //volta y Corriente de los Paneles Solares
            auxVoltajePS = (short)(trama[11] << 8 | trama[10]);
            voltajePS = auxVoltajePS / 100.0;

            auxCorrientePS = (short)(trama[13] << 8 | trama[12]);
            corrientePS = auxCorrientePS / 100.0;

            //voltaje y corriente de las Baterias
            auxVoltajeBat = (short)(trama[15] << 8 | trama[14]);
            voltajeBat = auxVoltajeBat / 100.0;

            auxCorrienteBat = (short)(trama[17] << 8 | trama[16]);
            corrienteBat = auxCorrienteBat / 100.0;

            //Latitud y Longitud
            auxLat = trama[21] << 24 | trama[20] << 16 | trama[19] << 8 | trama[18];
            latitud = auxLat / 10000000.0;
            
            auxLon = trama[25] << 24 | trama[24] << 16 | trama[23] << 8 | trama[22];
            longitud = auxLon / 10000000.0;

            //Magnetometro
            auxMagX = (short)(trama[27] << 8 | trama[26]);
            magX = auxMagX * 1.0;

            auxMagY = (short)(trama[29] << 8 | trama[28]);
            magY = auxMagY * 1.0;

            auxMagZ = (short)(trama[31] << 8 | trama[30]);
            magZ = auxMagZ * 1.0;

            //Acelerometro
            auxAcelX = (short)(trama[33] << 8 | trama[32]);
            acelX = auxAcelX / 10.0;

            auxAcelY = (short)(trama[35] << 8 | trama[34]);
            acelY = auxAcelY / 10.0;

            auxAcelZ = (short)(trama[37] << 8 | trama[36]);
            acelZ = auxAcelZ / 10.0;

            //Giroscopio
            auxGirX = (short)(trama[39] << 8 | trama[38]);
            girX = auxGirX / 10.0;

            auxGirY = (short)(trama[41] << 8 | trama[40]);
            girY = auxGirY / 10.0;

            auxGirZ = (short)(trama[43] << 8 | trama[42]);
            girZ = auxGirZ / 10.0;

        }

        private void ShowData(object sender, EventArgs e)   //private void ShowData()
        {
            lblID.Text = ID.ToString();
            lblNumPaquete.Text = numPaquete.ToString();

            lblTemperatura.Text = Temp.ToString();
            lblPresion.Text = presion.ToString();
            lblAltura.Text = altura.ToString();

            lblAcelX.Text = acelX.ToString();
            lblAcelY.Text = acelY.ToString();
            lblAcelZ.Text = acelZ.ToString();

            lblGirX.Text = girX.ToString();
            lblGirY.Text = girY.ToString();
            lblGirZ.Text = girZ.ToString();

            lblMagX.Text = magX.ToString();
            lblMagY.Text = magY.ToString();
            lblMagZ.Text = magZ.ToString();

            //lblAzimuth.Text = Azimut.ToString();

            lblVoltajeBateria.Text = voltajeBat.ToString();
            lblCorrienteBateria.Text = corrienteBat.ToString();

            lblVoltajePS.Text = voltajePS.ToString();
            lblCorrientePS.Text = corrientePS.ToString();

            lblLatitud.Text = latitud.ToString();
            lblLongitud.Text = longitud.ToString();
            bunifuGauge1.Value = Convert.ToInt32((1.0 + voltajeBat - 4.2)*100.0);
            //bunifuGauge1.Value = Convert.ToInt32((Temp * 100) / 30.0);
            bunifuGauge1.Value = Convert.ToInt32((1.0 + voltajeBat - 4.2) * 100.0);

            UpdateCpuChart();
            InsertarDatosDataGrid();
        }

        private void UpdateCpuChart()
        {
            //Para ver las  grficas con el EJE X como cronomtro
            string segundos1 = seg.ToString();
            string minutos1 = min.ToString();
            string horas1 = hor.ToString();

            if (seg < 10) { segundos1 = "0" + seg.ToString(); }
            if (min < 10) { minutos1 = "0" + min.ToString(); }
            if (hor < 10) { horas1 = "0" + hor.ToString(); }
            string formato1 = minutos1 + ":" + segundos1;

            datosTemp.chtTemperatura.Series["T1"].Points.AddXY(formato1, Temp);

            datosPresion.chtPresion.Series["Presion"].Points.AddXY(formato1, presion);
            datosAltura.chtAltura.Series[0].Points.AddXY(formato1, altura);
            //datosPresion.chtPresion.Series["P_Atm"].Points.AddXY(formato1, PresAtm);
            //datosPresion.chtPresion.Series["P_mmHg"].Points.AddXY(formato1, PresmmHg);

            datosAcel.chtAcelerometro.Series["A_X"].Points.AddXY(formato1, acelX);
            datosAcel.chtAcelerometro.Series["A_Y"].Points.AddXY(formato1, acelY);
            datosAcel.chtAcelerometro.Series["A_Z"].Points.AddXY(formato1, acelZ);

            datosGiro.chtGiroscopio.Series["G_X"].Points.AddXY(formato1, girX);
            datosGiro.chtGiroscopio.Series["G_Y"].Points.AddXY(formato1, girY);
            datosGiro.chtGiroscopio.Series["G_Z"].Points.AddXY(formato1, girZ);

            datoMag.chtMagnetometro.Series["M_X"].Points.AddXY(formato1, magX);
            datoMag.chtMagnetometro.Series["M_Y"].Points.AddXY(formato1, magY);
            datoMag.chtMagnetometro.Series["M_Z"].Points.AddXY(formato1, magZ);

            if (datosTemp.chtTemperatura.Series["T1"].Points.Count == 40)
            {
                datosTemp.chtTemperatura.Series["T1"].Points.RemoveAt(0);
                datosPresion.chtPresion.Series["Presion"].Points.RemoveAt(0);
                datosAltura.chtAltura.Series[0].Points.RemoveAt(0);

                datosAcel.chtAcelerometro.Series["A_X"].Points.RemoveAt(0);
                datosAcel.chtAcelerometro.Series["A_Y"].Points.RemoveAt(0);
                datosAcel.chtAcelerometro.Series["A_Z"].Points.RemoveAt(0);

                datosGiro.chtGiroscopio.Series["G_X"].Points.RemoveAt(0);
                datosGiro.chtGiroscopio.Series["G_Y"].Points.RemoveAt(0);
                datosGiro.chtGiroscopio.Series["G_Z"].Points.RemoveAt(0);

                datoMag.chtMagnetometro.Series["M_X"].Points.RemoveAt(0);
                datoMag.chtMagnetometro.Series["M_Y"].Points.RemoveAt(0);
                datoMag.chtMagnetometro.Series["M_Z"].Points.RemoveAt(0);
            }

        }

        string tiempo;
        private void InsertarDatosDataGrid()
        {
            tiempo = DateTime.Now.ToString("hh:mm:ss");
            int n = datosLatLong.dataGridView2.Rows.Add();
            datosLatLong.dataGridView2.Rows[n].Cells[0].Value = tiempo;
            datosLatLong.dataGridView2.Rows[n].Cells[1].Value = Temp;
            datosLatLong.dataGridView2.Rows[n].Cells[2].Value = presion;
            datosLatLong.dataGridView2.Rows[n].Cells[3].Value = altura;
            datosLatLong.dataGridView2.Rows[n].Cells[4].Value = voltajeBat;
            datosLatLong.dataGridView2.Rows[n].Cells[5].Value = corrienteBat;
            datosLatLong.dataGridView2.Rows[n].Cells[6].Value = voltajePS;
            datosLatLong.dataGridView2.Rows[n].Cells[7].Value = corrientePS;
            datosLatLong.dataGridView2.Rows[n].Cells[8].Value = acelX;
            datosLatLong.dataGridView2.Rows[n].Cells[9].Value = acelY;
            datosLatLong.dataGridView2.Rows[n].Cells[10].Value = acelZ;
            datosLatLong.dataGridView2.Rows[n].Cells[11].Value = girX;
            datosLatLong.dataGridView2.Rows[n].Cells[12].Value = girY;
            datosLatLong.dataGridView2.Rows[n].Cells[13].Value = girZ;
            datosLatLong.dataGridView2.Rows[n].Cells[14].Value = magX;
            datosLatLong.dataGridView2.Rows[n].Cells[15].Value = magY;
            datosLatLong.dataGridView2.Rows[n].Cells[16].Value = magZ;

            int n2 = datosLatLong.dataGridView1.Rows.Add();
            datosLatLong.dataGridView1.Rows[n2].Cells[0].Value = latitud;
            datosLatLong.dataGridView1.Rows[n2].Cells[1].Value = longitud;
        }
        #endregion

        #region Comando 
        private void btnComando_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelComandoSubmenu);
        }

        String datoOUT;             //Variable para el envio de comandos
        String BW, SF;
        private void btnTransmitirComando_Click(object sender, EventArgs e)
        {
            VerificarBWySF();
            if (serialPort1.IsOpen)
            {
                datoOUT = Convert.ToString(cmbComando.Text);
                if (datoOUT == "Inicio Comm") { serialPort1.Write("0T2"); }
                if (datoOUT == "Finalizar Comm") { serialPort1.Write("0T0"); }
                if (datoOUT == "Camara") { serialPort1.Write("0C"); };
                if (datoOUT == "1 trama/0.5 seg") { serialPort1.Write("0T1"); }
                if (datoOUT == "1 trama/1 seg") { serialPort1.Write("0T2"); }
                if (datoOUT == "1 trama/2 seg") { serialPort1.Write("0T4"); }
                if (datoOUT == "1 trama/4 seg") { serialPort1.Write("0T8"); }
                if (datoOUT == "TX BW y SF") { serialPort1.Write("0L" + BW + SF); }
            }

            OcultarSubmenu();
        }
        private void VerificarBWySF()
        {
            switch (cBoxBW.Text)
            {
                case "[7.80 KHz]":
                    BW = "0";
                    break;
                case "[10.40 KHz]":
                    BW = "1";
                    break;
                case "[15.60 KHz]":
                    BW = "2";
                    break;
                case "[20.80 KHz]":
                    BW = "3";
                    break;
                case "[31.25 KHz]":
                    BW = "4";
                    break;
                case "[41.70 KHz]":
                    BW = "5";
                    break;
                case "[62.50 KHz]":
                    BW = "6";
                    break;
                case "[125.0 KHz]":
                    BW = "7";
                    break;
                case "[250.0 KHz]":
                    BW = "8";
                    break;
                case "[500.0 KHz]":
                    BW = "9";
                    break;
            }

            switch (cBoxSF.Text)
            {
                case "[SP6]":
                    SF = "0";
                    break;
                case "[SP7]":
                    SF = "1";
                    break;
                case "[SP8]":
                    SF = "2";
                    break;
                case "[SP9]":
                    SF = "3";
                    break;
                case "[SP10]":
                    SF = "4";
                    break;
                case "[SP11]":
                    SF = "5";
                    break;
                case "[SP12]":
                    SF = "6";
                    break;
            }
        }
        
        private void btnIncioFinalizar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if(btnIncioFinalizar.Text == "Inicio COMM")
                {
                    serialPort1.Write("0T2");
                    Task.Delay(3000);
                    timer1.Enabled = true;
                    btnIncioFinalizar.Text = "Finalizar COMM";
                }
                else
                {
                    serialPort1.Write("0T0");
                    timer1.Enabled = false;
                    btnIncioFinalizar.Text = "Inicio COMM";
                }
            }

            OcultarSubmenu();
        }
        #endregion

        #region Pestaña Sensores
        private void btnSensores_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSensoresSubmenu);
        }
        private void btnTemperatura_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosTemp);
            OcultarSubmenu();
        }

        private void btnPresion_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosPresion);
            OcultarSubmenu();
        }
        private void btnAltura_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosAltura);
            OcultarSubmenu();
        }

        private void btnvoltajeCorrienteBat_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnVoltajeCorrientePS_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnAceleracion_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosAcel);
            OcultarSubmenu();
        }

        private void btnGiroscopio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosGiro);
            OcultarSubmenu(); 
        }

        private void btnMagnetometro_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datoMag);
            OcultarSubmenu();
        }

        private void btnGraficarImagen_Click(object sender, EventArgs e)
        {
            ClaseImagen imagen = new ClaseImagen();

            if (foto[0] != 0x00)
            {
                var bytes = foto.ToArray();
                //we need to create a memoryStream with byte array
                var imageMemoryStream = new MemoryStream(bytes);
                // now we create an image from stream 
                Image imgFromStream = Image.FromStream(imageMemoryStream);
                // we can now save the byte array to a db, file, or transport (stream) it.

                imagen.pictureBox1.Image = imgFromStream;
                imagen.Show();
                j = 0;  //Reinicia el puntero del vector Foto
            }

            OcultarSubmenu();
        }
        #endregion

        //Para el cronometro de la mision
        int seg, min, hor;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();

            //Para el cronometro de la mision
            seg += 1;
            string segundos1 = seg.ToString();
            string minutos1 = min.ToString();
            string horas1 = hor.ToString();

            if (seg < 10) { segundos1 = "0" + seg.ToString(); }
            if (min < 10) { minutos1 = "0" + min.ToString(); }
            if (hor < 10) { horas1 = "0" + hor.ToString(); }

            lblTiempoMision.Text = horas1 + ":" + minutos1 + ":" + segundos1;

            if (seg == 59)
            {
                min += 1;
                seg = 0;
            }
            if (min == 59)
            {
                hor += 1;
                min = 0;
            }
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }

        private void btnBorarTabla_Click(object sender, EventArgs e)
        {
            datosLatLong.dataGridView1.Rows.Clear();
            datosLatLong.dataGridView1.Refresh();
        }

        private void btnGraficarRuta_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GMapOverlay Ruta = new GMapOverlay("CapaRuta");
            List<PointLatLng> puntos = new List<PointLatLng>();

            //Variables para almacenar
            double LatDataGrid, LongDataGrid;
            //Extraemos los datos del DataGrid
            for (int filas = 0; filas < datosLatLong.dataGridView1.Rows.Count - 1; filas++)
            {
                LatDataGrid = Convert.ToDouble(datosLatLong.dataGridView1.Rows[filas].Cells[0].Value);
                LongDataGrid = Convert.ToDouble(datosLatLong.dataGridView1.Rows[filas].Cells[1].Value);
                puntos.Add(new PointLatLng(LatDataGrid, LongDataGrid));

            }

            //Para dibujar la Ruta
            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
            //Ruta.Routes.Remove(PuntosRuta);
            Ruta.Routes.Add(PuntosRuta);
            //gMapControl1.Overlays.Remove(Ruta);
            gMapControl1.Overlays.Add(Ruta);
            //Actualizar mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 0.1;
            gMapControl1.Zoom = gMapControl1.Zoom - 0.1;

            puntos.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;

                toolStripStatusLblConectado.Text = "Desconectado";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }
    }
}
