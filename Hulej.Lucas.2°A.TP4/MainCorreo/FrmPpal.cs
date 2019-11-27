using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos

        Correo correo;

        #endregion

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado delegado = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(delegado, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.ingresado:
                        if (!lstEstadoIngresado.Items.Contains(item.ToString()))
                        {
                            lstEstadoIngresado.Items.Add(item.ToString());
                        }
                        break;

                    case Paquete.EEstado.en_viaje:

                        if (!lstEstadoEnViaje.Items.Contains(item.ToString()))
                        {
                            lstEstadoEnViaje.Items.Add(item.ToString());
                            lstEstadoIngresado.Items.Clear();
                        }
                        break;

                    case Paquete.EEstado.entregado:
                        if (!lstEstadoEntregado.Items.Contains(item.ToString()))
                        {
                            lstEstadoEntregado.Items.Add(item.ToString());
                            lstEstadoEnViaje.Items.Clear();
                        }
                        break;
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento is Paquete)
                {
                    this.rtbMostrar.Text = ((Paquete)elemento).ToString();
                }
                else if (elemento is Correo)
                {
                    this.rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                this.rtbMostrar.Text.Guardar("salida");
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
