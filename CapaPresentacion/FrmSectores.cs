using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmSectores : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmSectores()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txt_Sector, "Ingresar el nombre de la Sector.");
            this.ttMensaje.SetToolTip(this.cb_Provincia, "selecionar el nombre de la provincia.");
            this.Llenar_Combox();
            Mostrar();
        }

        //Mostrar mensaje de Confirmación
        private void MensageOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Prestamos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar mensaje de Error
        private void MensageError(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Prestamos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Limpiar
        private void Limpiar()
        {
            this.txt_Codigo.Text = string.Empty;
            this.txt_Sector.Text = string.Empty;
           
        }

        //habilitar
        private void Habilitar(bool valor)
        {
            this.txt_Sector.ReadOnly = !valor;
            this.txt_Codigo.ReadOnly = !valor;
            this.cb_Provincia.Enabled = !valor;

        }
        //habilitar botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btn_Nuevo.Enabled = false;
                this.btn_Guardar.Enabled = true;
                this.btn_Editar.Enabled = false;
                this.btn_Cancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btn_Nuevo.Enabled = true;
                this.btn_Guardar.Enabled = false;
                this.btn_Editar.Enabled = true;
                this.btn_Cancelar.Enabled = false;
            }
        }

        //Metodo Ocultar columnas
        private void Ocultar_Columnas()
        {
            this.dataListado.Columns[0].Visible = false;
           // this.dataListado.Columns[3].Visible = false;
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NSectores.Mostrar();
            this.Ocultar_Columnas();
            this.lbl_Total.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
            
        }

        //Metodo Buscar Nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NSectores.BuscarNombre(this.txt_Buscar.Text);
            this.Ocultar_Columnas();
            this.lbl_Total.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo Buscar Nombre Llenar_Combox
        private void Llenar_Combox()
        {
            cb_Provincia.DataSource = NProvincias.Mostrar();
            cb_Provincia.ValueMember = "codigo_provincia";
            cb_Provincia.DisplayMember = "provincia";
        }

        private void cb_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSectores_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txt_Sector.Focus();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txt_Sector.Text == string.Empty)
                {
                    MensageError("Faltan ingresar Datos");
                    errorIcono.SetError(txt_Sector, "Ingrese una Sector");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NSectores.Insertar(this.txt_Sector.Text.Trim().ToUpper(), Convert.ToInt32(this.cb_Provincia.SelectedValue));

                    }
                    else
                    {
                        rpta = NSectores.Editar(Convert.ToInt32(txt_Codigo.Text),
                        this.txt_Sector.Text.Trim().ToUpper(), Convert.ToInt32(this.cb_Provincia.SelectedValue));

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensageOk("Se Inseto de Forma Correcta");
                        }
                        else
                        {
                            this.MensageOk("Se Actualizo de Forma Correcta");
                        }
                    }
                    else
                    {
                        this.MensageError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txt_Codigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo_sector"].Value);
            this.txt_Sector.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector"].Value);
            this.cb_Provincia.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo_provincia"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (!txt_Codigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensageError("Debe de selecionar el registro a editar");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chk_Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Eliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;

            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {


                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NSectores.Eliminar(Convert.ToInt32(Codigo));
                        }
                        if (Rpta.Equals("OK"))
                        {
                            this.MensageOk("Se Elimino Correctamente el Registro");
                        }
                        else
                        {
                            this.MensageError(Rpta);
                        }

                    }

                }
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        

    }
}
