﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*Formulario en donde se ingresaran los datos del viaje a comprar*/

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class IngresoDatosViaje : BaseForm
    {
        public String codigoViaje;
        public String codigoRecorrido;
        public String microPatente;
        public String butacasDisponibles;
        public String kgsDisponibles;
        public String tipoServicio;
        public int pasajesCompra;
        public int kgsCompra;

        public DataTable pasajeEncomiendaNro;

        public IngresoDatosViaje():
               base()
        {
            InitializeComponent();
            cargarCiudades();
            pasajeEncomiendaNro = new DataTable("Pasaje_Encomienda_Nro");
            pasajeEncomiendaNro.Columns.Add("Pasaje_Encomienda_Nro");
        }

        /*Se cargan las ciudades origen y destino posibles desde la base de datos*/
        private void cargarCiudades()
        {
            DataTable ciudadesOrigenDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getCiudades();
            ciudadOrigencomboBox.DataSource = ciudadesOrigenDt;
            ciudadOrigencomboBox.ValueMember = "CIUDAD_ID";
            ciudadOrigencomboBox.DisplayMember = "CIUDAD_NOMBRE";

            DataTable ciudadesDestinoDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getCiudades();
            ciudadDestinoComboBox.DataSource = ciudadesDestinoDt;
            ciudadDestinoComboBox.ValueMember = "CIUDAD_ID";
            ciudadDestinoComboBox.DisplayMember = "CIUDAD_NOMBRE";
        }

        /* Busca si existen viajes disponibles en la base de datos segun lo ingresado por el usuario */
        private void buscarViajeButton_Click(object sender, EventArgs e)
        {
            errorViajeLabel.Text = "";

            String fechaSeleccionada = (viajeDateTimePicker.Value.Year * 10000 + viajeDateTimePicker.Value.Month * 100 + viajeDateTimePicker.Value.Day).ToString();
            String origenSeleccionado = (ciudadOrigencomboBox.SelectedIndex + 1).ToString();
            String destinoSeleccionado = (ciudadDestinoComboBox.SelectedIndex + 1).ToString();

            if (origenSeleccionado.Equals(destinoSeleccionado))
                errorViajeLabel.Text = "Ciudad de origen y ciudad de destino deben ser diferentes.";
            else
            {
                DataTable viajeLibreDt = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getViajeLibre(fechaSeleccionada, origenSeleccionado, destinoSeleccionado);
                if (viajeLibreDt.Rows.Count != 0)
                {
                    codigoViaje = viajeLibreDt.Rows[0].ItemArray[0].ToString();
                    codigoRecorrido = viajeLibreDt.Rows[0].ItemArray[1].ToString();
                    microPatente = viajeLibreDt.Rows[0].ItemArray[2].ToString();
                    butacasDisponibles = viajeLibreDt.Rows[0].ItemArray[3].ToString();
                    kgsDisponibles = viajeLibreDt.Rows[0].ItemArray[4].ToString();

                    if (!butacasDisponibles.Equals("0"))
                    {
                        pasajesDisponiblesTextBox.Enabled = true;
                        pasajesDisponiblesTextBox.Text = butacasDisponibles;
                    }

                    if (!butacasDisponibles.Equals("0"))
                    {
                        kgsDisponiblesTextBox.Enabled = true;
                        kgsDisponiblesTextBox.Text = kgsDisponibles;
                    }

                    tipoServicio = FrbaBus.Compra_de_Pasajes.FuncionesCompraPasajes.getTipoServicio(codigoRecorrido);
                    if (!tipoServicio.Equals(""))
                    {
                        servicioTextBox.Enabled = true;
                        servicioTextBox.Text = tipoServicio;
                    }

                    cantidadPasajesTextBox.Enabled = true;
                    KgsEncomiendaTextBox.Enabled = true;
                    siguienteButton.Enabled = true;
                }
                else
                    errorViajeLabel.Text = "No hay viajes disponibles para esa fecha.";
            }
        }
        
        /* Finaliza las transacciones verificando que se hayan ingresado valores validos, y genera instancias de los formularios para comprar encomiendas y pasajes segun corresponda */
        private void siguienteButton_Click(object sender, EventArgs e)
        {
            errorViajeLabel.Text = "";

            int pasajesDisponibles = Convert.ToInt16(pasajesDisponiblesTextBox.Text);
            int kgsDisponibles = Convert.ToInt16(kgsDisponiblesTextBox.Text);
            pasajesCompra = Convert.ToInt16(cantidadPasajesTextBox.Text);
            kgsCompra = Convert.ToInt16(KgsEncomiendaTextBox.Text);

            if (pasajesCompra <= pasajesDisponibles && kgsCompra <= kgsDisponibles)
            {
                if (pasajesCompra > 0 || kgsCompra > 0)
                {
                    if (kgsCompra == 0)
                    {
                        IngresoDatosPasaje frmPasaje = new IngresoDatosPasaje(codigoViaje, codigoRecorrido, microPatente, tipoServicio, pasajesCompra, kgsCompra, pasajeEncomiendaNro);
                        frmPasaje.Show();
                    }
                    else
                    {
                        if (pasajesCompra >= 0)
                        {
                            IngresoDatosEncomienda frmEncomienda = new IngresoDatosEncomienda(codigoViaje, codigoRecorrido, microPatente, tipoServicio, pasajesCompra, kgsCompra, pasajeEncomiendaNro);
                            frmEncomienda.Show();
                        }
                    }
                }   
                else
                    errorViajeLabel.Text = "Ingrese cantidades válidas.";
           }
           else
           errorViajeLabel.Text = "Ingrese cantidades válidas.";
        }

        private void IngresoDatosViaje_Load(object sender, EventArgs e)
        {

        }

        private void menuPrincipalButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MenuPrincipal.Show();
        }
    }
}
