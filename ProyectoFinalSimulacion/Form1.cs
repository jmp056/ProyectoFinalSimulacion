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

        // Variables globales -----------------------------------------------------------------------------------------------------------

        bool Inversor = false; // Estado del inversor
        bool Luz = true; // Estado del inversor
        decimal Porcentaje = 0;
        int Carga = 3500; // Carga inicial del inversor
        int Consumo = 0; // Consumo actual
        int Limite = 5000; // limite de carga del inversor
        int Aumento = 25; // Cantidad que aumenta la carga en un lapso de tiempo
        int Tiempo = 0; // Tiempo en el que el inversor realizara una accion


        
        // Consumo de los articulos de la casa ------------------------------------------------------------------------------------------

        int Bombilla = 1; // Consumo de los bombillos 
        int Television = 20; // Consumo de los televisores
        int Abanico = 10; // Consumo de los abanicos
        int Radio = 30; // Consumo de los radios
        int Pecera = 5; // Consumo de la pecera
        int Microondas = 40; // Consumo del microondas
        int Extractor = 10; // Consumo del extractor 
        int VideoJuegos = 5; // Consumo de los video juegos


        public void CalcularCarga() // Funcion encargada de calcular la carga del inversor
        {
            if(Luz == true)
            {
                if(Carga >= Limite)
                {
                    Carga = Limite;
                    CargaTimer.Enabled = false;
                    InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.PausaBtn;
                    MensajeCargaLabel.Text = "¡Carga Completa!";
                    ImprimirMensaje("¡Las baterías del inversor\nestán totalmente\ncargadas, el inversor se\nencuentra en reposo!");
                }
                else
                {
                    Carga += Aumento;
                    Tiempo = (Limite - Carga) / Aumento;
                    MensajeCargaLabel.Text = "Carga completa en: " + Tiempo + " Min";
                }
            }
            else
            {
                Carga -= Consumo;
                if (Consumo == 0)
                    MensajeCargaLabel.Text = "No hay ningun consumo";
                else
                {
                    Tiempo = Carga / Consumo;
                    MensajeCargaLabel.Text = "Quedan " + Tiempo + " Min. de carga";
                }


                if (Carga <= 0)
                {
                    Carga = 0;
                    Inversor = false;
                    InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                    ImprimirMensaje("¡Las baterías del inversor\nse han descargado!");
                    CargaTimer.Enabled = false;
                    SeDescargoElInversor();
                }

            }
            
            Porcentaje = (Carga * 100) / 5000;
            CargaLabel.Text = Porcentaje.ToString("N2");
        }

        public void ImprimirMensaje(string Mensaje) // Funcion encargada de imprimir el mensaje
        {
            MensajeLabel.Text = Mensaje;
            MensajeTimer.Enabled = true;
        }

        public bool ValidarCarga() // Funcion encargada de validar la carga del inversor
        {
            bool paso = true;

            if(Carga <= 0)
            {
                ImprimirMensaje("¡El inversor esta\ndescargado, no\npuede\nencender este articulo!");
                paso = false;
            }

            return paso;
        }
        
        // Timers ----------------------------------------------------------------------------------------------------------------------
        
        private void CargaTimer_Tick(object sender, EventArgs e) // Timer para actulizar la carga
        {
            CalcularCarga();
        }

        private void MensajeTimer_Tick(object sender, EventArgs e) // Timer del mensaje
        {
            MensajeLabel.Text = string.Empty;
            MensajeTimer.Enabled = false;
        }

        // Luz  ------------------------------------------------------------------------------------------------------------------------

        private void LuzButton_Click(object sender, EventArgs e) // Boton de la luz
        {

            if(Luz == true)
            {
                Luz = false;
                LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Inversor = true;
                InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                SeFueLaLuz();
            }
            else
            {
                Luz = true;
                LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Inversor = false;
                InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                LlegoLaLuz();
            }
            CargaTimer.Enabled = true;
        }


        // Inversor ---------------------------------------------------------------------------------------------------------------
        
        private void InversorButton_Click(object sender, EventArgs e) // Boton del inversor
        {
            //if (Inversor == true)
            //{
            //    Inversor = false;
            //    InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            //    Luz = true;
            //    LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            //    CargaTimer.Enabled = true;
            //}
            //else
            //{
            //    Inversor = true;
            //    InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            //    Luz = false;
            //    LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            //}

            //if(Luz == true)
            //{
            //    if (MessageBox.Show("Hay luz, está seguro que desea utilizar el inversor?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            //    {
            //        LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.PausaBtn;
                    
            //        Inversor = true;
            //        CargaTimer.Enabled = true;
            //        InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            //    }
            //}

            //if(Inversor == true)
            //{
            //    Inversor = false;
            //    InversorButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            //    if(LuzReposo == true && Luz == true)
            //    {
            //        LuzReposo = false;
            //        LuzButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
            //    }
            //    else if(Luz == false)
            //    {
            //        CargaTimer.Enabled = false;
            //    }
            //}
        }
        
        // Galeria -----------------------------------------------------------------------------------------------------------------

        bool BoS = false, TVS = false, RaS = false, AbS = false, PeS = false;
        
        private void BoGButton_Click(object sender, EventArgs e) // Bombillo
        {
            if (!ValidarCarga())
                return;

            if (BoS == false)
            {
                BoS = true;
                BoSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoS = false;
                BoSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }



        private void TVGButton_Click(object sender, EventArgs e) // Television
        {
            if (!ValidarCarga())
                return;

            if (TVS == false)
            {
                TVS = true;
                TvSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Television;
            }
            else
            {
                TVS = false;
                TvSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Television;
            }
        }



        private void RaGButton_Click(object sender, EventArgs e) // Radio
        {
            if (!ValidarCarga())
                return;

            if (RaS == false)
            {
                RaS = true;
                RaSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Radio;
            }
            else
            {
                RaS = false;
                RaSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Radio;
            }
        }

        private void AbGButton_Click(object sender, EventArgs e) // Abanico
        {
            if (!ValidarCarga())
                return;

            if (AbS == false)
            {
                AbS = true;
                AbSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbS = false;
                AbSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }



        private void PeGButton_Click(object sender, EventArgs e) // Pecera
        {
            if (!ValidarCarga())
                return;

            if (PeS == false)
            {
                PeS = true;
                PeSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Pecera;
            }
            else
            {
                PeS = false;
                PeSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Pecera;
            }
        }


        // Comedor -----------------------------------------------------------------------------------------------------------------

        bool BoC1 = false, AbC1 = false;

        private void BoC1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoC1 == false)
            {
                BoC1 = true;
                BoC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoC1 = false;
                BoC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }
        
        private void AbCButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (AbC1 == false)
            {
                AbC1 = true;
                AbC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbC1 = false;
                AbC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }



        // Cocina -----------------------------------------------------------------------------------------------------------------

        bool BoC2 = false, NeC = true, MiC = false, ExC = false;

        private void BoC2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoC2 == false)
            {
                BoC2 = true;
                BoC2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoC2 = false;
                BoC2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void NeCButton_Click(object sender, EventArgs e)
        {
            if(NeC == true)
            {
                NeC = false;
                NeCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            }
            else
            {
                if(Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender la nevera!");
                }
                else
                {
                    NeC = true;
                    NeCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                }
            }
        }

        private void MiCButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (MiC == false)
            {
                MiC = true;
                MiCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Microondas;
            }
            else
            {
                MiC = false;
                MiCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Microondas;
            }
        }

        private void ExCButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (ExC == false)
            {
                ExC = true;
                ExCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Extractor;
            }
            else
            {
                ExC = false;
                ExCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Extractor;
            }
        }

        // Pasillo -----------------------------------------------------------------------------------------------------------------

        bool BoP1 = false, BoP2 = false, BoP3 = false;

        private void BoP1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoP1 == false)
            {
                BoP1 = true;
                BoP1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoP1 = false;
                BoP1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void BoP2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoP2 == false)
            {
                BoP2 = true;
                BoP2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoP2 = false;
                BoP2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void BoP3Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoP3 == false)
            {
                BoP3 = true;
                BoP3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoP3 = false;
                BoP3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        // Area Libre -----------------------------------------------------------------------------------------------------------------

        bool BoAl = false, AbAl = false, RaAl = false, AiAl = false, TvAl = false, VjAl = false;

        private void BoAlButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoAl == false)
            {
                BoAl = true;
                BoAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoAl = false;
                BoAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void AbAlButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (AbAl == false)
            {
                AbAl = true;
                AbAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbAl = false;
                AbAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }

        private void RaAlButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (RaAl == false)
            {
                RaAl = true;
                RaAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Radio;
            }
            else
            {
                RaAl = false;
                RaAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Radio;
            }
        }

        private void AiAlButton_Click(object sender, EventArgs e)
        {
            if(AiAl == false)
            {
                if(Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender el aire\nacondicionado!");
                }
                else
                {
                    AiAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                    AiAl = true;
                }
            }
            else
            {
                AiAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                AiAl = false;
            }
        }

        private void TvAlButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (TvAl == false)
            {
                TvAl = true;
                TvAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Television;
            }
            else
            {
                TvAl = false;
                TvAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Television;
            }
        }

        private void Vj4Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (VjAl == false)
            {
                VjAl = true;
                VjAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += VideoJuegos;
            }
            else
            {
                VjAl = false;
                VjAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= VideoJuegos;
            }
        }

        // Habitacion #1 -----------------------------------------------------------------------------------------------------------------

        bool BoH1 = false, TvH1 = false, VjH1 = false, AbH1 = false, AiH1 = false, NeH1 = true;

        private void BoH1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoH1 == false)
            {
                BoH1 = true;
                BoH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoH1 = false;
                BoH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void TvH1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (TvH1 == false)
            {
                TvH1 = true;
                TvH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Television;
            }
            else
            {
                TvH1 = false;
                TvH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Television;
            }
        }

        private void Vj1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (VjH1 == false)
            {
                VjH1 = true;
                VjH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += VideoJuegos;
            }
            else
            {
                VjH1 = false;
                VjH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= VideoJuegos;
            }
        }

        private void AbH1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (AbH1 == false)
            {
                AbH1 = true;
                AbH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbH1 = false;
                AbH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }

        private void AiHa1Button_Click(object sender, EventArgs e)
        {
            if (AiH1 == false)
            {
                if (Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender el aire\nacondicionado!");
                }
                else
                {
                    AiH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                    AiH1 = true;
                }
            }
            else
            {
                AiH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                AiH1 = false;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (NeH1 == true)
            {
                NeH1 = false;
                NeH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            }
            else
            {
                if (Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender la nevera!");
                }
                else
                {
                    NeH1 = true;
                    NeH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                }
            }
        }

        // Baños -----------------------------------------------------------------------------------------------------------------

        bool BoB1 = false, BoB2 = false;
        private void BoB1Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoB1 == false)
            {
                BoB1 = true;
                BoB1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoB1 = false;
                BoB1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }
        
        private void BoB2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoB2 == false)
            {
                BoB2 = true;
                BoB2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoB2 = false;
                BoB2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        // Habitacion #2 -----------------------------------------------------------------------------------------------------------------

        bool BoH2 = false, AiH2 = false, TvH2 = false, VjH2 = false, AbH2 = false;

        private void BoH2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoH2 == false)
            {
                BoH2 = true;
                BoH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoH2 = false;
                BoH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void AiHa2Button_Click(object sender, EventArgs e)
        {
            if (AiH2 == false)
            {
                if (Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender el aire\nacondicionado!");
                }
                else
                {
                    AiH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                    AiH2 = true;
                }
            }
            else
            {
                AiH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                AiH2 = false;
            }
        }

        private void TvH2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (TvH2 == false)
            {
                TvH2 = true;
                TvH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Television;
            }
            else
            {
                TvH2 = false;
                TvH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Television;
            }
        }

        private void Vj2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (VjH2 == false)
            {
                VjH2 = true;
                VjH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += VideoJuegos;
            }
            else
            {
                VjH2 = false;
                VjH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= VideoJuegos;
            }
        }

        private void AbH2Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (AbH2 == false)
            {
                AbH2 = true;
                AbH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbH2 = false;
                AbH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }

        // Habitacion #3 -----------------------------------------------------------------------------------------------------------------

        bool BoH3 = false, AiH3 = false, TvH3 = false, VjH3 = false, AbH3 = false;
        
        private void BoH3Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (BoH3 == false)
            {
                BoH3 = true;
                BoH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Bombilla;
            }
            else
            {
                BoH3 = false;
                BoH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Bombilla;
            }
        }

        private void AiHa3Button_Click(object sender, EventArgs e)
        {
            if (AiH3 == false)
            {
                if (Luz == false)
                {
                    ImprimirMensaje("¡No hay luz, no puede\nencender el aire\nacondicionado!");
                }
                else
                {
                    AiH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                    AiH3 = true;
                }
            }
            else
            {
                AiH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                AiH3 = false;
            }
        } 
        
        private void Vj3Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (VjH3 == false)
            {
                VjH3 = true;
                VjH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += VideoJuegos;
            }
            else
            {
                VjH3 = false;
                VjH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= VideoJuegos;
            }
        }
        private void TvH3Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (TvH3 == false)
            {
                TvH3 = true;
                TvH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Television;
            }
            else
            {
                TvH3 = false;
                TvH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Television;
            }
        }
        
        private void AbH3Button_Click(object sender, EventArgs e)
        {
            if (!ValidarCarga())
                return;

            if (AbH3 == false)
            {
                AbH3 = true;
                AbH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
                Consumo += Abanico;
            }
            else
            {
                AbH3 = false;
                AbH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
                Consumo -= Abanico;
            }
        }

        public void SeFueLaLuz() // Funcion encargada de apagar todo lo que funciona solo con luz
        {
            if(NeC == true) // Nevera de la cocina
                NeCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            
            if (AiAl == true) // Aire del area libre
                AiAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AiH1 == true) // Aire de la habitacion #1
                 AiH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (NeH1 == true) // Nevera de la habitacion #1
                NeH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AiH2 == true) // Aire de la habitacion #2
                AiH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AiH3 == true) // Aire de la habitacion #3
                AiH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
        }

        public void SeDescargoElInversor() // Funcion encargada de apagar todo lo que esta encendido cuando el inversor se descarga
        {
            if(BoS == true) // Bombillo de la sala
                BoSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            
            if (RaS == true) // Radio de la sala
                RaSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            
            if (AbS == true) // Abanico de la sala
                AbSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (PeS == true) // Pecera de la sala
                PeSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (TVS == true) // Television de la sala
                TvSButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoC1 == true) // Bombillo del comedor
                BoC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
            
            if (AbC1 == true) // Abanico del comedor
                AbC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoC2 == true) // Bombillo de la cocina
                BoC2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (MiC == true) // Microondas de la cocina
                MiCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (ExC == true) // Extractor de grasa de la cocina
                ExCButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoP1 == true) // Bombillo del pasillo #1
                BoP1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoP2 == true) // Bombillo del pasillo #2
                BoP2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoP3 == true) // Bombillo del pasillo #3
                BoP3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoAl == true) // Bombillo del area libre
                BoAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AbAl == true) // Abanico del area libre
                AbAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (RaAl == true) // Radio del area libre
                RaAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (TvAl == true) // Television del area libre
                TvAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (VjAl == true) // Video juego del area libre
                VjAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoH1 == true) // Bombillo de la habitacion #1
                BoH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (TvH1 == true) // Television de la habitacion #1
                TvH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (VjH1 == true) // Video juego de la habitacion #1
                VjH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AbH1 == true) // Abanico de la habitacion #1
                AbH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoB1 == true) // Bombillo del baño #1
                BoB1Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoH2 == true) // Bombillo de la habitacion #2
                BoH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (TvH2 == true) // Television de la habitacion #2
                TvH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (VjH2 == true) // Video juego de la habitacion #2
                VjH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AbH2 == true) // Abanico de la habitacion #2
                AbH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoB2 == true) // Bombillo del baño #2
                BoB2Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (BoH3 == true) // Bombillo de la habitacion #3
                BoH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (TvH3 == true) // Television de la habitacion #3
                TvH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (VjH3 == true) // Video juego de la habitacion #3
                VjH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;

            if (AbH3 == true) // Abanico de la habitacion #3
                AbH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.ApagadoBtn;
        }

        public void LlegoLaLuz() // Funcion encargada de encender todo lo que estaba encendido se fue la luz y luego regresa
        {
            if (NeC == true) // Nevera de la cocina
                NeCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AiAl == true) // Aire del area libre
                AiAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AiH1 == true) // Aire de la habitacion #1
                AiH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (NeH1 == true) // Nevera de la habitacion #1
                NeH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AiH2 == true) // Aire de la habitacion #2
                AiH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AiH3 == true) // Aire de la habitacion #3
                AiH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;


            if (BoS == true) // Bombillo de la sala
                BoSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (RaS == true) // Radio de la sala
                RaSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbS == true) // Abanico de la sala
                AbSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (PeS == true) // Pecera de la sala
                PeSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (TVS == true) // Television de la sala
                TvSButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoC1 == true) // Bombillo del comedor
                BoC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbC1 == true) // Abanico del comedor
                AbC1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoC2 == true) // Bombillo de la cocina
                BoC2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (MiC == true) // Microondas de la cocina
                MiCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (ExC == true) // Extractor de grasa de la cocina
                ExCButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoP1 == true) // Bombillo del pasillo #1
                BoP1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoP2 == true) // Bombillo del pasillo #2
                BoP2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoP3 == true) // Bombillo del pasillo #3
                BoP3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoAl == true) // Bombillo del area libre
                BoAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbAl == true) // Abanico del area libre
                AbAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (RaAl == true) // Radio del area libre
                RaAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (TvAl == true) // Television del area libre
                TvAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (VjAl == true) // Video juego del area libre
                VjAlButton.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoH1 == true) // Bombillo de la habitacion #1
                BoH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (TvH1 == true) // Television de la habitacion #1
                TvH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (VjH1 == true) // Video juego de la habitacion #1
                VjH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbH1 == true) // Abanico de la habitacion #1
                AbH1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoB1 == true) // Bombillo del baño #1
                BoB1Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoH2 == true) // Bombillo de la habitacion #2
                BoH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (TvH2 == true) // Television de la habitacion #2
                TvH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (VjH2 == true) // Video juego de la habitacion #2
                VjH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbH2 == true) // Abanico de la habitacion #2
                AbH2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoB2 == true) // Bombillo del baño #2
                BoB2Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (BoH3 == true) // Bombillo de la habitacion #3
                BoH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (TvH3 == true) // Television de la habitacion #3
                TvH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (VjH3 == true) // Video juego de la habitacion #3
                VjH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;

            if (AbH3 == true) // Abanico de la habitacion #3
                AbH3Button.Image = ProyectoFinalSimulacion.Properties.Resources.EncendidoBtn;
        }
    }
}
