using System;
using System.Windows.Forms;
using System.IO;
namespace Capa_Vista_Componente_Consultas
{

    // Realizado por: Nelson Jose Godinez Mendez 0901-22-3550
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();

        }



        private void btn_ConsultaSimple_Click(object sender, EventArgs e)
        {
            using (var f = new Frm_Consultas())
            {
                this.Hide();
                f.ShowDialog(this);
                this.Show();
            }
        }


        private void btn_ConsultaCompleja_Click(object sender, EventArgs e)
        {
            using (var f = new Frm_Consulta_Compleja())
            {
                this.Hide();
                f.ShowDialog(this);
                this.Show();
            }
        }

        // Se agrega el path específico ubicado en bin/debug de ayudas para que aparezcan - Realizado por Nelson Godínez 0901-22-3550 07/10/2025
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta relativa exacta según tu estructura actual
                string chmPath = Path.GetFullPath(
                    Path.Combine(Application.StartupPath, @"..\..\..\..\Ayuda_Consultas\AyudaConsultaAS2.chm")
                );

                if (File.Exists(chmPath))
                {
                    Help.ShowHelp(this, chmPath, HelpNavigator.TableOfContents);
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de ayuda en:\n" + chmPath,
                        "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la ayuda:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}
