using System;
using System.Windows.Forms;

namespace ProyectoFinalSimulacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Carga = 3500; // Carga inicial del inversor
        int Consumo = 0; // Consumo actual
        int Limite = 5000; // limite de carga del inversor
        bool inversor = false; // Estado del inversor

        
        // Consumo de los articulos de la casa --------------------------------------------------------------------------------------

        int Bombilla = 1; // Consumo de los bombillos 
        int Television = 50; // Consumo de los televisores
        int Abanico = 10; // Consumo de los abanicos
        int Radio = 30; // Consumo de los radios
        int Pecera = 5; // Consumo de la pecera
        int Microondas = 100; // Consumo del microondas
        int Extractor = 10; // Consumo del extractor 
        int VideoJuegos = 3; // Consumo de los video juegos
         


        public void CalcularCarga() // Funcion encargada de calcular la carga del inversor
        {
            if(Luz == true)
            {
                if(Carga >= Limite)
                {
                    Carga = Limite;
                    CargarTimer.Enabled = false;
                }
                else
                {
                    Carga += 25;
                }
            }
            else
            {
                Carga = (Carga - Consumo) / 5000;
            }
            CargaLabel.Text = Convert.ToString(Carga);
        }
        
        // Luz  --------------------------------------------------------------------------------------------------------------------

        bool Luz = true;
        private void LuzButton_Click(object sender, EventArgs e)
        {
            if(Luz == true)
            {
                Luz = false;
                LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                inversor = true;
                InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            }
            else
            {
                Luz = true;
                LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                inversor = false;
                InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            }

        }

        
        
        
        
        
        
        
        
        
        // Galeria -----------------------------------------------------------------------------------------------------------------

        bool BoG = false, TVG = false, RaG = false, AbG = false, PeG = false;
        
        private void BoGButton_Click(object sender, EventArgs e) // Bombillo
        {
            if(BoG == false)
            {
                BoG = true;
                BoGButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            }
            else
            {
                BoG = false;
                BoGButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            }
        }

        private void TVGButton_Click(object sender, EventArgs e) // Television
        {

        }

        private void RaGButton_Click(object sender, EventArgs e) // Radio
        {

        }

        private void AbGButton_Click(object sender, EventArgs e) // Abanico
        {

        }

        private void PeGButton_Click(object sender, EventArgs e) // Pecera
        {

        }
    }
}
